using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStrategy : IInputStrategy
{
    public Vector2 GetMovementInput()
    {
        return Vector3.zero;
    }

    public bool IsJumpPressed()
    {
        return Input.GetMouseButtonDown(0);
    }
}
