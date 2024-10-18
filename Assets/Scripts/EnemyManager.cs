using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    public int EnemyKills = 0;
    public List<Enemy> enemies = new List<Enemy>();
    float NextEnemySpawn = 0;
    float NextEnemySpawnBoss = 0;
    StateMachine stateMachine;

    [SerializeField] List<Enemy> EnemyPrefabz = new List<Enemy>();
    [SerializeField] List<Enemy> EnemyPrefabChampBoss = new List<Enemy>();
    public float EnemySpawnRateBoss = 0.2f;

    //[SerializeField] Enemy enemyPrefab;
    [SerializeField] TextMeshProUGUI KillCountDisplayer;
    public float EnemySpawnRate = 0.2f;
    public float EnemySpawnDistance = 0;
    // Spawn Rate does not seem to change much from 2 to 0.2 .....??

    [SerializeField] Transform PlayerPosition;

    private void Awake()
    {
        Instance = this;
    }
   
    public void UpdateEnemySpawnDelay(float GFKP)
    {
        EnemySpawnRate += GFKP;

    }

    public void OnStateChange()
    {
        foreach(Enemy e in enemies)
        {
            e.SetVelToCero();
        }
    }



    public void UpdateEnemyManager()
    {
        if (NextEnemySpawn >= 1f)
        {
            SpawnEnemyRandom();

            NextEnemySpawn = 0;
        }
        else
        {
            NextEnemySpawn += Time.deltaTime * EnemySpawnRate;
        }

        if (NextEnemySpawnBoss >= 20)
        {
            SpawnEnemyBossRandom();

            NextEnemySpawnBoss = 0;
        }
        else
        {
            NextEnemySpawnBoss += Time.deltaTime * EnemySpawnRateBoss;
        }

        foreach (Enemy e in enemies) e.UpdateEnemy(PlayerPosition.position);
    }

    public void SpawnEnemyRandom()
    {
        Vector3 rndPos = Random.insideUnitCircle.normalized;
        rndPos *= EnemySpawnDistance;

        SpawnEnemy(PlayerPosition.position + rndPos);
    }

    public void SpawnEnemyBossRandom()
    {
        Vector3 rndPos = Random.insideUnitCircle.normalized;
        rndPos *= EnemySpawnDistance;

        SpawnBossEnemy(PlayerPosition.position + rndPos);
    }

    public void SpawnEnemy(Vector3 aPosition)
    {
        int getRandomEnemy = Random.Range(0, EnemyPrefabz.Count);
        Enemy e = Instantiate(EnemyPrefabz[getRandomEnemy], transform);
        enemies.Add(e);
        e.transform.position = aPosition;
        e.OnKilled.AddListener(EnemyKilled);
    }

    public void SpawnBossEnemy(Vector3 aPosition)
    {
        int h = Random.Range(0, EnemyPrefabChampBoss.Count);
        Enemy e = Instantiate(EnemyPrefabChampBoss[h], transform);
        enemies.Add(e);
        e.transform.position = aPosition;
        e.OnKilled.AddListener(EnemyKilled);
    }

    public void EnemyKilled(Enemy anEnemy)
    {
        anEnemy.OnKilled.RemoveAllListeners();
        EnemyKills++;
        KillCountDisplayer.text = "Current Kills: " + EnemyKills.ToString();

        if (enemies.Contains(anEnemy)) enemies.Remove(anEnemy);
    }

}