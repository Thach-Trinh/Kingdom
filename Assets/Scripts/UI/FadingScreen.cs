using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadingScreen : MonoBehaviour
{
    public Image image;
    public float duration = 1f;
    public void Fade()
    {
        image.DOFade(1, duration).SetLoops(2, LoopType.Yoyo);
    }
}
