using UnityEngine;

public class ColorlessHazard : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Triggered collider");
            if (!other.gameObject.GetComponent<ColorManager>().hasBlue)
            {
                Debug.Log("Player Woahing");
                Vector3 move = new Vector3(0,0,-2);
                Transform playerPosition = other.gameObject.GetComponent<Transform>();
                other.GetComponent<CharacterController>().enabled = false;
                other.GetComponent<ThirdPersonMovement>().enabled = false;
                playerPosition.Translate(move);
                other.gameObject.GetComponent<Animator>().SetTrigger("Woah");
                other.GetComponent<CharacterController>().enabled = true;
                other.GetComponent<ThirdPersonMovement>().enabled = true;
                
            }
        }
    }
}
