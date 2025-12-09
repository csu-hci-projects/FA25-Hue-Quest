using UnityEngine;

public class CameraButtonTrigger : MonoBehaviour
{
    [SerializeField] CameraToggle cameraToggle;
    [SerializeField] GameObject cameraMessageUI;  // 3D text above button
    
    void Start()
    {
        // Hide message at start
        if (cameraMessageUI != null)
        {
            cameraMessageUI.SetActive(false);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Camera toggle unlocked!");
            
            if (cameraToggle != null)
            {
                cameraToggle.canToggle = true;
            }
            
            // Show message permanently
            if (cameraMessageUI != null)
            {
                cameraMessageUI.SetActive(true);
            }
        }
    }
}