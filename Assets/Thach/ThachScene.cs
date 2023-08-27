using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThachScene : MonoBehaviour
{
    public void StartLoadScene()
    {
        StartCoroutine(LoadScene());
    }
    private IEnumerator LoadScene()
    {
        Debug.Log("Start Load Scene");
        DontDestroyOnLoad(gameObject);
        AsyncOperation task = SceneManager.LoadSceneAsync("Village");
        Time.timeScale = 0;
        while (!task.isDone)
        {
            Debug.Log($"Frame {Time.frameCount} - progress {task.progress}");
            yield return null;
        }
        Debug.Log("Finish Load Scene");
        Time.timeScale = 1;
    }
    private void OnDestroy()
    {
        Debug.Log("Destroy on Load");
    }
}
