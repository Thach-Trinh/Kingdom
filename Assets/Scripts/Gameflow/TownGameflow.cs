using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownGameflow : Gameflow
{
    public SpeakingBehaviour priest;
    public Civilian guard;
    public Transform guardDestination;
    protected override void Init()
    {
        base.Init();
        SetDestination(guard.transform);
    }

    public void OnGateOpen()
    {
        StartCoroutine(missionPanel.Show("Go to the church"));
        guard.SetDestination(guardDestination.position);
        SetDestination(priest.transform);
        priest.enabled = true;
    }

    public void OnPlayerMeetingPriest()
    {
        IgnoreDestination();
    }
    public void StartMission()
    {
        SceneManager.LoadScene("Book");
    }
}
