using UnityEngine;

public interface IPoolableObject
{
    void OnSpawn();
    void OnDespawn();   
}