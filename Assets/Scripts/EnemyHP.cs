using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int enemyHitPoint;
    public int scoreForEnemy = 5;
    int currentHitPoint;
    Animator anim;
    Rigidbody2D rb;

    void Start()
    {
        currentHitPoint = enemyHitPoint;
        anim = transform.parent.GetComponent<Animator>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        if (currentHitPoint == 1)
        {
            anim.SetBool("hit", true);
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = Vector2.up * 10f;
            rb.gravityScale = 2;
            transform.parent.gameObject.GetComponent<Enemy>().enabled = false;
            this.gameObject.layer = 8;
            transform.parent.gameObject.layer = 8;
        }
        else
        {
            anim.SetBool("hit", true);
            Invoke("OffHitAnimation", 0.5f);
        }
        currentHitPoint -= damage;
        if (currentHitPoint <= 0)
        {
            GameManager.GM.AddScore(scoreForEnemy);
            Invoke("DestroyEnemy", 3f);
        }
    }

    private void OffHitAnimation()
    {
        anim.SetBool("hit", false);
    }

    private void DestroyEnemy()
    {
        Destroy(transform.parent.gameObject);
    }
}
