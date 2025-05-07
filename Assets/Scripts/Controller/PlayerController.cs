using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private GameManager gameManager;
    private IInputStrategy inputStrategy;
    private Camera _camera;

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.inputStrategy = gameManager.InputStrategy;
        _camera = Camera.main;
    }

    //private void Update()
    //{
    //    if (inputStrategy == null) return;

    //    movementDirection = inputStrategy.GetMovementInput();
    //    movementDirection = movementDirection.normalized;

    //    if (inputStrategy.IsJumpPressed())
    //        Jump();
    //}

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnJump()
    {
        Jump();
    }
}
