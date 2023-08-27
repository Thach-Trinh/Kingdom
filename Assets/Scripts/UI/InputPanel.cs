using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class InputPanel : BasePopup
{
    public TMP_InputField nameField;
    public void Play()
    {
        string name = nameField.text;
        if (name == string.Empty) return;
        DatabaseController.Instance.data.name = name;
        SceneManager.LoadScene("Book");
    }
    public override void Hide()
    {
        nameField.text = string.Empty;
        base.Hide();
        //gameObject.SetActive(false);
        //darkScreen.SetActive(false);
    }
}
