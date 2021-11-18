using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int maxLevel = 3;
    public GameObject levelPanel;
    public GameObject[] lockImages;
    public Button[] levelButtons;

    AudioSource audios;
    public AudioClip buttonSound;

    int openLevel = 1;

    void Start()
    {
        Application.targetFrameRate = 60;
        if (!PlayerPrefs.HasKey("OpenLevel"))
        {
            PlayerPrefs.SetInt("OpenLevel", openLevel);
        }
        else
        {
            openLevel = PlayerPrefs.GetInt("OpenLevel");
        }
        LevelUnlock();
        audios = GetComponent<AudioSource>();
    }

    public void OpenLevelPanel()
    {
        levelPanel.SetActive(true);
        PlaySound(buttonSound);
    }

    public void CloseLevelPanel()
    {
        levelPanel.SetActive(false);
        PlaySound(buttonSound);
    }

    void LevelUnlock()
    {
        if (openLevel > 1)
        {
            if (openLevel == maxLevel) maxLevel++;
            for(int i = 1; i < maxLevel-1; i++)
            {
                lockImages[i - 1].SetActive(false);
                levelButtons[i - 1].interactable = true;
            }
        }
    }

    public void LevelStart(int levelNumber)
    {
        PlaySound(buttonSound);
        SceneManager.LoadScene("Level_" + levelNumber);
    }

    public void DeleteKeys()
    {
        PlayerPrefs.DeleteKey("OpenLevel");
    }

    public void PlaySound(AudioClip ac)
    {
        audios.PlayOneShot(ac);
    }

}
