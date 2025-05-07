using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputStrategy
{
    Vector2 GetMovementInput();
    bool IsJumpPressed();
}

