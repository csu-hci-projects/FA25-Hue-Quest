using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] float speed = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float speedFactor = speed * Time.deltaTime;
        float x = speedFactor * Input.GetAxis("Horizontal");
        float z = speedFactor * Input.GetAxis("Vertical");
        //float y = 0;


    }
}
