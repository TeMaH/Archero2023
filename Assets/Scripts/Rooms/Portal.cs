using System;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public event Action PlayerInPortal;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ActivateTeleport()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BasePlayer>() != null)
        {
            PlayerInPortal?.Invoke();
        }
    }
}