using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingdomGameflow : Gameflow
{
    //public int maxAllyNumber = 5;
    //public int maxEnemyNumber = 5;
    public int targetDeathEnemyNumber = 5;
    public float startDelay;
    public float completingDelay;

    public Gate gate;
    public AudioSource warHorn;
    public SkeletonBoss skeletonBoss;
    public AllyManagement[] allyTeam;
    public EnemyManagement[] enemyTeam;
    public Transform[] enemySpawningPoints;
    //public Transform allySpawningPoint;

    private bool hasBossCome;
    private int currentDeathEnemyNumber;

    protected override void Init()
    {
        base.Init();
        IgnoreDestination();
        mono.player.weapon.Equip(WeaponType.Dagger, WeaponType.Bow, WeaponType.SwordAndShield);
        mono.player.weapon.SetUp(WeaponType.SwordAndShield);
        mono.player.suit.SetUpSuit(SuitType.Knight);
        StartCoroutine(StartBattle());
        CheatTool.Instance.onCheat += OnCompleteMission;
    }
    private IEnumerator StartBattle()
    {
        yield return new WaitForSeconds(startDelay);
        gate.Open();
        yield return CountDown();
        StartCoroutine(missionPanel.Show("Defend your kingdom"));
        warHorn.Play();
        foreach (Transform point in enemySpawningPoints)
        {
            EnemyManagement enemy = Instantiate(enemyTeam.GetRandomElement(), point.position, Quaternion.identity);
            enemy.health.onDead.AddListener(OnEnemyDeath);
        }
        currentDeathEnemyNumber = 0;
    }
    private IEnumerator CountDown()
    {
        for (int i = 3; i > 0; i--)
        {
            missionPanel.ShowText(i.ToString());
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnEnemyDeath()
    {
        if (hasBossCome) return;
        currentDeathEnemyNumber++;
        EnemyManagement enemy = Instantiate(enemyTeam.GetRandomElement(), enemySpawningPoints.GetRandomElement().position, Quaternion.identity);
        enemy.health.onDead.AddListener(OnEnemyDeath);
        if (currentDeathEnemyNumber >= targetDeathEnemyNumber)
        {
            OnBossEntrance();
        }
    }
    public void OnAllyDeath()
    {
        Debug.Log("OnAllyDeath");
        AllyManagement ally = Instantiate(allyTeam.GetRandomElement(), transform.position, Quaternion.identity);
        ally.health.onDead.AddListener(OnAllyDeath);
    }
    private void OnBossEntrance()
    {
        Debug.Log("OnBossEntrance");
        hasBossCome = true;
        StartCoroutine(missionPanel.Show("Boss is coming"));
        SkeletonBoss boss = Instantiate(skeletonBoss, enemySpawningPoints.GetRandomElement().position, Quaternion.identity);
        boss.health.onDead.AddListener(OnBossDead);
    }
    private void OnBossDead()
    {
        StartCoroutine(missionPanel.Show("Congratulation"));
        Invoke(nameof(OnCompleteMission), completingDelay);
    }
    public void OnCompleteMission()
    {
        DatabaseController.Instance.data.chapter++;
        SceneManager.LoadScene("Book");
        CheatTool.Instance.onCheat -= OnCompleteMission;
    }
}
