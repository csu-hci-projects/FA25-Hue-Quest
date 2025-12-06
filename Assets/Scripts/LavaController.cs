using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaController : MonoBehaviour
{
    private bool isRising = false;
    public float riseSpeed = 1f;

    [SerializeField] AudioManager audioManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRising)
        {
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;
        }
    }

    public void startRising()
    {
        isRising = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has hit lava, player should now be dead");
            //death music
            audioManager.Playdeath();
            //Add death scene script here?
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
