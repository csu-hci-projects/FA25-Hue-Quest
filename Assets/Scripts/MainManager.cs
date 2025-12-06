using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public bool hasBlue = false;
    public bool hasRed = false;
    public bool hasGreen = false;
    public bool hasYellow = false;
    public bool hasPurpule = false;
    public bool hasOrange = false;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
