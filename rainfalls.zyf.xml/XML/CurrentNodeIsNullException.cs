using System;

namespace Zyf.Xml
{
    public class CurrentNodeIsNullException : Exception
    {
        public CurrentNodeIsNullException() { }
        public CurrentNodeIsNullException(string message) : base(message) { }
    }
}
