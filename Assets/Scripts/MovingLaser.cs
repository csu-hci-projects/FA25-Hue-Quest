using UnityEngine;

public class MovingLaser : MonoBehaviour
{
    [Header("Respawn Settings")]
    public Transform respawnPoint;  // drag your respawn empty GameObject here
    
    [Header("Movement Settings")]
    public float moveSpeed = 2f;           // how fast laser moves
    public float minHeight = 0f;           // bottom position (world Y coordinate)
    public float maxHeight = 10f;          // top position (world Y coordinate)
    public bool startMovingUp = true;      // initial direction
    
    private bool movingUp;
    
    void Start()
    {
        movingUp = startMovingUp;
    }
    
    void Update()
    {
        // Move up and down using world position
        Vector3 currentPos = transform.position;
        float newY = currentPos.y;
        
        if (movingUp)
        {
            newY += moveSpeed * Time.deltaTime;
            if (newY >= maxHeight)
            {
                newY = maxHeight;
                movingUp = false;
            }
        }
        else
        {
            newY -= moveSpeed * Time.deltaTime;
            if (newY <= minHeight)
            {
                newY = minHeight;
                movingUp = true;
            }
        }
        
        transform.position = new Vector3(currentPos.x, newY, currentPos.z);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit moving laser! Respawning...");
            
            if (respawnPoint != null)
            {
                // Teleport player to respawn point
                CharacterController controller = other.GetComponent<CharacterController>();
                if (controller != null)
                {
                    controller.enabled = false;  // disable to teleport
                    other.transform.position = respawnPoint.position;
                    controller.enabled = true;   // re-enable
                }
                else
                {
                    other.transform.position = respawnPoint.position;
                }
            }
        }
    }
}