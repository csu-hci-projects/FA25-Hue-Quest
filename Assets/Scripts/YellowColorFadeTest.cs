using UnityEngine;
using System.Collections;
using NUnit.Framework;


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

    bool isColored;
    //public string unlockKey;          // e.g. "YellowUnlocked"
    //public string fadeKey;            // e.g. "FadeYellowNextLoad"

    void Start()
    {
        // Access the correct material slot
        //Material[] mats = hubRenderer.materials;
        //runtimeMat = new Material(mats[materialIndex]);
        //mats[materialIndex] = runtimeMat;
        //hubRenderer.materials = mats;

        //end - mainManager
        mainManager = GameObject.FindAnyObjectByType<MainManager>();

        isColored = false;
    }

    void Update()
    {
        //move color transition here?
        if (!isColored && hasRedColor())
        {
            Debug.Log("Red unlocked, continent is now " + unlockedColor);
            //runtimeMat.color = unlockedColor;
            hubRenderer.materials[materialIndex].color = unlockedColor;
            isColored = true;
        }
        else
        {
            //runtimeMat.color = greyColor;
            hubRenderer.materials[materialIndex].color = greyColor;
        }

    }

    private bool hasRedColor()
    {
        if(mainManager.hasRed)
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
