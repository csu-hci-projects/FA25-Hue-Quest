using UnityEngine;

public class BlueTrigger : MonoBehaviour
{
    [SerializeField] Material bluemat;
    [SerializeField] Material greymat;
    [SerializeField] GameObject water;
    [SerializeField] ColorManager player;
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip startSong;
    [SerializeField] AudioClip blueSong;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player.hasBlue)
        {
            audioManager.PlaySong(blueSong, 0);
            water.GetComponent<MeshRenderer>().material = bluemat;
        }
        else
        {
           audioManager.PlaySong(startSong, 0); 
           water.GetComponent<MeshRenderer>().material = greymat;
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Blue Paint is grabbed");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has picked up blue paint");
            player.hasBlue = true;
            if (MainManager.instance != null)
            {
                MainManager.instance.hasBlue = true;
            }
            audioManager.PlaySong(blueSong,0);
            water.GetComponent<MeshRenderer>().material = bluemat;
            Debug.Log("Player should now have green and walk on blue.");
        }
        gameObject.SetActive(false);
    }
}
