using UnityEngine;

public class YellowTrigger : MonoBehaviour
{
    [SerializeField] ColorManager player;
    [SerializeField] Material skyboxMaterial;      // drag your skybox material here
    [SerializeField] Material honeycombGroundMaterial;  // drag honeycomb ground material here
    
    private Color blackAndWhite = new Color(0.5f, 0.5f, 0.5f); // grayscale for skybox
    private Color towerBlackAndWhite = new Color(1f, 1f, 1f);  // pure white for tower
    private Color honeyYellow = new Color(248f/255f, 194f/255f, 0f/255f); // rgba(248, 194, 0) - bright for skybox
    private Color darkYellow = new Color(180f/255f, 140f/255f, 0f/255f);  // darker yellow for tower
    
    void Start()
    {
        // Set skybox to black and white at start
        if (skyboxMaterial != null)
        {
            skyboxMaterial.SetColor("_Tint", blackAndWhite);
        }
        
        // Set tower walls to white at start
        if (honeycombGroundMaterial != null)
        {
            honeycombGroundMaterial.color = towerBlackAndWhite;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Yellow Paint is grabbed");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has picked up yellow paint");
            player.hasYellow = true;
            if (MainManager.instance != null)
            {
                MainManager.instance.hasYellow = true;
            }
            
            // Change skybox to bright yellow!
            if (skyboxMaterial != null)
            {
                skyboxMaterial.SetColor("_Tint", honeyYellow);
            }
            
            // Change tower walls to dark yellow!
            if (honeycombGroundMaterial != null)
            {
                honeycombGroundMaterial.color = darkYellow;
            }
            
            Debug.Log("Player should now have yellow and can climb walls.");
        }
        gameObject.SetActive(false);
    }
}