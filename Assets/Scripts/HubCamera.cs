using UnityEngine;
using Unity.Cinemachine;

public class HubCamera : MonoBehaviour
{
     [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject planetCamera;
    [SerializeField] GameObject menu;

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
        menu.SetActive(false);
    }
    public void Deactivate()
    {
        playerCamera.SetActive(false);
        planetCamera.SetActive(false);
        menu.SetActive(true);
    }

    void switchCamera()
    {
        if (transform.position.z > -12)
        {
            planetCamera.GetComponent<CinemachineOrbitalFollow>().TargetOffset.Set(0, 0, flipPosition);
           // playerCamera.GetComponent<CinemachineOrbitalFollow>().TargetOffset.Set(0, 0, 10f);
        }
        else
        {
            planetCamera.GetComponent<CinemachineOrbitalFollow>().TargetOffset.Set(0, 0, 0);
            //playerCamera.GetComponent<CinemachineOrbitalFollow>().TargetOffset.Set(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            planetCameraActive = !planetCameraActive;
            planetCamera.SetActive(planetCameraActive);
        }
    }
}
