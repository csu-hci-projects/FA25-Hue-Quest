using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToHubButton : MonoBehaviour
{
    [SerializeField] string hubSceneName = "HubWorld";

    //adding UnlockLevelColor functionality
    [SerializeField] bool IsLevelEnd = false;
    public string colorKey;
    public string fadeKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Returning to hub...");

            //UnlockLevelColor function
            if (IsLevelEnd)
            {
                PlayerPrefs.SetInt(colorKey, 1);
                PlayerPrefs.SetInt(fadeKey, 1);
                PlayerPrefs.Save();
            }

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
            //disable starting screen?
            HubCamera playercam = player.GetComponent<HubCamera>();
            playercam.Activate();
            //end

            player.GetComponent<HubCamera>().Activate();
            if (cc) cc.enabled = true;
        }
    }
}
