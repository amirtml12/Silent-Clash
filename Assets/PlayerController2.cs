
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    public static PlayerController2 instance;
    public int MoveSpeed;
    public float climbSpeed = 3f;
    public Joystick joystick;

    Animator animator;
    Rigidbody2D rb;

    float MoveX;
    float MoveY;
    private float scaleX = 1f;

    public bool isGround;
    public bool isNearLadder = false;
    public bool isClimbing = false;
    bool isBusy = false;
    public Slider slider;

     void Awake()
    {
        instance = this;
    }
    void Start()
    {

        slider.minValue = 0;
        slider.maxValue = 20;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }


    void Update()
    {

        joystick = FindObjectOfType<Joystick>();
        MoveX = joystick.Horizontal;
        MoveY = joystick.Vertical;


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

        if (slider.value <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }



    void Move()
    {
        if (isBusy) return;
        rb.gravityScale = 3f;

        if (isGround)
        {
            if (MoveX > 0)
            {
                rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                animator.SetInteger("PlayerMode", 1);
            }
            else if (MoveX < 0)
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




    void StartClimbing()
    {
        isClimbing = true;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, 0);
    }

    void LadderMovement()
    {


        if (Mathf.Abs(MoveY) > 0.1f)
        {
            rb.velocity = new Vector2(0, MoveY * climbSpeed);
            animator.SetInteger("PlayerMode", 2);
        }

        else if (Mathf.Abs(MoveY) < -0.1f)
        {
            rb.velocity = new Vector2(0, MoveY * -climbSpeed);
            animator.SetInteger("PlayerMode", 2);
        }

    }


    void StopClimbing()
    {
        isClimbing = false;
        rb.gravityScale = 3f;
    }


    public void PickUp()
    {

        StartCoroutine(AfterPickUp());
    }

    IEnumerator AfterPickUp()
    {
        isBusy = true;
        animator.SetInteger("PlayerMode", 4);
        yield return new WaitForSeconds(0.5f);
        animator.SetInteger("PlayerMode", 0);
        isBusy = false;
    }




    public void TakeDamage(int dmg)
    {
        slider.value -= dmg;

        if (slider.value <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over");
        Destroy(gameObject);
    }



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
