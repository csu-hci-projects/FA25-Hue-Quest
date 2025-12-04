using UnityEngine;
using System.Linq;

public class Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IPlanet currentPlanet;
    [SerializeField] PlanetGravity player;
    [SerializeField] HubCamera playerCam;

    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip song;

    void Start()
    {
        IPlanet[] allObjectsWithInterface = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IPlanet>().ToArray();
        if (allObjectsWithInterface.Length > 0)
        {
            Debug.Log(allObjectsWithInterface);
            currentPlanet = allObjectsWithInterface[0];
            Debug.Log("Set planet " + currentPlanet + " as current planet");
        }
        player.setGravityTarget(currentPlanet);
        audioManager.PlaySong(song, 20);
    }

    void Update()
    {
    }

    public IPlanet getPlanet()
    {
        return currentPlanet;
    }

    public void Startgame()
    {
        Debug.Log("Start Button Pressed");
        audioManager.PlaySelect();
        playerCam.Activate();
    }

    public void Quitgame()
    {
        Debug.Log("Exit Button Pressed");
        audioManager.PlaySelect();
        Application.Quit();
    }
    
    public void Settings()
    {
        audioManager.PlaySelect();
        audioManager.toggleMenu(true);
        Debug.Log("Settings Button Pressed");
    }

}
