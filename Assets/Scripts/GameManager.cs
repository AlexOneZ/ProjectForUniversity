using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    [Header("Появление игрока")]
    public GameObject spawnPlayer;
    public GameObject activePlayer;
    public Transform spawnPosition;
    private PlayerMoovement pm;

    [Header("Для расчета очков")]
    public Text scoreText;
    private int totalScore = 0;

    [Header("Время игры")]
    public int timeToEnd = 100;
    public Text timeText;

    [Header("Мобильное управление")]
    public GameObject mobileInput;

    public int Score
    {
        get { return totalScore; }
    }

    void Awake()
    {
        GM = GetComponent<GameManager>();
        activePlayer = Instantiate(spawnPlayer);
        activePlayer.transform.position = spawnPosition.position;
        pm = activePlayer.GetComponent<PlayerMoovement>();
#if UNITY_IOS || UNITY_ANDROID
        mobileInput.SetActive(true);
#endif
    }

    private void Start()
    {
        AddScore(0);
        StartCoroutine(LevelTime(timeToEnd));
    }

    public void AddScore(int score)
    {
        pm.PlaySound(pm.fruitSound);
        totalScore += score;
        scoreText.text = "ОЧКИ:" + totalScore.ToString();
    }

    private IEnumerator LevelTime(int end)
    {
        for (int i = timeToEnd; i > 0; i--)
        {
            timeToEnd--;
            if (timeToEnd <= 30) timeText.color = Color.red;
            timeText.text = (timeToEnd / 60).ToString() + ": " + (timeToEnd % 60).ToString();
            if (timeToEnd <= 0)
            {
                activePlayer.GetComponent<PlayerHealth>().TakeDamage(3);
                StopAllCoroutines();
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void AddTime(int timeToAdd)
    {
        timeToEnd += timeToAdd;
        pm.PlaySound(pm.bonusSound);
        if (timeToEnd > 30) timeText.color = Color.white;
        timeText.text = (timeToEnd / 60).ToString() + ": " + (timeToEnd % 60).ToString();
    }
}
