using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThachUnity : MonoBehaviour
{
    public ThachCoroutine coroutine;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coroutine.StartInvoke();
        }
    }

}
