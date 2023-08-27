using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinBar : MonoBehaviour
{
    public TMP_Text text;
    
    private void Start()
    {
        MonoUtility.Instance.coin.onCoinChanged += StartAnimation;
        UpdateCoin(DatabaseController.Instance.data.coin);
    }

    public void UpdateCoin(int coin)
    {
        text.text = $"{coin}";
    }

    private void StartAnimation(int oldCoin, int newCoin)
    {
        StartCoroutine(PlayCoinTextAnimation(oldCoin, newCoin));
    }

    private IEnumerator PlayCoinTextAnimation(int oldCoin, int newCoin)
    {
        int increment = newCoin >= oldCoin ? 1 : -1;
        int currentCoin = oldCoin;
        while (currentCoin != newCoin)
        {
            currentCoin += increment;
            text.text = $"{currentCoin}";
            yield return null;
        }
    }

}
