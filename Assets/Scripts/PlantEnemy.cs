using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : Enemy
{
    [Header("Для установки в инспекторе: Plant")]
    public Transform shootPoint;
    public GameObject projectile;
    public float distance = 10f, delayBetweenAttack;
    Transform player, plant;
    bool right = true;
    float startAtackTime = 0f;
    Animator anim;

    private void Start()
    {
        player = GameManager.GM.activePlayer.transform;
        plant = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    public override void Moove()
    {
        //base.Moove();
        if (player.transform.position.x < plant.transform.position.x)
        {
            if (!right) Flip();
            if (plant.position.x - player.position.x < distance) Attack();
        }
        else if (player.transform.position.x > plant.transform.position.x)
        {
            if (right) Flip();
            if (Mathf.Abs(plant.position.x - player.position.x) < distance) Attack();
        }
    }

    public override void Flip()
    {
        right = !right;
        plant.Rotate(0f, 180f, 0f);
    }

    private void Attack()
    {
        if (startAtackTime + delayBetweenAttack < Time.time)
        {
            anim.SetBool("attack", true);
            Invoke("StopAttackAnimation", delayBetweenAttack - 1f);
            //print(startAtackTime);
            //print(Mathf.Abs(player.transform.position.x) - Mathf.Abs(plant.position.x));
            startAtackTime = Time.time;
            GameObject go = Instantiate(projectile);
            go.transform.position = shootPoint.position;
            if (right)
            {
                Projectile pgl = go.GetComponent<Projectile>();
                pgl.speed = -pgl.speed;
            }
        }
    }
    private void StopAttackAnimation()
    {
        anim.SetBool("attack", false);
    }
}
