using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has touched lader");
            if (other.gameObject.GetComponent<ColorManager>().hasGreen)
            {
                Debug.Log("Moving Player up");
                Vector3 move = new Vector3(0,10,0);
                Transform playerPosition = other.gameObject.GetComponent<Transform>();
                
                playerPosition.Translate(move);
            }
        }
    }
}
