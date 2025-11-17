using UnityEngine;
using Unity.Cinemachine;

public class HubCamera : MonoBehaviour
{
     [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject planetCamera;

    bool planetCameraActive;
    float flipPosition = 22.4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        planetCameraActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        switchCamera();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Deactivate();
        }
    }
    
      public void Activate()
    {
        playerCamera.SetActive(true);
    }
    public void Deactivate()
    {
        playerCamera.SetActive(false);
        planetCamera.SetActive(false);
    }

    void switchCamera()
    {
        if (transform.position.z > -12)
        {
            planetCamera.GetComponent<CinemachineOrbitalFollow>().TargetOffset.Set(0, 0, flipPosition);
        }
        else
        {
            planetCamera.GetComponent<CinemachineOrbitalFollow>().TargetOffset.Set(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            planetCameraActive = !planetCameraActive;
            planetCamera.SetActive(planetCameraActive);
        }
    }
}
