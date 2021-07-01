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

    int savedScore = 0;
    int unsavedScore = 0;

    private void Awake()
    {
        CreatePlayer();
        savePoint.OnPlayerCollided += SaveScore;
    }

    private void Start()
    {
        StartCoroutine(EnemyWaves());
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    IEnumerator EnemyWaves()
    {
        currentTimeBetweenEnemies = timeBetweenEnemies;
        CreateEnemy();
        while(currentTime < gameTime)
        {
            yield return new WaitForSeconds(currentTimeBetweenEnemies);
            currentTimeBetweenEnemies = currentTimeBetweenEnemies - timeReduceBetweenEnemies > 0 ? currentTimeBetweenEnemies - timeReduceBetweenEnemies : currentTimeBetweenEnemies;
            CreateEnemy();
        }
    }

    private void CreatePlayer()
    {
        GameObject playerGo = Instantiate(playerPrefab);
        playerShape = playerGo.GetComponent<Shape>();
        playerShape.OnTakeDamage += PlayerRecievedDamage;
        playerShape.OnDestroy += PlayerDied;
    }

    private void CreateEnemy()
    {
        int randomPosIndex = Random.Range(0, enemySpawnPositions.Count);
        GameObject EnemyGo = Instantiate(enemyPrefab, enemySpawnPositions[randomPosIndex].position, Quaternion.identity, enemySpawnPositions[randomPosIndex]);
        var enemyController = EnemyGo.GetComponent<EnemyController>();
        enemyController.OnPointsGiven += AddScore;
        enemyController.SetTarget(playerShape.transform);
        enemiesControllers.Add(enemyController);
    }

    void SaveScore()
    {
        savedScore = unsavedScore;
    }

    void PlayerRecievedDamage()
    {
        CameraController.instance.ShakeCamera();
    }

    void PlayerDied()
    {
        StopAllCoroutines();
        foreach (var item in enemiesControllers)
        {
            item.StopFollowing();
        }
    }

    void AddScore(int score)
    {
        unsavedScore += score;
    }
}
