using System;
using Systems;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private Bootstrap _instance;

    public Bootstrap Instance
    {
        get
        {
            if (!_instance)
                _instance = new GameObject().AddComponent<Bootstrap>();
            return _instance;
        }
    }

    private void Awake()
    {
        
    }
}
