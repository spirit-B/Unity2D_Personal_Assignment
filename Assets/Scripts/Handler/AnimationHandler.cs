using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
    private static readonly int IsJumping = Animator.StringToHash("IsJump");

    protected Animator _animator;

    protected virtual void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        _animator.SetBool(IsMoving, obj.magnitude > .5f);
    }

    public void Jump(bool isJump)
    {
        _animator.SetBool(IsJumping, isJump);
    }

    public void Damage()
    {
        _animator.SetBool(IsDamage, true);
    }
}
