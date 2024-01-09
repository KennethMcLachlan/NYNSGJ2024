using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;

public abstract class InputController : ScriptableObject
{
    public abstract float RetrieveMoveInput();
    public abstract bool RetrieveJumpInput();
}
