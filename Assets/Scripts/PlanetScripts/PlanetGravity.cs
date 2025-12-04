using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    IPlanet gravityTarget;
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
        processGravity();
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

}
