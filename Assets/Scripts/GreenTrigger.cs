using UnityEngine;

public class GreenTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Terrain terrain;
    [SerializeField] ColorManager player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hasGreen)
        {
            terrain.treeBillboardDistance = 400;
        }
        else
        {
            terrain.treeBillboardDistance = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Green Paint is grabbed");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has picked up green paint");
            player.hasGreen = true;
            Debug.Log("Player should now have green and can climb.");
        }
        gameObject.SetActive(false);
    }
}
