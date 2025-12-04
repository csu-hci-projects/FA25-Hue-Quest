using UnityEngine;

public class BasePlanet : MonoBehaviour, IPlanet
{
    [SerializeField] float gravity = 0;

    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
    }


    void Start()
    {
        
    }

    public float getGravity()
    {
        return gravity;
    }

}
