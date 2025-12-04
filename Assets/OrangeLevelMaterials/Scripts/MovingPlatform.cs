using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float height = 2f;
    public float speed = 2f;

    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float t = Mathf.PingPong(Time.time * speed, height);
        transform.position = startPos + new Vector3(0, t, 0);

    }
}
