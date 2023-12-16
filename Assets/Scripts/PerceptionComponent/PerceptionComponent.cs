using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionComponent : MonoBehaviour
{
    public LayerMask EnemyMask;
    public float smallDistance;
    public float bigDistance;
    public float SearchRadius;
    public GameObject closestObj;
    public GameObject player;
    public List<GameObject> enemies;
    public List<GameObject> targets;

    private void Start()
    {
        var objectsInRadius = Physics.OverlapSphere(transform.position, SearchRadius);

        for (int i = 0; i < objectsInRadius.Length; i++)
        {
            if (objectsInRadius[i].GetComponent<Enemy>())
            {
                if (enemies.Contains(objectsInRadius[i].gameObject))
                {
                    continue;
                }
                enemies.Add(objectsInRadius[i].gameObject);
            }

            if (objectsInRadius[i].GetComponent<BasePlayer>())
            {
                player = objectsInRadius[i].gameObject;
            }
        }
        if (LayerMask.LayerToName(gameObject.layer).Equals("Player"))
        {
            targets = enemies;
        }
        else if(LayerMask.LayerToName(gameObject.layer).Equals("Enemy"))
        {
            targets.Add(player);
        }
    }

    private void Update()
    {
        ClosestTarget();
        Debug.Log(closestObj);
    }

    private void OnDrawGizmos()
    {
        // Отрисовка радиуса в гизмосе
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, smallDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, bigDistance);
    }

    public DamageableObject GetTarget() 
    {
        return null;
    }

    public void ClosestTarget()
    {
        // List<GameObject> targets = new List<GameObject>();

        bool inRange = false;
        float closestDistance = Mathf.Infinity;
        foreach (var target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance <= smallDistance && distance < closestDistance)
            {
                closestObj = target.gameObject;
                closestDistance = distance;
                inRange = true;
            }
        }

        if (!inRange && closestObj != null)
        {
            float distance = Vector3.Distance(transform.position, closestObj.transform.position);
            if (distance <= bigDistance)
            {
                inRange = true;
            }

            if (!inRange)
            {
                closestObj = null;
            }
        }
    }
}