using UnityEngine;

public class ForceRedAbility : MonoBehaviour
{
    void Start()
    {
        if (MainManager.instance != null)
        {
            MainManager.instance.hasRed = true;
        }

        ColorManager player = FindObjectOfType<ColorManager>();
        if (player != null)
        {
            player.hasRed = true;
        }

    }
}
