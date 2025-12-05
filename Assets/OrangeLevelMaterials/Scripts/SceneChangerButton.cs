using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneTrigger : MonoBehaviour
{
    [SerializeField] string sceneName; // assign in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
