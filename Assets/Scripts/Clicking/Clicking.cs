using UnityEngine;
using UnityEngine.InputSystem;

namespace Clicking.Components
{
public class ClickingComponent : MonoBehaviour
{
    private PlayerInput _playerInput;

    public InputAction clickAction;
    public InputAction pointAction;

    [SerializeField] private int digSpeed = 2;
    [SerializeField] private float digTime = 1f;
    private float _digCooldown = 0f;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();

        clickAction = _playerInput.actions["click"];
        pointAction = _playerInput.actions["point"];
    }
    private void Update()
    {
        _digCooldown -= Time.deltaTime;
        _digCooldown = Mathf.Max(_digCooldown, 0);
    }
}
}
