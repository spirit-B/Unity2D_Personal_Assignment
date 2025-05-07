using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDStrategy : IInputStrategy
{
    public Vector2 GetMovementInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public bool IsJumpPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
