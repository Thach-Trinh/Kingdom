using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ThachAnimation : MonoBehaviour
{
    public FakeVillager[] villagers;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (FakeVillager villager in villagers)
            {
                villager.StartTransform();
            }
        }
    }
}
