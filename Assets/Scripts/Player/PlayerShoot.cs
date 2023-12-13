using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float SearchRadius;
    public GameObject bullet;
    public float ShootingRate;

    private GameObject enemy;
    private float time;

    private void FixedUpdate()
    {
        var objectsInRadius = Physics.OverlapSphere(transform.position, SearchRadius);
        enemy = null;

        for (int i = 0; i < objectsInRadius.Length; i++)
        {
            if (objectsInRadius[i].GetComponent<Enemy>())
            {
                enemy = objectsInRadius[i].gameObject;
            }
        }
    }

    public void Shoot()
    {
        if (enemy == null)
            return;

        var position = transform.position;
        Vector3 dir = enemy.transform.position - position;
        Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);

        Instantiate(bullet, position, rotation);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > ShootingRate)
        {
            Shoot();
            time -= ShootingRate;
        }
    }
}
