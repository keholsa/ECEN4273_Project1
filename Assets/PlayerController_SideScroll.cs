using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController_SideScroll : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float fastSpeed = 8f; 
    public float airspeed = 3f;
    public float jumpImpulse = 10f;
    Vector2 moveInput;
    TouchingDirections touchingDirections;

    public float CurrMoveSpd 
    {   get
        {
            if(IsMoving && !touchingDirections.IsOnWall)
            {
                if(touchingDirections.IsGrounded)
                {
                    if(IsFast) {return fastSpeed;}
                    else {return walkSpeed;}
                }
                else {return airspeed;}
            }
            else {return 0;}
        }
    }

    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving 
    { 
        get {return _isMoving;} 
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        } 
    }

    [SerializeField]
    private bool _isFast = false;
    public bool IsFast
    {
        get{return _isFast;}
        set
        {
            _isFast = value;
            animator.SetBool(AnimationStrings.isFast, value);
        }
    }

    public bool _isFacingRight = true;
    public bool IsFacingRight 
    { 
        get {return _isFacingRight;} 
        private set
        {
            if(_isFacingRight != value)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); // Flip
            }
            _isFacingRight = value;
        } 
    }

    Rigidbody2D rb;
    Animator animator;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(moveInput.x * CurrMoveSpd, rb.velocity.y);
        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight) {IsFacingRight = true;}      // Right
        else if(moveInput.x < 0 && IsFacingRight) {IsFacingRight = false;} // Left
    }

    public void OnFast(InputAction.CallbackContext context)
    {
        if(context.started) {IsFast = true;}
        else if(context.canceled){IsFast = false;}
    }

    public void OnJump(InputAction.CallbackContext context)
    {   //TODO: Check when alive
        if(context.started && touchingDirections.IsGrounded) 
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }
}
