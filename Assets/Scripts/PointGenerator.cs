using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGenerator : MonoBehaviour
{
    [ContextMenu("Generate Point")]
    public void GenerateObject()
    {
        GameObject x = new GameObject("Thach");
        x.transform.SetParent(transform);
    }

}
