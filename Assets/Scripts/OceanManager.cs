using UnityEngine;

public class OceanManager : MonoBehaviour
{
    public Renderer hubRenderer;
    public Material[] runtimeMats;

    void Awake()
    {
        runtimeMats = hubRenderer.materials;
        //replace all materials with runtime instances
        for (int i = 0; i < runtimeMats.Length; i++)
        {
            runtimeMats[i] = new Material(runtimeMats[i]);
        }
        hubRenderer.materials = runtimeMats;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
