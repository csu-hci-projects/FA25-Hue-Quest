using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] float liftStrength = 10;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has touched lader");
            if (other.gameObject.GetComponent<ColorManager>().hasGreen)
            {
                Debug.Log("Moving Player up");
                Vector3 move = new Vector3(0,liftStrength,0);
                Transform playerPosition = other.gameObject.GetComponent<Transform>();
                other.GetComponent<ThirdPersonMovement>().enabled = false;
                other.GetComponent<CharacterController>().enabled = false;
                playerPosition.Translate(move);
                other.GetComponent<CharacterController>().enabled = true;
                other.GetComponent<ThirdPersonMovement>().enabled = true;
            }
        }
    }
}
