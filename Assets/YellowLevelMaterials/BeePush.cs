using UnityEngine;
using System.Collections;

public class BeePush : MonoBehaviour
{
    public float pushForce = 150f;  // much stronger
    public float pushUpwardForce = 20f;
    private bool canPush = true;
    private float pushCooldown = 1f;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && canPush)
        {
            canPush = false;
            
            ThirdPersonMovement movement = collision.gameObject.GetComponent<ThirdPersonMovement>();
            CharacterController controller = collision.gameObject.GetComponent<CharacterController>();
            
            if (movement != null && controller != null)
            {
                // Calculate knockback direction
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
                pushDirection.y = 0; // keep horizontal
                pushDirection = pushDirection.normalized;
                
                // Add upward force
                Vector3 totalForce = pushDirection * pushForce + Vector3.up * pushUpwardForce;
                
                StartCoroutine(ApplyKnockback(movement, controller, totalForce));
            }
            
            StartCoroutine(ResetPushCooldown());
        }
    }
    
    IEnumerator ApplyKnockback(ThirdPersonMovement movement, CharacterController controller, Vector3 force)
    {
        // Briefly freeze input
        movement.isFrozen = true;
        
        // Apply the force in one big burst
        controller.Move(force * Time.deltaTime);
        
        // Keep applying diminishing force for a bit
        float duration = 0.5f;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float t = 1 - (elapsed / duration); // 1 to 0
            controller.Move(force * t * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        movement.isFrozen = false;
    }
    
    IEnumerator ResetPushCooldown()
    {
        yield return new WaitForSeconds(pushCooldown);
        canPush = true;
    }
}