using UnityEngine;

public class RedEntranceColor : MonoBehaviour
{
    [SerializeField] Material redMat;
    private bool turnedRed = false;

    [SerializeField] MainManager mainManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (mainManager != null && turnedRed == false && mainManager.hasRed)
        {
            this.GetComponent<MeshRenderer>().material = redMat;
            turnedRed = true;
        }
    }
}
