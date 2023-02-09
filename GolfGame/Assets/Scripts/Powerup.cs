using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// It looks silly that I'm making an abstract class with only one function--this should be an interface right?  Well hear me out
// All classes that inherit this type MUST also be ScriptableObjects in order for this system to work
// Therefore writing it this way guarantees that all Powerups are also ScriptableObjects
public abstract class Powerup : ScriptableObject {
    public abstract void use();
}
