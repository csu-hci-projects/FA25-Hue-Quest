using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] public bool hasBlue = false;
    [SerializeField] public bool hasRed = false;
    [SerializeField] public bool hasGreen = false;
    [SerializeField] public bool hasYellow = false;
    [SerializeField] public bool hasPurpule = false;
    [SerializeField] public bool hasOrange = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (MainManager.instance != null)
        {
           hasBlue = MainManager.instance.hasBlue;
           hasRed = MainManager.instance.hasRed;
           hasGreen = MainManager.instance.hasGreen;
           hasYellow = MainManager.instance.hasYellow;
           hasPurpule = MainManager.instance.hasPurpule;
           hasOrange = MainManager.instance.hasOrange; 
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
