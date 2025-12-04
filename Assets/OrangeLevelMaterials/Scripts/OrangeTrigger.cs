using UnityEngine;
using System.Collections;

public class OrangeTrigger : MonoBehaviour
{

    public Material desertSandMaterial; // Orange-ish color
    public Terrain terrain;

    public GameObject dashMessageUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColorManager playerColorManager = other.gameObject.GetComponent<ColorManager>();
            playerColorManager.hasOrange = true;

            // Change terrain color
            if (terrain != null)
                terrain.materialTemplate = desertSandMaterial;

            if (dashMessageUI != null)
                StartCoroutine(ShowDashMessageAndDestroy());


            // Destroy the sphere after a tiny delay (or just deactivate it)
            // delay 0.1 sec ensures coroutine starts
        }
    }

    private IEnumerator ShowDashMessageAndDestroy()
    {
        if (dashMessageUI != null)
            dashMessageUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        if (dashMessageUI != null)
            dashMessageUI.SetActive(false);

        Destroy(gameObject); // destroy sphere after message disappears
    }
}
