using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public int MoveSpeed;
    public float climbSpeed = 3f;
    public Joystick joystick;

    Animator animator;
    Rigidbody2D rb;

    int MoveX;
    float MoveY;
    private float scaleX = 1f;

    public bool isGround;
    public bool isNearLadder = false;
    public bool isClimbing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        MoveX = Mathf.RoundToInt(joystick.Horizontal);
        MoveY = Mathf.RoundToInt(joystick.Vertical);


        if (isNearLadder && Mathf.Abs(MoveY) > 0.3f)
        {
            StartClimbing();
        }

        else if (isClimbing && Mathf.Abs(MoveY) == 0)
        {

            rb.velocity = Vector2.zero;
            animator.SetInteger("PlayerMode", 3);
        }
        else if (isClimbing && !isNearLadder)
        {

            StopClimbing();
        }


        if (!isClimbing)
        {
            Move();
        }
        else
        {
            LadderMovement();
        }
    }



    void Move()
    {
        rb.gravityScale = 3f;

        if (isGround)
        {
            if (MoveX > 0.3f)
            {
                rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                animator.SetInteger("PlayerMode", 1);
            }
            else if (MoveX < -0.3f)
            {
                rb.velocity = new Vector2(-MoveSpeed, rb.velocity.y);
                transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
                animator.SetInteger("PlayerMode", 1);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                animator.SetInteger("PlayerMode", 0);
            }
        }
    }



    // ======================
    //   فعال‌سازی حالت نردبان
    // ======================
    void StartClimbing()
    {
        isClimbing = true;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, 0);
    }

    // ======================
    //   حرکت روی نردبان
    // ======================
    void LadderMovement()
    {


        if (Mathf.Abs(MoveY) > 0.1f)
        {
            rb.velocity = new Vector2(0, MoveY * climbSpeed);
            animator.SetInteger("PlayerMode", 2); // انیمیشن بالا رفتن
        }

        else if (Mathf.Abs(MoveY) < -0.1f)
        {
            rb.velocity = new Vector2(0, MoveY * -climbSpeed);
            animator.SetInteger("PlayerMode", 2);
        }

    }


    // ======================
    // خروج از حالت نردبان
    // ======================
    void StopClimbing()
    {
        isClimbing = false;
        rb.gravityScale = 3f;
    }


    // ======================
    //    تریگر نردبان
    // ======================
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isNearLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isNearLadder = false;
            StopClimbing();
        }
    }


    // ======================
    //  تشخیص زمین
    // ======================
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gnd"))
        {
            isGround = true;
            isClimbing = false;

        }
    }



    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gnd"))
        {
            isGround = false;
        }
    }
}
