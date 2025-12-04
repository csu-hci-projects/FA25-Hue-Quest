using UnityEngine;

public class HoneycombTile : MonoBehaviour
{
    [Header("Tile Settings")]
    public bool isBreakable = true;
    public float breakDelay = 0.5f;        // time before tile breaks after stepped on
    public float respawnTime = 5f;         // time before tile respawns (0 = never)
    
    [Header("Visual Feedback")]
    public Color normalColor = new Color(1f, 0.9f, 0.3f);      // yellow
    public Color warningColor = new Color(1f, 0.5f, 0f);       // orange
    public float wobbleAmount = 0.1f;
    
    private MeshRenderer meshRenderer;
    private Collider walkCollider;
    private Collider triggerCollider;
    private Vector3 originalPosition;
    private bool isTriggered = false;
    private bool isBroken = false;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalPosition = transform.position;
        
        // Find the two colliders - one trigger, one not
        Collider[] colliders = GetComponents<Collider>();
        foreach (Collider col in colliders)
        {
            if (col.isTrigger)
                triggerCollider = col;
            else
                walkCollider = col;
        }
        
        if (meshRenderer != null)
            meshRenderer.material.color = normalColor;
    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name + " with tag: " + other.tag);
        Debug.Log("isBreakable: " + isBreakable + " | isTriggered: " + isTriggered + " | isBroken: " + isBroken);
        
        if (other.CompareTag("Player") && isBreakable && !isTriggered && !isBroken)
        {
            Debug.Log("Breaking tile!");
            isTriggered = true;
            StartCoroutine(BreakTile());
        }
    }
    
    System.Collections.IEnumerator BreakTile()
    {
        // Warning phase - change color and wobble
        if (meshRenderer != null)
            meshRenderer.material.color = warningColor;
        
        float elapsed = 0f;
        while (elapsed < breakDelay)
        {
            // Wobble effect
            float wobble = Mathf.Sin(elapsed * 20f) * wobbleAmount;
            transform.position = originalPosition + Vector3.up * wobble;
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        // Break - fall and disable
        isBroken = true;
        StartCoroutine(FallAndDisable());
        
        // Respawn if enabled
        if (respawnTime > 0)
        {
            yield return new WaitForSeconds(respawnTime);
            RespawnTile();
        }
    }
    
    System.Collections.IEnumerator FallAndDisable()
    {
        // Disable collision immediately
        if (walkCollider != null)
            walkCollider.enabled = false;
        if (triggerCollider != null)
            triggerCollider.enabled = false;
        
        // Animate falling
        float fallDuration = 1f;
        float elapsed = 0f;
        Vector3 startPos = transform.position;
        
        while (elapsed < fallDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fallDuration;
            transform.position = startPos + Vector3.down * (t * 10f);
            transform.Rotate(Vector3.forward * Time.deltaTime * 180f);
            yield return null;
        }
        
        // Hide the tile
        gameObject.SetActive(false);
    }
    
    void RespawnTile()
    {
        // Reset state
        gameObject.SetActive(true);
        transform.position = originalPosition;
        transform.rotation = Quaternion.identity;
        
        if (walkCollider != null)
            walkCollider.enabled = true;
        if (triggerCollider != null)
            triggerCollider.enabled = true;
        
        if (meshRenderer != null)
            meshRenderer.material.color = normalColor;
        
        isTriggered = false;
        isBroken = false;
    }
}