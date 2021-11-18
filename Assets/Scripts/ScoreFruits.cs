using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFruits : MonoBehaviour
{
    public int score;
    public GameObject collectEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GM.AddScore(score);
            GameObject go = Instantiate(collectEffect);
            go.transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
