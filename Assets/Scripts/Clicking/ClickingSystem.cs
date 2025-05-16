using System;
using UnityEngine;
using Components.Clicking;
using JetBrains.Annotations;
using UnityEngine.InputSystem;
namespace Systems.Clicking
{
    
public abstract class ClickingSystem : SystemBase
{
    public static Action<GameObject, ClickingComponent> ClickedAction = delegate { };
    

    private void Start()
    {
        ClickingComponent.ComponentUpdate += CompUpdate;
    }

    private static void OnClick(PlayerInput playerInput)
    {
        if (!playerInput.TryGetComponent<ClickingComponent>(out ClickingComponent comp))
            return;
        TryClick(comp, playerInput);
    }
    
    public static void TryClick(ClickingComponent comp, [CanBeNull] PlayerInput playerInput)
    {
        if (!playerInput && !comp.TryGetComponent<PlayerInput>(out playerInput))
            return;
        var clickedOn = playerInput.actions["point"].ReadValue<Vector2>();
        var clickHit = Physics2D.Raycast(clickedOn, Vector2.zero);
        if (!clickHit) return;
        
        ClickedAction.Invoke(clickHit.collider.gameObject, comp);
    }
    
    private void CompUpdate(ClickingComponent comp)
    {
        comp.DigCooldown -= Time.deltaTime;
        comp.DigCooldown = Mathf.Max(comp.DigCooldown, 0);
    }
}

}