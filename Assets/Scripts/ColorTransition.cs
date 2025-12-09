using UnityEngine;
using System.Collections;

public class ColorTransition : MonoBehaviour
{
    [Header("Material Setup")]
    public Renderer hubRenderer;      // The icosphere
    public int materialIndex;         // Which region this script controls
    public Color unlockedColor;       // e.g. yellow, red, green, etc.
    public float fadeDuration = 10f;

    private Material runtimeMat;
    private readonly Color greyColor = Color.grey;
    public string unlockKey;          // e.g. "YellowUnlocked"
    public string fadeKey;            // e.g. "FadeYellowNextLoad"

    void Start()
    {
        // Access the correct material slot
        Material[] mats = hubRenderer.materials;
        runtimeMat = new Material(mats[materialIndex]);
        mats[materialIndex] = runtimeMat;
        hubRenderer.materials = mats;

        bool isUnlocked = PlayerPrefs.GetInt(unlockKey, 0) == 1;
        bool mustFade = PlayerPrefs.GetInt(fadeKey, 0) == 1;
        Debug.Log(unlockKey +" isUnlocked: " + isUnlocked);
        Debug.Log(fadeKey + " mustFade: " + mustFade);
        if (isUnlocked && mustFade)
        {
            runtimeMat.color = greyColor;
            Debug.Log("Start: " + greyColor);
            Debug.Log("Target: " + unlockedColor);
            StartCoroutine(FadeTo(unlockedColor));
            PlayerPrefs.SetInt(fadeKey, 0);
            PlayerPrefs.Save();
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

    IEnumerator FadeTo(Color target)
    {
        Color start = greyColor;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            //Debug.Log( unlockKey + " t: " + t);

            runtimeMat.color = Color.Lerp(start, target, t / fadeDuration);
            //Debug.Log("Color: " + runtimeMat.color);
            yield return null;
        }

        runtimeMat.color = target;
    }
}
