using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ArchPrototype.Domain.Core.Models
{
    public class Response
    {
        private readonly IList<Notification> _messages = new List<Notification>();

        public Response()
        {
            Errors = new ReadOnlyCollection<Notification>(_messages);
        }

        public Response(object result) : this()
        {
            Result = result;
        }

        public IEnumerable<Notification> Errors { get; }
        public object Result { get; }

        public Response AddError(Notification message)
        {
            _messages.Add(message);
            return this;
        }
    }
}