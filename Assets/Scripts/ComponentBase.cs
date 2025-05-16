using System;
using UnityEngine;

namespace Components
{
public class ComponentBase<TDerived> : MonoBehaviour where TDerived : ComponentBase<TDerived>
{
    public static Action<TDerived> ComponentUpdate = delegate { };
    public bool FirstFrame = true;
    

    public void Dirty<T>(T component) where T : TDerived
    {
        ComponentUpdate.Invoke(component);
    }
}
}
