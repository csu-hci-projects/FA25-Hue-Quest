using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneTrigger : MonoBehaviour
{
    [SerializeField] string sceneName;

    [SerializeField] float backUpDistance = 2f;   // how far away to save the return position

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Saving player hub location...");

            Transform t = other.transform;

            // move the saved position BACKWARD from where the player is standing
            Vector3 safeReturnPos = t.position - t.forward * backUpDistance;

            SavedHubPosition.hubPosition = safeReturnPos;
            SavedHubPosition.hubRotation = t.rotation;

            Debug.Log("Loading scene: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}
