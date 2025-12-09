using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public bool hasBlue = false;
    public bool hasRed = false;
    public bool hasGreen = false;
    public bool hasYellow = false;
    public bool hasPurpule = false;
    public bool hasOrange = false;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] public Slider musicSlider;
    [SerializeField] public Slider SFXSlider;
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

    public void toggleMenu(bool toggle)
    {
        if (Input.GetKeyDown(KeyCode.Escape) || toggle)
        {
            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
            }
            else
            {
                settingsMenu.SetActive(true);
            }
        }
    }

    public void resetAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene("HubWorld");
    }
}
