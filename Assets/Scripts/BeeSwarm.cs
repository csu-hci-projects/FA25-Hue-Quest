using UnityEngine;

public class BeeSwarm : MonoBehaviour
{
    [Header("Bee Settings")]
    public GameObject beePrefab;           // drag your bee model here
    public int numberOfBees = 20;          // how many bees to spawn
    public float spawnRadius = 30f;        // how far from this object to spawn
    
    [Header("Movement Settings")]
    public float moveSpeed = 2f;           // how fast bees fly
    public float rotationSpeed = 2f;       // how smoothly they turn
    public float changeDirectionTime = 3f; // how often they pick new direction
    public float minHeight = 5f;           // minimum flying height
    public float maxHeight = 15f;          // maximum flying height
    public float wanderRadius = 20f;       // how far they wander from spawn point
    
    private GameObject[] bees;
    private Vector3[] targetPositions;
    private float[] directionTimers;
    private Vector3[] spawnCenters;        // remember where each bee started
    
    void Start()
    {
        bees = new GameObject[numberOfBees];
        targetPositions = new Vector3[numberOfBees];
        directionTimers = new float[numberOfBees];
        spawnCenters = new Vector3[numberOfBees];
        
        // Spawn all the bees spread out
        for (int i = 0; i < numberOfBees; i++)
        {
            // Spawn in a large spread area
            Vector3 randomPos = transform.position + new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                Random.Range(minHeight, maxHeight),
                Random.Range(-spawnRadius, spawnRadius)
            );
            
            bees[i] = Instantiate(beePrefab, randomPos, Random.rotation);
            bees[i].transform.parent = transform;
            
            // Disable any physics components on the bee prefab
            Rigidbody rb = bees[i].GetComponent<Rigidbody>();
            if (rb != null)
            {
                Destroy(rb);
                Debug.Log("Removed Rigidbody from bee " + i);
            }
            
            spawnCenters[i] = randomPos; // remember spawn position
            targetPositions[i] = GetRandomPositionNear(spawnCenters[i]);
            directionTimers[i] = Random.Range(0f, changeDirectionTime);
        }
        
        Debug.Log("Spawned " + numberOfBees + " bees");
    }
    
    void Update()
    {
        for (int i = 0; i < numberOfBees; i++)
        {
            if (bees[i] == null) continue;
            
            // Count down timer
            directionTimers[i] -= Time.deltaTime;
            
            // Pick new random direction when timer hits 0
            if (directionTimers[i] <= 0f)
            {
                targetPositions[i] = GetRandomPositionNear(spawnCenters[i]);
                directionTimers[i] = changeDirectionTime + Random.Range(-1f, 1f);
                
                // Debug first bee
                if (i == 0)
                {
                    Debug.Log("Bee 0 new target: " + targetPositions[i] + " | Current pos: " + bees[i].transform.position);
                }
            }
            
            // Force clamp bee position to stay within bounds
            Vector3 currentPos = bees[i].transform.position;
            currentPos.y = Mathf.Clamp(currentPos.y, minHeight, maxHeight);
            bees[i].transform.position = currentPos;
            
            // Move toward target position
            Vector3 direction = (targetPositions[i] - bees[i].transform.position).normalized;
            bees[i].transform.position += direction * moveSpeed * Time.deltaTime;
            
            // Rotate to face movement direction
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                bees[i].transform.rotation = Quaternion.Slerp(bees[i].transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            
            // Check if close to target, pick new target
            if (Vector3.Distance(bees[i].transform.position, targetPositions[i]) < 1f)
            {
                targetPositions[i] = GetRandomPositionNear(spawnCenters[i]);
            }
        }
    }
    
    Vector3 GetRandomPositionNear(Vector3 center)
    {
        // Random horizontal position near center
        Vector3 randomPos = new Vector3(
            center.x + Random.Range(-wanderRadius, wanderRadius),
            Random.Range(minHeight, maxHeight), // completely random height within bounds
            center.z + Random.Range(-wanderRadius, wanderRadius)
        );
        
        return randomPos;
    }
}