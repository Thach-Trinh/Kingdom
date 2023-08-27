using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackWeapon : MonoBehaviour
{
    public int defaultDamage;
    private int currentDamage;
    public UnityEvent onCountered;
    public Collider _collider;
    public AudioSource sound;
    private void Start()
    {
        currentDamage = defaultDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            if (sound != null) sound.Play();
            //Debug.Log($"{gameObject.name} {gameObject.layer} hit {other.gameObject.name} {other.gameObject.layer}");
            health.TakeDamage(currentDamage);
        }
    }
}
