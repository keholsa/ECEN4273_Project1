using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; //temprary
public class Damageable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damageableHit;

    Animator animator;

    [SerializeField]
    private int _maxHealth = 3;

    public int MaxHeath
    {
        get {return _maxHealth;}
        set {_maxHealth = value;}
    }

    [SerializeField]
    private int _health = 3; //Current Health

    public int Health
    {
        get {return _health;}
        set 
        {
            _health = value;
            if(_health <= 0)
            {
                IsAlive = false; // Die
                // temporary sceene change
                Invoke("loaddev", 3);
            }
        }
    }
    void loaddev()
    {
        SceneManager.LoadScene("DEV_SCEENE");
    }

    [SerializeField]
    private bool _isAlive = true;

    [SerializeField]
    private bool isInvincible = false;



    private float timeSinceHit = 0;
    public float invincibleTime = 0.25f;

    public bool IsAlive
    {
        get {return _isAlive;}
        set 
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive: " + value);
        }
    }

    public bool LockVelocity 
    { 
        get{return animator.GetBool(AnimationStrings.lockVelocity);}
        set{animator.SetBool(AnimationStrings.lockVelocity, value);}
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(isInvincible)
        {
            if(timeSinceHit > invincibleTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
            
            timeSinceHit += Time.deltaTime;
        }
    }
   
    public void Hit(int damage, Vector2 knockback)
    {
        if(IsAlive && !isInvincible)
        {
            Health -= damage;
            //LockVelocity = true;
            isInvincible = true;

            animator.SetTrigger(AnimationStrings.hitTrigger);
            damageableHit?.Invoke(damage, knockback);

        }
    }

}
