using UnityEngine;
using System.Collections.Generic;

public class ObjectPool<T> where T : Component, IPoolableObject
{
    private readonly Queue<T> _pool = new Queue<T>();
    private readonly T _prefab;

    public ObjectPool(T prefab, int initialSize)
    {
        _prefab = prefab;
        for (int i = 0; i < initialSize; i++)
        {
            AddObjectToPool();
        }
    }

    private void AddObjectToPool()
    {
        var obj = Object.Instantiate(_prefab);
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }

    public T Get()
    {
        if (_pool.Count == 0)
        {
            AddObjectToPool();
        }

        T obj = _pool.Dequeue();
        obj.gameObject.SetActive(true);
        obj.OnSpawn();
        return obj;
    }

    public void ReturnToPool(T obj)
    {
        obj.OnDespawn();
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
}
