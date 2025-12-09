using UnityEngine;

public class RedEntranceColor : MonoBehaviour
{
    [SerializeField] Material redMat;
    private bool turnedRed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turnedRed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.instance != null && turnedRed == false && MainManager.instance.hasRed)
        {
            GetComponent<Renderer>().material = redMat;
            turnedRed = true;
        }
    }
}
