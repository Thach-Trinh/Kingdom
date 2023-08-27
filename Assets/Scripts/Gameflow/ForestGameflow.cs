using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class ForestGameflow : Gameflow
{
    public AncientTree tree;
    public Priest priest;
    public Gravestone[] traps;
    public Transform home;
    public GameObject gate;
    public float trapDelay;
    public float waveDelay;
    public SkeletonBoss boss;
    public Transform rain;
    private bool hasPriestReached;
    
    protected override void Init()
    {
        base.Init();
        mono.player.weapon.Equip(WeaponType.Dagger, WeaponType.Bow);
        mono.player.weapon.SetUp(WeaponType.Bow);
        mono.player.suit.SetUpSuit(SuitType.Hunter);
        path.SetTarget(priest.transform);
        StartCoroutine(missionPanel.Show("Protest the priest"));
        CheatTool.Instance.onCheat += FinishChapter;
        rain.SetParent(minimapCamera.transform);
        Vector3 newPos = Vector3.zero;
        newPos.z = rain.localPosition.z;
        rain.localPosition = newPos;
    }

    public void OnPriestReachTree()
    {
        if (hasPriestReached) return;
        hasPriestReached = true;
        StartCoroutine(missionPanel.Show("Defend the priest"));
        StartSkeletonWave();
    }

    private void StartSkeletonWave()
    {
        StartCoroutine(ActiveGravestoneTrap());
        if (tree.isFinish) return;
        Invoke(nameof(StartSkeletonWave), waveDelay);
    }

    private IEnumerator ActiveGravestoneTrap()
    {
        mono.thirdPersonCamera.Shake();
        foreach (Gravestone trap in traps)
        {
            trap.GenerateSkeleton();
            yield return new WaitForSeconds(trapDelay);
        }
    }

    public void OnDeathMagicCursed()
    {
        StartCoroutine(missionPanel.Show("Get out of here"));
        SetDestination(home);
        gate.SetActive(true);
        Instantiate(boss, transform.position, Quaternion.identity);
    }

    public void FinishChapter()
    {
        DatabaseController.Instance.data.chapter++;
        LoadingScreen.Instance.LoadScene(SceneTheme.Capital);
        CheatTool.Instance.onCheat -= FinishChapter;
    }
}
