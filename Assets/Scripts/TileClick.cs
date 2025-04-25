using UnityEngine;
using UnityEngine.InputSystem;

public class TileClick : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction clickAction;
    private InputAction pointAction;

    [SerializeField] private int digSpeed = 2;
    [SerializeField] readonly private float digTime = 1f;
    private float digCooldown = 0f;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        clickAction = playerInput.actions["click"];
        pointAction = playerInput.actions["point"];
    }
    private void Update()
    {
        digCooldown -= Time.deltaTime;
        digCooldown = Mathf.Max(digCooldown, 0);

        if (clickAction.IsPressed())
        {
            Click();
        }

    }

    private void Click()
    {
        if (digCooldown > 0f) return;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(pointAction.ReadValue<Vector2>());
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, default, 1 << 3);
        if (hit.collider == null) return;
        if (!hit.transform.TryGetComponent<Block>(out Block blockScript)) return;
        blockScript.Damage(10f);
        digCooldown = digTime / digSpeed;
    }
}
