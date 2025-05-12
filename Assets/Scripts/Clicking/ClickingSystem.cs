using System;
using UnityEngine;

namespace Clicking.Clicking
{
    
public abstract class ClickingSystem
{
    public static Action<GameObject, ClickingComponent> ClickedAction = delegate { };

    public static void TryClick(ClickingComponent clicker)
    {
        var clickedOn = clicker.PointAction.ReadValue<Vector2>();
        var clickHit = Physics2D.Raycast(clickedOn, Vector2.zero);
        if (!clickHit) return;
        
        ClickedAction.Invoke(clickHit.collider.gameObject, clicker);
    }
}

}