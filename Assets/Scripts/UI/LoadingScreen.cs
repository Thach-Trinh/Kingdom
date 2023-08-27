using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum SceneTheme
{
    Village,
    Town,
    Forest,
    Capital,
    Kingdom
}

[System.Serializable]
public class SceneData
{
    public SceneTheme theme;
    public Sprite background;
}

[System.Serializable]
public class LoadingProcessBar
{
    public RectTransform mask;
    private float originalWidth;
    public void SetZeroProgress()
    {
        originalWidth = mask.sizeDelta.x;
        //Vector2 newSizeDelta = mask.sizeDelta;
        //newSizeDelta.x = 0;
        //mask.sizeDelta = newSizeDelta;
    }
    public void UpdateProgress(float progress)
    {
        Vector2 newSizeDelta = mask.sizeDelta;
        newSizeDelta.x = originalWidth * progress;
        mask.sizeDelta = newSizeDelta;
    }
}

public class LoadingScreen : MonoBehaviour
{
    
    public static LoadingScreen Instance;
    //public float sceneActivatonThresold;
    public float fakeLoadingDuration;
    public Sprite[] themeSprites;
    public LoadingProcessBar processBar;
    //public SceneData[] scenes;
    public Image background;
    public AudioSource audi;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
        processBar.SetZeroProgress();
    }

    public void LoadScene(SceneTheme theme)
    {
        background.sprite = themeSprites[(int)theme];
        gameObject.SetActive(true);
        audi.Play();
        StartCoroutine(AsyncLoading(theme));
    }

    private IEnumerator AsyncLoading(SceneTheme theme)
    {
        //Time.timeScale = 0;
        AsyncOperation task = SceneManager.LoadSceneAsync(theme.ToString());
        //task.allowSceneActivation = false;
        float startTime = Time.time;
        float fakeProgress = 0;

        while (!task.isDone || fakeProgress < 0.9f)
        {
            float normalizedTime = (Time.time - startTime) / fakeLoadingDuration;
            fakeProgress = Mathf.Min(task.progress, normalizedTime);
            processBar.UpdateProgress(fakeProgress);
            yield return null;
        }
        //task.allowSceneActivation = true;
        audi.Stop();
        gameObject.SetActive(false);
        //Time.timeScale = 1;
    }
}
