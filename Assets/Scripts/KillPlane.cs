using UnityEngine;

public class KillPlane : MonoBehaviour
{
    [Header("Respawn Settings")]
    public Transform defaultRespawnPoint;  // initial respawn
    public Transform yellowRespawnPoint;   // respawn after player gets yellow

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        ColorManager colorManager = other.GetComponent<ColorManager>();
        if (colorManager == null) return;

        Transform respawnToUse = defaultRespawnPoint;

        if (colorManager.hasYellow && yellowRespawnPoint != null)
        {
            respawnToUse = yellowRespawnPoint;
        }

        // teleport player
        CharacterController controller = other.GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;
            other.transform.position = respawnToUse.position;
            controller.enabled = true;
        }
        else
        {
            other.transform.position = respawnToUse.position;
        }
    }
}
