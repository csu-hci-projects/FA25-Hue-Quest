using UnityEngine;

public class Player : MonoBehaviour
{
    IPlanet gravityTarget;
    [SerializeField] float playerSpeed = 12.0f;
    [SerializeField] float rotateSpeed = 12.0f;
    Rigidbody rb;

    [SerializeField] Manager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        processGravity();
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

    public void setGravityTarget(IPlanet target) {
        gravityTarget = target;
    }
}
