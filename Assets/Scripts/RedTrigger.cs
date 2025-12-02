using UnityEngine;

public class RedTrigger : MonoBehaviour
{
    public Material redMat;
    public Material brownMat;
    public Material caveMat;

    public GameObject lavaPlane;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Red Paint is grabbed");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has picked up red paint");
            ColorManager playerColorManager = other.gameObject.GetComponent<ColorManager>();
            playerColorManager.hasRed = true;
            Debug.Log("Player should now have red and can jump.");
            Debug.Log("Adding colors...");
            AddRedToLvl();
            Debug.Log("Colors should be added.");

            Debug.Log("Starting lava rise...");
            LavaRise();
        }
        gameObject.SetActive(false);
    }

    void AddRedToLvl()
    {

        GameObject[] redObjects = GameObject.FindGameObjectsWithTag("IsRed");
        GameObject[] brownObjects = GameObject.FindGameObjectsWithTag("IsBrown");
        GameObject[] caveObjects = GameObject.FindGameObjectsWithTag("IsCaveTexture");
        if (redObjects.Length > 0)
        {
            Debug.Log("red objects found");
            foreach (GameObject redobj in redObjects)
            {
                redobj.GetComponent<MeshRenderer>().material = redMat;
            }
            Debug.Log("all red objects found should now be red.");
        }
        if (brownObjects.Length > 0)
        {
            Debug.Log("brown objs found");
            foreach (GameObject brnobj in brownObjects)
            {
                brnobj.GetComponent<MeshRenderer>().material = brownMat;
            }
            Debug.Log("all brown objs found should now be brown.");
        }
        if (caveObjects.Length > 0)
        {
            Debug.Log("cavetexture objs found");
            foreach (GameObject caveobj in caveObjects)
            {
                caveobj.GetComponent<MeshRenderer>().material = caveMat;
            }
            Debug.Log("all cavetexture objs found should now be cavey.");
        }
        return;
    }

    void LavaRise()
    {
        if (lavaPlane != null)
        {
            LavaController lavaController = lavaPlane.GetComponent<LavaController>();
            if (lavaController != null)
            {
                lavaController.startRising();
            }
        }
    }
}
