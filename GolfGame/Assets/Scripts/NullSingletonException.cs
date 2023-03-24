using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class NullSingletonException : Exception {
    public NullSingletonException() : base("No instance of Singleton exists.") { }
    public NullSingletonException(string name) : base("No instance of " + name + " exists.") { }
    public NullSingletonException(string message, Exception inner) : base(message, inner) { }
}
