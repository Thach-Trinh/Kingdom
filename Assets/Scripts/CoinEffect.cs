using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CoinEffect : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public float duration;
    public TMP_Text text;
    public Image image;
    public void Perform(int coin, Vector3 startPosition)
    {
        text.text = $"{coin}";
        text.DOFade(0, duration);
        image.DOFade(0, duration);
        transform.position = Vector3.up * minHeight + startPosition;
        transform.DOMoveY(startPosition.y + maxHeight, duration).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
