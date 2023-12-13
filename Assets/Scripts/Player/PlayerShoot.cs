using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float SearchRadius;
    public GameObject bullet;

    private GameObject enemy;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
}
