using UnityEngine;
using System.Collections;


public class OceanColorTransition : MonoBehaviour
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

    //color fix
    private OceanManager oceanManager;

    void Start()
    {
        // Access the correct material slot
        //Material[] mats = hubRenderer.materials;
        //runtimeMat = new Material(mats[materialIndex]);
        //mats[materialIndex] = runtimeMat;
        //hubRenderer.materials = mats;
        oceanManager = GameObject.FindAnyObjectByType<OceanManager>();
        runtimeMat = oceanManager.runtimeMats[materialIndex];

        bool isUnlocked = PlayerPrefs.GetInt(unlockKey, 0) == 1;
        bool mustFade = PlayerPrefs.GetInt(fadeKey, 0) == 1;

        if (isUnlocked && mustFade)
        {
            runtimeMat.color = greyColor;
            //testing
            Debug.Log("color is " + unlockedColor + ", isUnlocked and mustFade, starting coroutine...");
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
