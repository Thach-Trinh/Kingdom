using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinManager : MonoBehaviour
{
    public CoinEffect coinEffect;
    public AudioSource audi;
    public Action<int, int> onCoinChanged;
    public void AddCoin(int coin)
    {
        int oldCoin = DatabaseController.Instance.data.coin;
        int newCoin = oldCoin + coin;
        DatabaseController.Instance.data.coin = newCoin;
        onCoinChanged.Invoke(oldCoin, newCoin);
        CoinEffect effect = Instantiate(coinEffect);
        effect.Perform(coin, MonoUtility.Instance.player.transform.position);
        audi.Play();
    }
}
