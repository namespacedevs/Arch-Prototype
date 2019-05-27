using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ArchPrototype.Domain.Core.Pipeline
{
    public class Response
    {
        private readonly IList<Notification> _messages = new List<Notification>();

        public IEnumerable<Notification> Errors { get; }
        public object Result { get; }

        public Response() => Errors = new ReadOnlyCollection<Notification>(_messages);

        public Response(object result) : this() => Result = result;

        public Response AddError(Notification message)
        {
            _messages.Add(message);
            return this;
        }
    }
}