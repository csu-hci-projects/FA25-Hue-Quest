using UnityEngine;

public class LaserHazard : MonoBehaviour
{
    [Header("Respawn Settings")]
    public Transform respawnPoint;  // drag your empty GameObject here
    
    [Header("Movement Settings (Optional)")]
    public bool shouldMove = false;
    public Vector3 moveDirection = Vector3.up;  // direction to move
    public float moveSpeed = 2f;
    public float moveDistance = 5f;  // how far to move before reversing
    
    private Vector3 startPosition;
    private bool movingForward = true;
    
    void Start()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        if (shouldMove)
        {
            // Move back and forth
            float step = moveSpeed * Time.deltaTime;
            
            if (movingForward)
            {
                transform.position += moveDirection.normalized * step;
                
                if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
                {
                    movingForward = false;
                }
            }
            else
            {
                transform.position -= moveDirection.normalized * step;
                
                if (Vector3.Distance(startPosition, transform.position) <= 0.1f)
                {
                    movingForward = true;
                }
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit laser! Respawning...");
            
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