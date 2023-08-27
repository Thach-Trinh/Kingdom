using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThachRotation : MonoBehaviour
{
    public float rotatingSpeed;
    public float minAngle;
    public Transform target;
    private Quaternion desiredDirection;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Rotate());
        }
    }

    private IEnumerator Rotate()
    {
        Debug.Log("Start Rotate");
        gameObject.SetActive(false);
        Vector3 direction = target.position - transform.position;
        float angle;
        do
        {
            angle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);
            desiredDirection = Quaternion.Euler(0, angle, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredDirection, rotatingSpeed * Time.deltaTime);
            Debug.Log($"angle {angle}");
            yield return null;
        } while (transform.rotation != desiredDirection);
        Debug.Log($"Finish Rotate");
    }

    private void RotateTowardTarget()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);
        desiredDirection = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredDirection, rotatingSpeed * Time.deltaTime);
    }

    private void SetDesiredDirection()
    {
        //desiredDirection = Quaternion.Euler(direction);
    }

}


