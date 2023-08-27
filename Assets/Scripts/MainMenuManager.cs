using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public InputPanel inputPanel;
    public GameObject darkScreen;
    public void ClickPlayButton()
    {
        darkScreen.SetActive(true);
        inputPanel.Show();
    }
    public void ClickSettingButton() { }
    public void ClickQuitButton() => Application.Quit();
}
