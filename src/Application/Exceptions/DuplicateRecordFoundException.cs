using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SRIS.Application.Exceptions
{
    public class DuplicateRecordFoundException : Exception
    {
        private string v;
        private Guid iD;

        public DuplicateRecordFoundException()
        {
        }

        public DuplicateRecordFoundException(string message) : base(message)
        {
        }

        public DuplicateRecordFoundException(string v, Guid iD)
        {
            this.v = v;
            this.iD = iD;
        }

        public DuplicateRecordFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateRecordFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public DuplicateRecordFoundException(string name, object key)
           : base($"Entity \"{name}\" ({key}) Duplicate found.")
        {
        }
    }
}
