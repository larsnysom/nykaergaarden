using System;
using System.Runtime.Serialization;

namespace Audit.Exceptions
{
    [Serializable]
    public class LoggerSetupException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public LoggerSetupException()
        {
        }

        public LoggerSetupException(string message) : base(message)
        {
        }

        public LoggerSetupException(string message, Exception inner) : base(message, inner)
        {
        }

        protected LoggerSetupException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}