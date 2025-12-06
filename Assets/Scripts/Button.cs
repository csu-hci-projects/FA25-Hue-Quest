using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int pressedDistance = 5;
    [SerializeField] float speed = 12.0f;
    Vector3 pressedVector;
    void Start()
    {
        pressedVector = new Vector3(0,pressedDistance,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit Button");
        transform.position = Vector3.MoveTowards(transform.position, transform.position - pressedVector, speed * Time.deltaTime);
        
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Released Button");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + pressedVector, speed * Time.deltaTime);
    }
}
