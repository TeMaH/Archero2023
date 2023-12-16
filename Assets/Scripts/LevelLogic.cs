using UnityEngine;

public class LevelLogic : MonoBehaviour
{ 
    public Transform[] EnemySpawnPoints;
    public GameObject MobPrefab;
    public Portal Teleport;

    private int enemiesCount;

    private void Awake()
    {
        for (int i = 0; i < EnemySpawnPoints.Length; i++)
        {
            var enemy = Instantiate(MobPrefab, EnemySpawnPoints[i].position, Quaternion.identity);
            enemiesCount++;
            enemy.GetComponent<HealthSystem>().Death += OnEnemyDeath;
        }
    }

    private void OnEnemyDeath()
    {
        enemiesCount--;
        if (enemiesCount <= 0)
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        Teleport.ActivateTeleport();
    }
}
