using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))]
public class ShadowBoss : MonoBehaviour
{
    Animator animator;
    public float walkSpeed = 2f;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance = 1000f;
    private float moving;

    Rigidbody2D rb;
    TouchingDirections touchingDirections;
    Damageable damageable;

    public enum WalkableDirection {Right, Left}

    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector = Vector2.right;

    public WalkableDirection WalkDirection
    {
        get {return _walkDirection;}
        set
        {
            if(_walkDirection != value)
            {
                // Flip
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                }
                else if(value == WalkableDirection.Left)
                {
                    walkDirectionVector = Vector2.left;
                }

                
            }
            _walkDirection = value;
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();
    }

    private void FixedUpdate()
    {
        if(animator.GetBool(AnimationStrings.isAlive))
        {
            if(touchingDirections.IsGrounded && touchingDirections.IsOnWall)
            {
                FlipDirection();
            }

            if(!damageable.LockVelocity)
            {
                if (isChasing)
                {
                    moving = 1f;
                    if(transform.position.x > playerTransform.position.x && transform.position.x - playerTransform.position.x > 0.1f)
                    {
                        WalkDirection = WalkableDirection.Left;
                    }
                    else if (transform.position.x < playerTransform.position.x && playerTransform.position.x - transform.position.x > 0.1f)
                    {
                        WalkDirection = WalkableDirection.Right;
                    }

                }
                else
                {
                    if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
                    {
                        isChasing = true;
                    }
                    moving = 0f;
                }
                rb.velocity = new Vector2(walkSpeed * walkDirectionVector.x * moving, rb.velocity.y);
            }
            
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        
    }

    private void FlipDirection()
    {
        if(WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        else if(WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }
        else
        {
            Debug.LogError("WalkDirection is not set to Left or Right");
        }
    }

    public void OnHit(int damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }


}
