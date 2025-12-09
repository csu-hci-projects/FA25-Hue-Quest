using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject killPlane;
    [SerializeField] GameObject respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        killPlane.SetActive(true);
        respawnPoint.SetActive(true);
        gameObject.SetActive(false);
    }
}
