using UnityEngine;

public class PoolableObject : MonoBehaviour, IPoolableObject
{
    public void OnSpawn()
    {
        // Initialize the object
    }

    public void OnDespawn()
    {
        // Reset the object to its default state
    }
}
