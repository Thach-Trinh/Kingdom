using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AncientTree : MonoBehaviour
{
    public float speed;
    public float maxPoint;
    public float effectDuration;
    public bool isFinish;
    private float currentPoint;

    public GameObject glowingEffect;
    public UnityEvent onPointChanged;
    public UnityEvent onFinish;
    public Transform[] effectPositions;
    public float CurrentPoint
    {
        get => currentPoint;
        set
        {
            currentPoint = value;
            onPointChanged.Invoke();
        }
    }
    
    private void Start()
    {
        currentPoint = 0;
    }
    public void UpdateProgress()
    {
        CurrentPoint += speed * Time.deltaTime;
        if (CurrentPoint >= maxPoint)
        {
            FinishProcess();
        }
        //ProgessUI.Intance.IncreaseProgess();
    }
    private void FinishProcess()
    {
        isFinish = true;
        foreach (Transform pos in effectPositions)
        {
            GameObject effect = Instantiate(glowingEffect, pos.position, Quaternion.identity);
            Destroy(effect, effectDuration);
        }
        onFinish.Invoke();
    }
}
