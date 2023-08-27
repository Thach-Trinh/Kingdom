using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThachVelocity : MonoBehaviour
{
    public int speed;
    public Rigidbody rigid;
    private void Start()
    {
        Debug.Log(Vector3.zero.normalized);
    }
    void Update()
    {
        rigid.velocity = new Vector3(0, 0, speed);
    }
}
