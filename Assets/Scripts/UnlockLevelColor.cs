using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockLevelColor : MonoBehaviour
{
    public string hubScene = "HubWorld";
    public string colorKey;
    public string fadeKey;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Permanently unlock this color
        PlayerPrefs.SetInt(colorKey, 1);
        PlayerPrefs.SetInt(fadeKey, 1);
        PlayerPrefs.Save();

        SceneManager.LoadScene(hubScene);
    }
}
