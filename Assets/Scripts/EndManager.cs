using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    //[SerializeField] Camera playercam;
    //[SerializeField] Camera screencam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Quitgame()
    {
        Debug.Log("Exit Button Pressed");
        Application.Quit();
    }
    
    public void ReturnToHub()
    {
        Debug.Log("Return button pressed");
        SceneManager.LoadScene("HubWorld");
    }
}
