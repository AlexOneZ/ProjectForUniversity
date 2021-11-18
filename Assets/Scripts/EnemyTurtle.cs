using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurtle : Enemy
{
    [Header("Для установки в инспекторе: Turtle")]
    public float offSpikesDelay;
    public float onSpikesDelay;
    public GameObject hurtBox;
    Transform player, turtle;
    Animator anim;

    private void Start()
    {
        player = GameManager.GM.activePlayer.transform;
        turtle = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        Attack();
    }

    public override void Moove()
    {
        //base.Moove();
        if (player.transform.position.x < turtle.transform.position.x)
        {
            if (!isRight) Flip();
        }
        else if (player.transform.position.x > turtle.transform.position.x)
        {
            if (isRight) Flip();
        }
    }

    private void Attack()
    {
        anim.SetBool("spikes", true);
        hurtBox.SetActive(false);
        Invoke("OffSpikes", offSpikesDelay);
    }

    private void OffSpikes()
    {
        anim.SetBool("spikes", false);
        hurtBox.SetActive(true);
        Invoke("Attack", onSpikesDelay);
    }

    public override void Flip()
    {
        isRight = !isRight;
        turtle.Rotate(0f, 180f, 0f);
    }
}
