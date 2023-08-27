using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManagement : CharacterManagement
{
    public NavMeshAgent agent;
    protected override void RegisterEvent()
    {
        base.RegisterEvent();
        health.onDead.AddListener(() =>
        {
            agent.isStopped = true;
        });
    }
}
