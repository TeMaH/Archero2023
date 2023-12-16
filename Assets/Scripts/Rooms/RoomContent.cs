using UnityEngine;

public class RoomContent : MonoBehaviour
{
    public Transform PlayerSpawn;
    public Transform[] EnemySpawnPoints;
    public Enemy[] MobsPrefab;
    public Portal Teleport;

    private int enemiesCount;

    private void Awake()
    {
        for (int i = 0; i < EnemySpawnPoints.Length; i++)
        {
            var enemy = Instantiate(RamdomizeMob(), EnemySpawnPoints[i].position, Quaternion.identity);
            enemiesCount++;
            enemy.GetComponent<HealthSystem>().Death += OnEnemyDeath;
        }
    }

    private Enemy RamdomizeMob()
    {
        var index = Random.Range(0, MobsPrefab.Length - 1);
        return MobsPrefab[index];
    }

    private void OnEnemyDeath()
    {
        enemiesCount--;
        if (enemiesCount <= 0)
        {
            RoomComplete();
        }
    }

    private void RoomComplete()
    {
        Teleport.ActivateTeleport();
    }
}
