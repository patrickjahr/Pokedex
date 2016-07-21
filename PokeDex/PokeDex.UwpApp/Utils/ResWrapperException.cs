using System;

namespace PokeDex.UwpApp.Utils
{
    public class ResWrapperException : Exception
    {
        public ResWrapperException()
        {
        }

        public ResWrapperException(string message)
            : base(message)
        {
        }

        public ResWrapperException(string message, Exception inner)
            : base(message, inner)
        {
        }


    }
}
