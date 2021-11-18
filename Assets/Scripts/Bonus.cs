using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum bonusFruits
{
    timeApple,
    lifeStrawberry,
    shieldCherry,
}

public class Bonus : MonoBehaviour
{
    public bonusFruits fruit;
    public GameObject effect;

    [Header("Для щита")]
    public float shieldDelay;
    public GameObject shield;

    [Header("Для времени")]
    public int timeToAdd = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ActivateBonus(collision.gameObject);
            GameObject go = Instantiate(effect);
            go.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    private void ActivateBonus(GameObject player)
    {
        switch (fruit)
        {
            case bonusFruits.timeApple:
                GameManager.GM.AddTime(timeToAdd);
                break;
            case bonusFruits.lifeStrawberry:
                player.GetComponent<PlayerHealth>().AddHealth(1);
                break;
            case bonusFruits.shieldCherry:
                player.GetComponent<PlayerHealth>().ActivateShield(shieldDelay, shield);
                break;
        }
    }
}
