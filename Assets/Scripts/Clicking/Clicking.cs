using Systems.Clicking;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Components.Clicking
{
public class ClickingComponent : ComponentBase<ClickingComponent>
{
    public int DigSpeed = 2;
    public float DigTime = 1f;
    public float DigCooldown;
}
}
