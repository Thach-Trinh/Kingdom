using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThachOverlap : MonoBehaviour
{
    public float groundCheckingRadius;
    public LayerMask groundLayer;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, groundCheckingRadius, groundLayer);
            Debug.Log(colliders != null);
            if (colliders != null) Debug.Log(colliders.Length);
        }
    }
}
