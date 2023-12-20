using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionComponent : MonoBehaviour
{
    public LayerMask PlayerMask;
    public LayerMask EnemyMask;
    public float smallDistance;
    public float bigDistance;
    public float SearchRadius;
    public GameObject closestObj;
    public List<GameObject> targets;

    private void Update()
    {
        GetTargets();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, smallDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, bigDistance);
    }

    private void GetTargets()
    {
        var objectsInRadius = Physics.OverlapSphere(transform.position, SearchRadius);

        for (int i = 0; i < objectsInRadius.Length; i++)
        {
            if (objectsInRadius[i].GetComponent<Enemy>() &&
                LayerMask.LayerToName(gameObject.layer).Equals(PlayerMask))
            {
                if (targets.Contains(objectsInRadius[i].gameObject))
                {
                    continue;
                }

                targets.Add(objectsInRadius[i].gameObject);
            }


            if (objectsInRadius[i].GetComponent<BasePlayer>() &&
                LayerMask.LayerToName(gameObject.layer).Equals(EnemyMask))
            {
                if (targets.Contains(objectsInRadius[i].gameObject))
                {
                    continue;
                }

                targets.Add(objectsInRadius[i].gameObject);
            }
        }
    }

    public DamageableObject GetTarget()
    {
        return closestObj.GetComponent<DamageableObject>();
    }

    private void ClosestTarget()
    {
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