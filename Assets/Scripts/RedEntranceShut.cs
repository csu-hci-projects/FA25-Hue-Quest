using UnityEngine;

public class RedEntranceShut : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Collider entranceCollider;
    [SerializeField] MainManager mainManager;

    private bool isShut = false;
    void Start()
    {
        entranceCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShut == false && mainManager != null && mainManager.hasRed)
        {
            if (entranceCollider != null)
            {
                entranceCollider.enabled = false;
                isShut = true;
            }
        }
    }
}
