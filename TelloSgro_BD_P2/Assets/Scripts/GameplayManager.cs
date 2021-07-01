using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    [SerializeField] GameObject playerPrefab = null;
    [SerializeField] GameObject enemyPrefab = null;
    [SerializeField] SavePoint savePoint = null;

    [Header("Gameplay General")]
    [SerializeField] float gameTime = 120f;
    [SerializeField] float timeBetweenEnemies = 10f;
    [SerializeField] float timeReduceBetweenEnemies = .5f;
    [SerializeField] List<Transform> enemySpawnPositions = null;
    float currentTimeBetweenEnemies = 0;
    float currentTime = 0;

    Shape playerShape = null;
    List<EnemyController> enemiesControllers = new List<EnemyController>();

    public Action<int> OnPlayerGotPoints;
    public Action<int> OnPlayerSavedPoints;
    public Action<int> OnPlayerDeath;
    public Action<float> OnTimeUpdate;

    int savedScore = 0;
    int unSavedScore = 0;
    int deaths = 0;

    private void Awake()
    {
        CreatePlayer();
        savePoint.OnPlayerCollided += SaveScore;
    }

    private void Start()
    {
        currentTimeBetweenEnemies = timeBetweenEnemies;
        CreateEnemy();
        StartCoroutine(EnemyWaves());
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        OnTimeUpdate?.Invoke(currentTime);
    }

    IEnumerator EnemyWaves()
    {
        while(currentTime < gameTime)
        {
            yield return new WaitForSeconds(currentTimeBetweenEnemies);
            currentTimeBetweenEnemies = currentTimeBetweenEnemies - timeReduceBetweenEnemies > 0 ? currentTimeBetweenEnemies - timeReduceBetweenEnemies : currentTimeBetweenEnemies;
            CreateEnemy();
        }
        LoaderManager.Get().SetSessionData(LoaderManager.Get().GetSessionData().username, savedScore, deaths);
        LoaderManager.Get().LoadSceneAsync("End Scene");
    }

    private void CreatePlayer()
    {
        GameObject playerGo = Instantiate(playerPrefab);
        playerShape = playerGo.GetComponent<Shape>();
        playerShape.OnTakeDamage += PlayerRecievedDamage;
        playerShape.OnDestroy += PlayerDied;
        playerShape.OnReset += ContinueCoroutineEnemyWaves;
    }

    private void CreateEnemy()
    {
        int randomPosIndex = UnityEngine.Random.Range(0, enemySpawnPositions.Count);
        GameObject EnemyGo = Instantiate(enemyPrefab, enemySpawnPositions[randomPosIndex].position, Quaternion.identity, enemySpawnPositions[randomPosIndex]);
        var enemyController = EnemyGo.GetComponent<EnemyController>();
        enemyController.OnPointsGiven += AddScore;
        enemyController.SetTarget(playerShape.transform);
        enemiesControllers.Add(enemyController);
    }

    void SaveScore()
    {
        savedScore += unSavedScore;
        unSavedScore = 0;
        OnPlayerSavedPoints?.Invoke(savedScore);
    }

    void PlayerRecievedDamage()
    {
        CameraController.instance.ShakeCamera();
    }

    void PlayerDied()
    {
        StopAllCoroutines();
        CameraController.instance.StrongShakeCamera();
        deaths++;
        unSavedScore /= 2;
        OnPlayerGotPoints?.Invoke(unSavedScore);
        foreach (var item in enemiesControllers)
        {
            item.StopFollowing();
        }
        OnPlayerDeath?.Invoke(deaths);
        playerShape.Reset();
    }

    void ContinueCoroutineEnemyWaves()
    {
        foreach (var item in enemiesControllers)
        {
            item.SetTarget(playerShape.transform);
        }
        StartCoroutine(EnemyWaves());
    }

    void AddScore(int score)
    {
        unSavedScore += score;
        OnPlayerGotPoints?.Invoke(unSavedScore);
    }
}
