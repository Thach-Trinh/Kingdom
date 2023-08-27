using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BasePopup : MonoBehaviour
{
    public float scaleDuration = 0.5f;
    public virtual void Show()
    {
        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);
        transform.DOScale(1, scaleDuration).SetUpdate(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

}
