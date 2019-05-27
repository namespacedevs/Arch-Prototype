using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using ArchPrototype.Domain.Core.Pipeline;
using ArchPrototype.Infrastructure.Contexts;
using ArchPrototype.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using ArchPrototype.Domain.Classificacao.Contracts;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace ProntotipoInterisk.API.App_Start
{
    public static class SimpleInjectorWebApiInitializer
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            InitializeContainer(container);
            container.RegisterWebApiControllers(config);
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            const string applicationAssemblyName = "ArchPrototype.Domain";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            var assembliesValidators = AssemblyScanner.FindValidatorsInAssembly(assembly)
                .Select(x => x.ValidatorType.Assembly).ToArray();
            container.Collection.Register(typeof(IValidator<>), assembliesValidators);

            RegisterMediator(container, assembly);

            container.Register<EfDataContext, EfDataContext>(Lifestyle.Scoped);
            container.Register<IClassificacaoRepository, ClassificacaoRepository>(Lifestyle.Scoped);
        }

        private static void RegisterMediator(Container container, params Assembly[] assemblies)
        {
            var allAssemblies = new List<Assembly> {typeof(IMediator).GetTypeInfo().Assembly};
            allAssemblies.AddRange(assemblies);

            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), allAssemblies);

            // we have to do this because by default, generic type definitions (such as the Constrained Notification Handler) won't be registered
            var notificationHandlerTypes = container.GetTypesToRegister(typeof(INotificationHandler<>), assemblies,
                new TypesToRegisterOptions
                {
                    IncludeGenericTypeDefinitions = true,
                    IncludeComposites = false
                });
            container.Register(typeof(INotificationHandler<>), notificationHandlerTypes);

            container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                //typeof(RequestPreProcessorBehavior<,>),
                //typeof(RequestPostProcessorBehavior<,>),
                typeof(FailFastRequestBehavior<,>)
            });

            //container.Collection.Register(typeof(IRequestPreProcessor<>), new[] { typeof(GenericRequestPreProcessor<>) });
            //container.Collection.Register(typeof(IRequestPostProcessor<,>), new[] { typeof(GenericRequestPostProcessor<,>), typeof(ConstrainedRequestPostProcessor<,>) });

            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);
        }
    }
}