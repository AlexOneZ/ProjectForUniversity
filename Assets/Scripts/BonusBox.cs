using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBox : MonoBehaviour
{
    public GameObject effect;
    public GameObject lifeBonus, shieldBonus, timeBonus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HurtBox")
        {
            BonusSpawn(effect);
            PlayerMoovement pm = collision.gameObject.transform.parent.gameObject.GetComponent<PlayerMoovement>();
            pm.PlaySound(pm.bonusSound);
            collision.gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.up * 14f;
            collision.gameObject.transform.parent.GetComponent<Animator>().SetBool("isJump", true);
            BonusGenerate();
            Destroy(gameObject);
        }
    }

    private void BonusGenerate()
    {
        float chance = Random.value;
        if (chance <= 0.25f)
        {
            BonusSpawn(timeBonus);
        }
        else if (chance <= 0.625)
        {
            BonusSpawn(lifeBonus);
        }
        else
        {
            BonusSpawn(shieldBonus);
        }
    }
    private void BonusSpawn(GameObject go)
    {
        GameObject goN = Instantiate(go);
        goN.transform.position = transform.position;
    }
}
