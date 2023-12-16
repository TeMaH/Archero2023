using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextLevel;

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
            SceneManager.LoadScene(nextLevel);
        }
    }
}