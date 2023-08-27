using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float normalSpeed;
    public float slowSpeed;
    public WaterFloat floating;
    public Transform seat;
    public void StartMoving() => floating.AxisOffsetSpeed.z = -normalSpeed;
    public void SlowDown()
    {
        floating.AxisOffsetSpeed.z = -slowSpeed;
        Vector3 euler = seat.eulerAngles;
        euler.y = -euler.y;
        seat.eulerAngles = euler;
    }
}
