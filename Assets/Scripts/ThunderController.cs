using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThunderController : MonoBehaviour
{
    public float duration = 1f;
    public float delay = 5f;
    public Image brightness;
    public AudioSource audi;
    public AudioClip[] soundTracks;
    private void Start()
    {
        PlayThunder(0);
    }

    private void PlayThunder()
    {
        int index = Random.Range(0, soundTracks.Length);
        PlayThunder(index);
    }

    private void PlayThunder(int index)
    {
        StartCoroutine(PerformThunder(index));
        Invoke(nameof(PlayThunder), delay + soundTracks[index].length);
    }

    private IEnumerator PerformThunder(int index)
    {
        audi.PlayOneShot(soundTracks.GetRandomElement());
        float leftTime = duration;
        do
        {
            Color newColor = brightness.color;
            newColor.a = leftTime / duration;
            brightness.color = newColor;
            leftTime -= Time.deltaTime;
            yield return null;
        } while (leftTime > 0);
    }
}
