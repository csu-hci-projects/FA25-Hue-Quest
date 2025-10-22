using UnityEngine;
using System.Linq;

public class Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IPlanet currentPlanet;
    [SerializeField] Player player;

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
        player.Activate();
    }

    public void Quitgame()
    {
        Debug.Log("Exit Button Pressed");
        Application.Quit();
    }
    
    public void Settings()
    {
        Debug.Log("Settings Button Pressed");
    }

}
