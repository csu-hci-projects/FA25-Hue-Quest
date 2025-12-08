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
        instance.hasBlue = PlayerPrefs.GetInt("BlueUnlock", 0) == 1;
        instance.hasRed = PlayerPrefs.GetInt("RedUnlock", 0) == 1;
        instance.hasGreen = PlayerPrefs.GetInt("GreenUnlock", 0) == 1;
        instance.hasYellow = PlayerPrefs.GetInt("YellowUnlock", 0) == 1;
        instance.hasPurpule = PlayerPrefs.GetInt("PurpleUnlock", 0) == 1;
        instance.hasOrange = PlayerPrefs.GetInt("OrangeUnlock", 0) == 1;
        DontDestroyOnLoad(gameObject);
    }
}
