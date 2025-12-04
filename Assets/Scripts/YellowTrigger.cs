using UnityEngine;

public class YellowTrigger : MonoBehaviour
{
    [SerializeField] ColorManager player;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Yellow Paint is grabbed");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has picked up yellow paint");
            player.hasYellow = true;
            Debug.Log("Player should now have yellow and can climb walls.");
        }
        gameObject.SetActive(false);
    }
}