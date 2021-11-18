using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    public float force;
    public bool isVertical = true, isLeft = true;
    Vector2 startPos;
    Transform player, head;
    bool detect = false;
    Rigidbody2D rb;
    Animator anim;
    bool isGround = false;

    private void Start()
    {
        player = GameManager.GM.activePlayer.transform;
        head = this.transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (detect)
        {
            if (isVertical)
            {
                if (isLeft)
                {
                    rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
                    //isLeft = false;
                    anim.SetBool("hit", true);
                }
                else
                {
                    rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                    //isLeft = true;
                    anim.SetBool("hit", true);
                }
            }
            else
            {
                if (isLeft)
                {
                    rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);
                    //isLeft = false;
                    anim.SetBool("hit", true);
                }
                else
                {
                    rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
                    //isLeft = true;
                    anim.SetBool("hit", true);
                }
            }
        }
        /*isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if(isGround)
        {
            groundCheck.Rotate(180f, 0f, 0f);
            isLeft = !isLeft;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detect = true;
            tag = "dethzone";
            anim.SetFloat("Blend", 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (isVertical)
            {
                if (isLeft)
                {
                    anim.SetFloat("Blend", 0.23f);
                }
                else
                {
                    anim.SetFloat("Blend", 0.45f);
                }
            }
            else
            {
                if (isLeft)
                {
                    anim.SetFloat("Blend", 0.85f);
                }
                else
                {
                    anim.SetFloat("Blend", 0.95f);
                }
            }
            print("colllision");
            anim.SetBool("hit", false);
            isLeft = !isLeft;
            detect = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            detect = false;
            tag = "Traps";
            anim.SetFloat("Blend", 0f);
        }
    }
}
