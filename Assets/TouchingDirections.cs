using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    public float wallDistance = 0.001f;
    public float ceilingDistance = 0.05f;

    CapsuleCollider2D touchingCollider;
    Animator animator;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    Rigidbody2D rb;

    [SerializeField]
    private bool _isGrounded = true;
    public bool IsGrounded 
    { 
        get
        {
            return _isGrounded;
        } 
        private set
        {
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        } 
    }

    [SerializeField]
    private bool _isOnWall = true;
    public bool IsOnWall 
    { 
        get
        {
            return _isOnWall;
        } 
        private set
        {
            _isOnWall = value;
            animator.SetBool(AnimationStrings.isOnWall, value);
        } 
    }

    [SerializeField]
    private bool _isOnCeling = true;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    public bool IsOnCeiling
    { 
        get
        {
            return _isOnCeling;
        } 
        private set
        {
            _isOnCeling = value;
            animator.SetBool(AnimationStrings.isOnCeiling, value);
        } 
    }

    private void Awake()
    {
        touchingCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = touchingCollider.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        IsOnWall = touchingCollider.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingCollider.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
        
    }
}
