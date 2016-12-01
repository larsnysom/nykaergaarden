﻿using System;
using System.Runtime.Serialization;

namespace Nykaergaarden.SharedKernel.Infrastructure.Shared.Exceptions
{
    [Serializable]
    public class InvalidCommandException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public InvalidCommandException()
        {
        }

        public InvalidCommandException(string message) : base(message)
        {
        }

        public InvalidCommandException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidCommandException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
