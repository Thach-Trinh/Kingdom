using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public AudioSource clickSound;
    public GameObject cover;
    public BasePopup pausePanel;
    public SettingPanel settingPanel;
    public BasePopup yesNoPanel;

    //public float timeScale;
    public void OpenPausePanel()
    {
        clickSound.Play();
        MonoUtility.Instance.cursor.ChangeState(new CursorPauseState());
        cover.SetActive(true);
        pausePanel.Show();
        Time.timeScale = 0;
    }

    public void ClosePausePanel()
    {
        clickSound.Play();
        MonoUtility.Instance.cursor.ChangeState(new CursorGameState());
        cover.SetActive(false);
        Time.timeScale = 1;
        pausePanel.Hide();
    }

    public void OpenSettingPanel()
    {
        clickSound.Play();
        pausePanel.Hide();
        settingPanel.Show();
    }

    public void CloseSettingPanel()
    {
        clickSound.Play();
        pausePanel.Show();
        settingPanel.Hide();
    }

    public void OpenYesNoPanel()
    {
        clickSound.Play();
        pausePanel.Hide();
        yesNoPanel.Show();
    }

    public void CloseYesNoPanel()
    {
        clickSound.Play();
        pausePanel.Show();
        yesNoPanel.Hide();
    }

    public void BackToMainMenu()
    {
        clickSound.Play();
        Destroy(DatabaseController.Instance.gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
