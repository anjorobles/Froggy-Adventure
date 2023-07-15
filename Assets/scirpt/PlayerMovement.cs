using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    private float dX = 0f;
    private bool doubleJump;
    private int jumpcount;

    private MovementState state; 
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource walkingSoundEffect;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

   private enum MovementState {idle, running, jump, fall, doublejump}

    // Start is called before the first frame update
   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dX * moveSpeed, rb.velocity.y);

        // for jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // for double jumping
            if (!IsGrounded() && jumpcount < 2)
            {
                if (jumpcount == 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
                else
                {
                    jumpSoundEffect.Play();
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce * 1.3f);
                }

                jumpcount++;
                doubleJump = true;
            }
            // for single jump
            else if (IsGrounded())
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpcount = 1;
            }
        }

        animationUpdate(jumpcount, doubleJump);
    }


    private void animationUpdate(int jumpcount, bool doubleJump)
    {
     

         if (dX > 0f)
        {
            walkingSoundEffect.enabled = true;
            state = MovementState.running;
            sprite.flipX = false;
            
        }
        else if (dX < 0f)
        {
            walkingSoundEffect.enabled = true;
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
            walkingSoundEffect.enabled = false;
        }


        if (rb.velocity.y >.1f) 
        {
            if (jumpcount == 1 )
            {
                walkingSoundEffect.enabled = false;
                state = MovementState.jump;
            }
            else if (jumpcount == 2 )
            {
                walkingSoundEffect.enabled = false;
                state = MovementState.doublejump;
            }

        }
        else if (rb.velocity.y < -.1f )
        {
            walkingSoundEffect.enabled = false;
            state = MovementState.fall;
        }

        anim.SetInteger("state",(int)state);
        
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
