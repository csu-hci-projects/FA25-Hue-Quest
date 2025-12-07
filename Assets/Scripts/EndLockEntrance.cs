using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLockEntrance : MonoBehaviour
{
    public MainManager mainManager;

    [SerializeField] BoxCollider entrance;

    [SerializeField] Canvas dialogue;

    void Start()
    {
        mainManager = GameObject.FindAnyObjectByType<MainManager>();
    }

    void Update()
    {
        if (hasAllColors())
        {
            entrance.enabled = true;
            dialogue.enabled = false;
        }
    }


    private bool hasAllColors()
    {
        if(mainManager.hasBlue && mainManager.hasGreen && mainManager.hasOrange && mainManager.hasRed && mainManager.hasYellow)
        {
            return true;
        } else
        {
            return false;
        }
    }

}
