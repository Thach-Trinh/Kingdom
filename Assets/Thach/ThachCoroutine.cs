using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThachCoroutine : MonoBehaviour
{
    public float delay;

    private void Awake()
    {
        Debug.Log("Awake");
    }
    private void Start()
    {
        Debug.Log("Start");
    }
    public void StartInvoke()
    {
        Debug.Log("Waiting");
        StartCoroutine(Test());
    }
    public IEnumerator Test()
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Oh yeah");
    }
}
