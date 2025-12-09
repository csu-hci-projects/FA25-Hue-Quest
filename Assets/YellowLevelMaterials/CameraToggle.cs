using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    [Header("Cameras")]
    public Camera normalCamera;  // your main follow camera
    public Camera wideCamera;    // the zoomed out tower camera
    
    private bool isWideView = false;
    public bool canToggle = false;  // whether player has unlocked the ability
    
    void Start()
    {
        // Make sure normal camera starts active
        if (normalCamera != null)
            normalCamera.enabled = true;
        
        if (wideCamera != null)
            wideCamera.enabled = false;
    }
    
    void Update()
    {
        // Toggle with C key only if unlocked
        if (Input.GetKeyDown(KeyCode.C) && canToggle)
        {
            isWideView = !isWideView;
            
            if (normalCamera != null)
                normalCamera.enabled = !isWideView;
            
            if (wideCamera != null)
                wideCamera.enabled = isWideView;
        }
    }
    
    // Reset to normal camera
    public void ResetToNormalCamera()
    {
        isWideView = false;
        
        if (normalCamera != null)
            normalCamera.enabled = true;
        
        if (wideCamera != null)
            wideCamera.enabled = false;
    }
}