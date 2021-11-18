using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int nextLevelNumber = 2;
    public float slowTime = 0.7f;
    public GameObject finishPanel;
    public Text totalScore;
    int openLevel = 0;
    public GameObject endEffect;
    bool endLevel = false;

    public ButtonFunction bf;

    private void Start()
    {
        openLevel = PlayerPrefs.GetInt("OpenLevel");
    }

    public void EndLevel()
    {
        finishPanel.SetActive(true);

        totalScore.text = "ТЫ НАБРАЛ: " + GameManager.GM.Score.ToString() + " ОЧКОВ";

        Time.timeScale = slowTime;

        //openLevel = PlayerPrefs.GetInt("OpenLevel");
        if (openLevel < nextLevelNumber)
        {
            openLevel++;
            PlayerPrefs.SetInt("OpenLevel", nextLevelNumber);
            print("Save: " + nextLevelNumber);
        }
    }

    public void GoNextLevel()
    {
        bf.PlaySound(bf.buttonSound);
        Time.timeScale = 1f;
        if(nextLevelNumber == 0) SceneManager.LoadScene(nextLevelNumber);
        else SceneManager.LoadScene("Level_" + nextLevelNumber);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!endLevel)
            {
                EndLevel();
                PlayerMoovement pm = collision.gameObject.GetComponent<PlayerMoovement>();
                pm.PlaySound(pm.finishSound);
                GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0f);
                GameObject go = Instantiate(endEffect);
                go.transform.position = this.transform.position;
            }
        }
    }
}
