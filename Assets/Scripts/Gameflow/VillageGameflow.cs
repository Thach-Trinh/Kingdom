using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class VillageGameflow : Gameflow
{
    public PlayableDirector invasionDirector;
    public PlayableDirector escapingDirector;
    public SpeakingBehaviour packageSender;
    public SpeakingBehaviour packageReceiver;
    public SpeakingBehaviour storyTeller;

    public Villager[] villagers;

    public Transform[] spawningPositions;
    public EnemyManagement[] enemies;
    public float spawningDuration;
    public int maxNumberOfEnemies;

    public int targetNumberOfDeadEnemies;
    private int currentNumberOfDeadEnemies;

    public ChurchBell bell;
    public GameObject daggerIcon;
    public GameObject gate;
    public Boat boat;
    public float completingDelay;
    public AudioClip villageTheme;
    public AudioClip dangerTheme;
    public AudioSource bossVoice;
    //public AudioClip bossVoice;
    public DeadBody[] deadBodies;

    public FakeVillager[] fakeVillagerPrefabs;
    private List<FakeVillager> fakeVillagers = new List<FakeVillager>();
    public Transform[] fakeVillagerPoints;

    public GameObject toBeContinuePanel;
    private bool canEscape = false;


    protected override void Init()
    {
        base.Init();
        StartCoroutine(missionPanel.Show("Explore the world"));
        SetDestination(packageSender.transform);
        CheatTool.Instance.onCheat += FinishChapter;
    }

    public void StartShippingTask()
    {
        packageSender.enabled = false;
        packageReceiver.enabled = true;
        StartCoroutine(missionPanel.Show("Ship the package to the village"));
        SetDestination(packageReceiver.transform);
    }
    public void FinishShippingTask()
    {
        packageReceiver.enabled = false;
        storyTeller.enabled = true;
        SetDestination(storyTeller.transform);
    }

    public void OnVibration()
    {
        mono.thirdPersonCamera.Shake();
        bossVoice.Play();
        //soundSource.PlayOneShot(bossVoice);
    }

    public void OnBossAppear()
    {
        invasionDirector.Play();
        audi.PlayOneShot(villageTheme);
    }

    public void OnInvasionStart()
    {
        foreach (DeadBody deadBody in deadBodies)
        {
            deadBody.StartTransform();
        }
        foreach (Villager villager in villagers)
        {
            villager.OnInvasionStart();
        }
        currentNumberOfDeadEnemies = 0;
        StartSpawning();
        StartCoroutine(missionPanel.Show("Find a weapon"));
        bell.StartRinging();
        daggerIcon.SetActive(true);
        SetDestination(daggerIcon.transform);
    }
    public void ActivePlayer() => mono.player.ActivePlayer();
    public void DisablePlayer() => mono.player.DisablePlayer();
    private void StartSpawning()
    {
        foreach(Transform trans in spawningPositions)
        {
            Instantiate(enemies.GetRandomElement(), trans.position, Quaternion.identity);
        }
        Invoke(nameof(SpawnEnemy), spawningDuration);
    }
    private void SpawnEnemy()
    {
        if (mono.population.pool[Side.Enemy].Count <= maxNumberOfEnemies)
        {
            Vector3 position = spawningPositions.GetRandomElement().position;
            EnemyManagement enemy = Instantiate(enemies.GetRandomElement(), position, Quaternion.identity);
            enemy.health.onDead.AddListener(CountEnemyDeath);
        }
        Invoke(nameof(SpawnEnemy), spawningDuration);
    }
    public void CountEnemyDeath()
    {
        if (canEscape) return;
        currentNumberOfDeadEnemies++;
        if (currentNumberOfDeadEnemies >= targetNumberOfDeadEnemies)
        {
            canEscape = true;
            StartEscapingMission();
        }
    }

    public void StartCombat()
    {
        mono.player.weapon.SetUp(WeaponType.Dagger);
        StartCoroutine(missionPanel.Show("Keep survive"));
        IgnoreDestination();
    }

    private void StartEscapingMission()
    {
        StartCoroutine(missionPanel.Show("Escape to the river side"));
        gate.SetActive(true);
        SetDestination(boat.transform);
    }

    public void FinishEscapingMission()
    {
        //mono.player.Teleport(boat.seat.position);
        mono.player.DisablePlayer();
        mono.player.transform.SetParent(boat.seat);
        mono.player.transform.localPosition = Vector3.zero;
        mono.player.transform.localRotation = Quaternion.identity;
        boat.StartMoving();
        StartCoroutine(missionPanel.Show("Mission complete"));
        bell.StopRinging();
        IgnoreDestination();
        Invoke(nameof(OnPlayerEscaping), completingDelay);
    }

    public void OnPlayerEscaping()
    {
        DestroyAllVillager();
        DestroyAllEnemy();
        foreach (Transform point in fakeVillagerPoints)
        {
            FakeVillager fakeVillager = Instantiate(fakeVillagerPrefabs.GetRandomElement(), point.position, Quaternion.Euler(0, 180, 0));
            fakeVillagers.Add(fakeVillager);
        }
        escapingDirector.Play();
        mono.player.transform.localRotation *= Quaternion.Euler(0, 180, 0);
        boat.SlowDown();
    }



    private void DestroyAllVillager()
    {
        foreach (Villager villager in villagers)
        {
            if (villager == null) continue;
            Destroy(villager.gameObject);
            mono.population.pool[Side.Ally].Remove(villager);
        }
    }

    private void DestroyAllEnemy()
    {
        List<CharacterManagement> enemyList = mono.population.pool[Side.Enemy];
        foreach (CharacterManagement enemy in enemyList)
        {
            Destroy(enemy.gameObject);
        }
        enemyList.Clear();
    }

    public void OnBossUsingMagic()
    {
        audi.PlayOneShot(dangerTheme);
        foreach (FakeVillager fakeVillager in fakeVillagers)
        {
            fakeVillager.StartTransform();
        }
        Invoke(nameof(ShowToBeContinuePanel), 17f);
    }

    private void ShowToBeContinuePanel()
    {
        toBeContinuePanel.SetActive(true);
        Invoke(nameof(FinishChapter), 3f);
    }

    public void FinishChapter()
    {
        DatabaseController.Instance.data.chapter++;
        LoadingScreen.Instance.LoadScene(SceneTheme.Town);
        CheatTool.Instance.onCheat -= FinishChapter;
    }


}
