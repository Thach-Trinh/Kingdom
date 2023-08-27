using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ThachTween : MonoBehaviour
{
    public CoinEffect coinEffect;
    public Transform priest;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Perform();
        }
    }


    public void Perform()
    {
        CoinEffect effect = Instantiate(coinEffect);
        effect.Perform(100, priest.position);
    }


}
