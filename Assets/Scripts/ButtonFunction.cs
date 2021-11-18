using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public GameObject pausePanel;

    AudioSource audios;
    public AudioClip buttonSound, pauseSound;

#if UNITY_STANDALONE_OSX || UNITY_STANDALONE
    bool isPause = false;
    private void Update()
    {
        if (!isPause && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            isPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
            isPause = false;
        }
    }
#endif
    private void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    public void Restart()
    {
        PlaySound(buttonSound);
        TimeNormilize();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume()
    {
        TimeNormilize();
        PlaySound(pauseSound);
        pausePanel.SetActive(false);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        PlaySound(buttonSound);
        TimeNormilize();
    }

    public void MainMenu()
    {
        PlaySound(buttonSound);
        TimeNormilize();
        SceneManager.LoadScene("MainMenu");
    }

    void TimeNormilize()
    {
        Time.timeScale = 1f;
    }

    public void PlaySound(AudioClip ac)
    {
        audios.PlayOneShot(ac);
    }
}
