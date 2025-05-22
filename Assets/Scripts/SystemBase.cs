using System;using Systems;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Systems
{

public struct SystemCreated<T> where T : SystemBase<T>
{
    
}

public abstract class SystemBase<T> : MonoBehaviour, ISystem where T : SystemBase<T>
{
    private static Bootstrap _bootstrap;

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (!_instance)
                FindAnyObjectByType<SystemBase<T>>();
            if (!_instance)
                _instance = new GameObject(nameof(T)).AddComponent<T>();
            return _instance;
        }
    }

    private void Awake()
    {
        
    }
}
}