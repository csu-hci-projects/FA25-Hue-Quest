using UnityEngine;
using System.Collections;

public class OrangeTrigger : MonoBehaviour
{
    public Material desertSandMaterial;
    public Terrain terrain;
    public GameObject dashMessageUI;

    private bool triggered = false; // ensures it only triggers once

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return; // prevent multiple triggers

        if (other.CompareTag("Player"))
        {
            triggered = true;

            // Disable collider so it can't trigger again
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;

            // Give player the orange power
            ColorManager playerColorManager = other.gameObject.GetComponent<ColorManager>();
            if (playerColorManager != null)
                playerColorManager.hasOrange = true;

            // Change terrain color
            if (terrain != null && desertSandMaterial != null)
                terrain.materialTemplate = desertSandMaterial;

            // Show dash message UI
            if (dashMessageUI != null)
                StartCoroutine(ShowDashMessageAndDestroy());
        }
    }

    private IEnumerator ShowDashMessageAndDestroy()
    {
        dashMessageUI.SetActive(true);

        yield return new WaitForSeconds(3f);

        dashMessageUI.SetActive(false);

        Destroy(gameObject);
    }
}
