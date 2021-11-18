using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    public int damageToDeal = 1;
    public float bounceForce = 10f;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        anim = transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "HurtBox")
        {
            if (collision.gameObject.GetComponent<EnemyHP>() != null)
            {
                collision.gameObject.GetComponent<EnemyHP>().TakeDamage(damageToDeal);
            }
            else
            {
                collision.gameObject.GetComponent<EnemyHPRock>().TakeDamage(damageToDeal);
            }
            PlayerMoovement pm = transform.parent.gameObject.GetComponent<PlayerMoovement>();
            pm.PlaySound(pm.enemeyDamageSound);
            rb.velocity = Vector2.up * bounceForce;
            anim.SetBool("isJump", true);
        }
    }
}
