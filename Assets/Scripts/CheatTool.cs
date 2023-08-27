using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheatTool : MonoBehaviour
{
    public static CheatTool Instance;
    public Action onCheat;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            onCheat?.Invoke();
        }
    }
}
