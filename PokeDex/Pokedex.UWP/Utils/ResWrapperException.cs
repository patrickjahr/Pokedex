using System;

namespace Pokedex.UWP.Utils
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
