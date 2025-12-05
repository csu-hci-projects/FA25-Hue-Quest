using UnityEngine;

public class GreenTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Terrain terrain;
    [SerializeField] ColorManager player;
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip startSong;
    [SerializeField] AudioClip greenSong;
    void Start()
    {
        if (player.hasGreen)
        {
            audioManager.PlaySong(greenSong, 0);
        }
        else
        {
           audioManager.PlaySong(startSong, 0); 
        }

        if (player.hasGreen)
        {
            terrain.treeBillboardDistance = 400;
        }
        else
        {
            terrain.treeBillboardDistance = 5;
        }
        
    }



    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Green Paint is grabbed");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has picked up green paint");
            player.hasGreen = true;
            audioManager.PlaySong(greenSong,0);
            terrain.treeBillboardDistance = 400;
            Debug.Log("Player should now have green and can climb.");
        }
        gameObject.SetActive(false);
    }
}
