using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))]
public class PlayerController_SideScroll : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float fastSpeed = 8f; 
    public float airspeed = 3f;
    public float jumpImpulse = 10f;
    Vector2 moveInput;
    TouchingDirections touchingDirections;
    Damageable damageable;

    public float CurrMoveSpd 
    {   get
        {
            if(CanMove)
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
                else {return 0;} // idle spd = 0
            }
            else {return 0;} // can't move
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

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }



    Rigidbody2D rb;
    Animator animator;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();
    }

    private float timeSinceDeath = 0;
    public float GameOverTime = 5f;

    private void FixedUpdate() 
    {
        if(!damageable.LockVelocity)
        {
            rb.velocity = new Vector2(moveInput.x * CurrMoveSpd, rb.velocity.y);
        }
        
        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);

        if(!animator.GetBool(AnimationStrings.isAlive))
        {
            rb.velocity = Vector2.zero;
            timeSinceDeath = 0;
            while(timeSinceDeath < GameOverTime)
            {
                timeSinceDeath += Time.deltaTime;
                Debug.Log("Wait for: " + timeSinceDeath);
            }
            SceneManager.LoadScene("title screen");

            
        }


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(animator.GetBool(AnimationStrings.isAlive))
        {
            if(moveInput.x > 0 && !IsFacingRight) {IsFacingRight = true;}      // Right
            else if(moveInput.x < 0 && IsFacingRight) {IsFacingRight = false;} // Left
        }
    }

    public void OnFast(InputAction.CallbackContext context)
    {
        if(context.started) {IsFast = true;}
        else if(context.canceled){IsFast = false;}
    }

    public void OnJump(InputAction.CallbackContext context)
    {   //TODO: Check when alive
        if(context.started && touchingDirections.IsGrounded && CanMove) 
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
        }
    }

    public void OnHit(int damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }

}
