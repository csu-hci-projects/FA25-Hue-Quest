using UnityEngine;

public class BlueChecker : MonoBehaviour
{
    [SerializeField] ColorManager plyaer;

    // Update is called once per frame
    void Update()
    {
        if (plyaer.hasBlue)
        {
            Destroy(this.gameObject);
        }
    }
}
