using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YellowTrigger : MonoBehaviour
{
    [SerializeField] ColorManager player;
    [SerializeField] Material skyboxMaterial;      // drag your skybox material here
    [SerializeField] Material honeycombGroundMaterial;  // drag honeycomb ground material here
    [SerializeField] GameObject abilityMessageUI;  // drag your UI Text/Panel here
    
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
        
        // Hide ability message at start
        if (abilityMessageUI != null)
        {
            abilityMessageUI.SetActive(false);
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
            
            // Show ability message
            if (abilityMessageUI != null)
            {
                StartCoroutine(ShowAbilityMessage());
            }
            
            Debug.Log("Player should now have yellow and can climb walls.");
        }
    }
    
    IEnumerator ShowAbilityMessage()
    {
        abilityMessageUI.SetActive(true);
        yield return new WaitForSeconds(10f);
        abilityMessageUI.SetActive(false);
        
        // Now disable the trigger
        gameObject.SetActive(false);
    }
}