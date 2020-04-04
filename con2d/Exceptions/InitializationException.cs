using System;
using System.Collections.Generic;
using System.Text;

namespace con2d.Exceptions {

    public class InitializationException : Exception {

        public InitializationException() { }
        public InitializationException(string message) : base(message) { }
        public InitializationException(string message, Exception inner) : base(message, inner) { }
    }
}
