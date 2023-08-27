using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CapitalGameflow : Gameflow
{
    public Transform castlePoint;
    public Transform meetingPoint;
    public Transform guard;
    public PlayableDirector meetingDirector;
    public ActingBoss boss;
    protected override void Init()
    {
        base.Init();
        SetDestination(guard.transform);
    }
    public void StartTeleporting()
    {
        mono.fading.Fade();
        Invoke(nameof(TeleportToCastle), 1f);
    }
    private void TeleportToCastle()
    {
        mono.player.Teleport(castlePoint.position);
    }

    public void StartMeeting()
    {
        mono.player.Teleport(meetingPoint.position);
        mono.player.transform.rotation = meetingPoint.rotation;
        meetingDirector.Play();
        boss.Stop();
    }

    public void StartMission()
    {
        SceneManager.LoadScene("Book");
    }
}
