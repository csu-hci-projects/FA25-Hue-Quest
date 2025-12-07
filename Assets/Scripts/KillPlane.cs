using System.Collections;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    [Header("Respawn Settings")]
    public Transform defaultRespawnPoint;
    public Transform yellowRespawnPoint;
    public float respawnDelay = 1f;  // delay in seconds before respawning

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        StartCoroutine(RespawnPlayer(other));
    }

    IEnumerator RespawnPlayer(Collider other)
    {
        // Wait for delay
        yield return new WaitForSeconds(respawnDelay);

        ColorManager colorManager = other.GetComponent<ColorManager>();
        if (colorManager == null) yield break;

        Transform respawnToUse = defaultRespawnPoint;

        if (colorManager.hasYellow && yellowRespawnPoint != null)
        {
            respawnToUse = yellowRespawnPoint;
        }

        // Unfreeze player movement
        ThirdPersonMovement movement = other.GetComponent<ThirdPersonMovement>();
        if (movement != null)
        {
            movement.isFrozen = false;
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