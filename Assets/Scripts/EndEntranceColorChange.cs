using Unity.VisualScripting;
using UnityEngine;

public class EndEntranceColorChange : MonoBehaviour
{
    //[SerializeField] Material startMat;
    [SerializeField] Material colorMat;

    public bool hasBeenColored = false;
    public MainManager mainManager;

    public MeshRenderer renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainManager = GameObject.FindAnyObjectByType<MainManager>();
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAllColors() && !hasBeenColored)
        {
            renderer.material = colorMat;
            hasBeenColored = true;
        }
    }

    private bool hasAllColors()
    {
        if(mainManager.hasBlue && mainManager.hasGreen && mainManager.hasOrange && mainManager.hasRed && mainManager.hasYellow)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
