using UnityEngine;
using System.Collections;


public class YellowColorFadeTest : MonoBehaviour
{
   [Header("Material Setup")]
    public Renderer hubRenderer;      // The icosphere
    public int materialIndex;         // Which region this script controls
    public Color unlockedColor;       // e.g. yellow, red, green, etc.
    public float fadeDuration = 10f;

    MainManager mainManager;

    private Material runtimeMat;
    private readonly Color greyColor = Color.grey;
    //public string unlockKey;          // e.g. "YellowUnlocked"
    //public string fadeKey;            // e.g. "FadeYellowNextLoad"

    void Start()
    {
        // Access the correct material slot
        Material[] mats = hubRenderer.materials;
        runtimeMat = new Material(mats[materialIndex]);
        mats[materialIndex] = runtimeMat;
        hubRenderer.materials = mats;

        //end - mainManager
        mainManager = GameObject.FindAnyObjectByType<MainManager>();

        //bool isUnlocked = PlayerPrefs.GetInt(unlockKey, 0) == 1;
        //bool mustFade = PlayerPrefs.GetInt(fadeKey, 0) == 1;

        //end - isUnlocked = hasAllColors;
        //end - mustFade = true;
        bool isUnlocked = hasYellowColor();
        bool mustFade = true;

        if (isUnlocked && mustFade)
        {
            runtimeMat.color = greyColor;
            StartCoroutine(FadeTo(unlockedColor));
            //PlayerPrefs.SetInt(fadeKey, 0);
            //PlayerPrefs.Save();

            //end - set mustfade
            mustFade = false;
        }
        else if (isUnlocked)
        {
            runtimeMat.color = unlockedColor;
        }
        else
        {
            runtimeMat.color = greyColor;
        }
    }

    private bool hasYellowColor()
    {
        if(mainManager.hasYellow)
        {
            return true;
        } else
        {
            return false;
        }
    }

    IEnumerator FadeTo(Color target)
    {
        Color start = runtimeMat.color;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            runtimeMat.color = Color.Lerp(start, target, t / fadeDuration);
            yield return null;
        }

        runtimeMat.color = target;
    }
}
