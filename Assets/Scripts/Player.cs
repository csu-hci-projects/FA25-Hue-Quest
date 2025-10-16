using Unity.Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    IPlanet gravityTarget;
    [SerializeField] float playerSpeed = 12.0f;
    [SerializeField] float rotateSpeed = 12.0f;
    Rigidbody rb;

    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject planetCamera;

    bool planetCameraActive;
    float flipPosition = 22.4f;

    [SerializeField] Manager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        planetCameraActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        processGravity();
        switchCamera();
    }

    void getInput()
    {
        float speedFactor = playerSpeed * Time.deltaTime;

        float x = speedFactor * Input.GetAxis("Horizontal");
        float y = 0;
        float z = speedFactor * Input.GetAxis("Vertical");
        transform.Translate(x, y, z);

        float rotatefactor = rotateSpeed * Time.deltaTime;
        float xRotate = 0;
        float yRotate = rotatefactor * Input.GetAxis("Horizontal");
        float zRotate = 0;
        transform.Rotate(xRotate, yRotate, zRotate);
    }

    void processGravity()
    {
        Vector3 diff = transform.position - gravityTarget.Position;
        rb.AddForce(-diff.normalized * gravityTarget.getGravity() * rb.mass);
        Debug.DrawRay(transform.position, diff.normalized, Color.red);
    }

    public void setGravityTarget(IPlanet target)
    {
        gravityTarget = target;
    }
    
    void switchCamera()
    {
        if (transform.position.z > 5)
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
