using UnityEngine;

public class RedEntranceShut : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Collider entranceCollider;

    private bool isShut = false;
    void Start()
    {
        mainManager = GameObject.FindAnyObjectByType<MainManager>();
        entranceCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShut == false && MainManager.instance != null && MainManager.instance.hasRed)
        {
            if (entranceCollider != null)
            {
                entranceCollider.enabled = false;
                isShut = true;
            }
        }
    }
}
