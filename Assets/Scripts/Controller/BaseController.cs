using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer charactorRenderer;
    [SerializeField] private Transform visualTransform;

    protected Vector2 movementDirection = Vector2.zero;
    protected Vector2 lookDirection = Vector2.zero;
    protected Vector2 charactorInitLocalPosition;
    public Vector2 MovementDirection { get { return movementDirection; } }
    public Vector2 LookDirection { get { return lookDirection; } }

    protected AnimationHandler animationHandler;
    protected StatHandler statHandler;

    protected bool isJump = false;
    public bool IsJump { get { return isJump; } }

    private bool isLeft;
    private float jumpVelocity = 0f;
    private float jumpHeight = 0f;
    private const float gravity = 25f;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
    }

    protected virtual void Start()
    {
        charactorInitLocalPosition = visualTransform.position;
    }

    protected virtual void FixedUpdate()
    {
        Rotate(movementDirection);
        Movement(movementDirection);
        HandleJump();
    }

    private void Movement(Vector2 dir)
    {
        dir = dir * statHandler.Speed;

        _rigidbody.velocity = dir;
        animationHandler.Move(dir);
    }

    protected void Jump()
    {
        if (jumpHeight <= 0f)
        {
            isJump = true;
        }
    }
    private void HandleJump()
    {

        if (isJump)
        {
            jumpVelocity = statHandler.Jump;
            isJump = false;
        }

        jumpVelocity -= gravity * Time.fixedDeltaTime;
        jumpHeight += jumpVelocity * Time.fixedDeltaTime;

        if (jumpHeight < 0f)
        {
            jumpHeight = 0f;
            jumpVelocity = 0f;
        }

        if (visualTransform != null)
        {
            Vector2 pos = visualTransform.localPosition;
            pos.y = charactorInitLocalPosition.y + jumpHeight;
            visualTransform.localPosition = pos;
        }

        animationHandler.Jump(jumpHeight > 0f);
    }

    private void Rotate(Vector2 dir)
    {
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // 마우스로 좌우 반전이 필요할때만 적용
        //bool isLeft = Mathf.Abs(rotZ) > 90f;
        if (Input.GetKey("d"))
            isLeft = false;
        else if (Input.GetKey("a"))
            isLeft = true;

        charactorRenderer.flipX = isLeft;
    }
}
