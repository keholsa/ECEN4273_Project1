using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    Rigidbody2D rb;

    Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
    }

    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if(!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));

                if(!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));


                }
            }
            else{
                animator.SetInteger("isMoving", 0);
            }
        }

        //Direction for animations
        if      (movementInput.x < 0 && movementInput.y == 0){animator.SetInteger("isMoving", 1);} // Left
        else if (movementInput.x > 0 && movementInput.y == 0){animator.SetInteger("isMoving", 3);} // Right
        else if (movementInput.y < 0 && movementInput.x == 0){animator.SetInteger("isMoving", 4);} // Down
        else if (movementInput.y > 0 && movementInput.x == 0){animator.SetInteger("isMoving", 2);} // Up
        else if (movementInput.x < 0 && movementInput.y < 0){animator.SetInteger("isMoving", 4);}
        else if (movementInput.x > 0 && movementInput.y < 0){animator.SetInteger("isMoving", 4);}
        else if (movementInput.x < 0 && movementInput.y > 0){animator.SetInteger("isMoving", 2);}
        else if (movementInput.x > 0 && movementInput.y > 0){animator.SetInteger("isMoving", 2);}
        else    {animator.SetInteger("isMoving", 0);}
    }

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);
            
        if(count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else return false;
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
