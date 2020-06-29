using System;

namespace Zyf.Xml
{
    public class DocumentNotExistException : Exception
    {
        public DocumentNotExistException() { }
        public DocumentNotExistException(string message) : base(message) { }
    }
}
