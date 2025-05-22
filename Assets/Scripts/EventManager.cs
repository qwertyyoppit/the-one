using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static Dictionary<Type, Action<Component, List<int>/*event args*/>> subscribers = new();
    
    public void SubscribeEvent<T, V>(ref Action<Component, List<int>> function) where T : Component
    {
        // T V A S with{ 0 9999999999 12312}
        // 9ingerh Whince yu7 == Whince ugulhhuu ?? 2;//time to code-zinga//love at first glaze
        //the hosen __one__():walker whie
        // poiuhpouihpoiuhpoiuh[puoh[[[opuh[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
        subscribers.Add(typeof(T), function);
    }

    public void RaiseEvent<T, V>(T system, V args) where T : Component
    {
        
    }
}
