using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Для установки в инспекторе: Enemy")]
    public float speed = 10f;
    public int damage = 1;
    public LayerMask whatIsWall;
    public Transform wallCheck;
    public float checkRadius = 0.125f;
    public bool wallIsDown = false;
    public bool isRight = true;
    bool isWall;
    Transform enemyTransform;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyTransform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Moove();
    }

    public virtual void Moove()
    {
        isWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius, whatIsWall);
        if (isWall && !wallIsDown)
        {
            Flip();
        }
        else if(!isWall && wallIsDown)
        {
            Flip();
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public virtual void Flip()
    {
        isRight = !isRight;
        speed = -speed;
        enemyTransform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
