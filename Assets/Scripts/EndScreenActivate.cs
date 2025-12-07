using Unity.VisualScripting;
using UnityEngine;

public class EndScreenActivate : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    [SerializeField] GameObject menu;

    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip endsong;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached ship, starting end screen...");
            playerCam.SetActive(false);
            menu.SetActive(true);
            audioManager.BGM = endsong;
        }
    }
}
