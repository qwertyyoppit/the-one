using System;
using Systems;
using UnityEngine;
using Clicking.Components;

namespace Clicking.Systems
{
    
public abstract class ClickingSystem : SystemBase<ClickingSystem>
{
    public static Action<GameObject, ClickingComponent> ClickedAction = delegate { };

    public static void TryClick(ClickingComponent clicker)
    {
        var clickedOn = clicker.pointAction.ReadValue<Vector2>();
        var clickHit = Physics2D.Raycast(clickedOn, Vector2.zero);
        if (!clickHit) return;
        
        ClickedAction.Invoke(clickHit.collider.gameObject, clicker);
    }
}

}