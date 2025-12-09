using UnityEngine;
using System.Collections;

public class OrangeTrigger : MonoBehaviour
{
    public Material desertSandMaterial;
    public Terrain terrain;
    public GameObject dashMessageUI;
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip startSong;
    [SerializeField] AudioClip orangeSong;

    private bool triggered = false; // ensures it only triggers once

    void Start()
    {
        audioManager.PlaySong(startSong, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return; // prevent multiple triggers

        if (other.CompareTag("Player"))
        {
            triggered = true;
            audioManager.PlaySong(orangeSong,0);

            // Disable collider so it can't trigger again
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;

            // Give player the orange power
            ColorManager playerColorManager = other.gameObject.GetComponent<ColorManager>();
            if (playerColorManager != null)
                playerColorManager.hasOrange = true;

            if (MainManager.instance != null)
            {
                MainManager.instance.hasOrange = true;
            }

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
