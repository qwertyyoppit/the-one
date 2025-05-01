using UnityEngine;
using UnityEngine.InputSystem;

public class TileClick : MonoBehaviour
{
    private PlayerInput _playerInput;

    private InputAction _clickAction;
    private InputAction _pointAction;

    [SerializeField] private int digSpeed = 2;
    [SerializeField] private float digTime = 1f;
    private float _digCooldown = 0f;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();

        _clickAction = _playerInput.actions["click"];
        _pointAction = _playerInput.actions["point"];
    }
    private void Update()
    {
        _digCooldown -= Time.deltaTime;
        _digCooldown = Mathf.Max(_digCooldown, 0);

        if (_clickAction.IsPressed())
        {
            Click();
        }

    }

    private void Click()
    {
        if (_digCooldown > 0f) return;
        _digCooldown = digTime / digSpeed;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(_pointAction.ReadValue<Vector2>());
        var hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (!hit) return;
        hit.collider.GetComponent<Block>().Damage(10f);
    }
}
