using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToHubButton : MonoBehaviour
{
    [SerializeField] string hubSceneName = "HubWorld";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Returning to hub...");

            SceneManager.sceneLoaded += OnHubLoaded;
            SceneManager.LoadScene(hubSceneName);
        }
    }

    private void OnHubLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnHubLoaded;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            CharacterController cc = player.GetComponent<CharacterController>();
            if (cc) cc.enabled = false;

            if (SavedHubPosition.hubPosition != null)
            {
                player.transform.position = (Vector3)SavedHubPosition.hubPosition;
                player.transform.rotation = (Quaternion)SavedHubPosition.hubRotation;
            }
            else
            {
                // fallback: spawn point
                Transform spawn = GameObject.Find("PlayerSpawnTransform")?.transform;
                if (spawn)
                {
                    player.transform.position = spawn.position;
                    player.transform.rotation = spawn.rotation;
                }
            }

            if (cc) cc.enabled = true;
        }
    }
}
