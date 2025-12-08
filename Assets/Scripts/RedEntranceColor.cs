using UnityEngine;

public class RedEntranceColor : MonoBehaviour
{
    [SerializeField] Material redMat;
    private bool turnedRed;

    public MainManager mainManager;
    public MeshRenderer renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainManager = GameObject.FindAnyObjectByType<MainManager>();
        renderer = GetComponent<MeshRenderer>();
        turnedRed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!turnedRed && (mainManager.hasRed == true))
        {
            renderer.material = redMat;
            turnedRed = true;
        }
    }
}
