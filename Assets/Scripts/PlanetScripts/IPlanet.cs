using UnityEngine;

public interface IPlanet
{
    Vector3 Position { get; }
    GameObject gameObject { get; }
    float getGravity();
}