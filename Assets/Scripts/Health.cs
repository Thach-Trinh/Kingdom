using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealthPoint;
    [SerializeField]
    protected float healthPoint;
    public float HealthPoint
    {
        get => healthPoint;
        set
        {
            healthPoint = value;
            onHealthChanged.Invoke();
        }
    }
    //public int disappearingDelay;
    public bool isAlive = true;
    public UnityEvent onHealthChanged;
    public UnityEvent onDead;
    public UnityEvent onHit;
    protected virtual void Start()
    {
        Revive();
        isAlive = true;
    }
    public void Revive()
    {
        HealthPoint = maxHealthPoint;
    }

    public virtual void TakeDamage(float damage)
    {
        if (!isAlive) return;
        HealthPoint -= damage;
        if (HealthPoint <= 0)
        {
            Dead();
            //Destroy(gameObject, disappearingDelay);
        }
        else
        {
            onHit.Invoke();
        }
    }

    public void Dead()
    {
        onDead.Invoke();
        isAlive = false;
    }
}
