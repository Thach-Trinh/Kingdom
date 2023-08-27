using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterManagement : MonoBehaviour
{
    public Side side;
    public Health health;
    public Animator animator;
    public MonoBehaviour[] others;
    protected void Start()
    {
        MonoUtility.Instance.population.pool[side].Add(this);
        health.onDead.AddListener(() =>
        {
            MonoUtility.Instance.population.pool[side].Remove(this);
        });
        RegisterEvent();
    }
    protected virtual void RegisterEvent()
    {
        health.onHit.AddListener(()=>
        {
            animator.SetTrigger("Hit");
        });
        health.onDead.AddListener(() =>
        {
            animator.SetTrigger("Dead");
        });
    }
}


