using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TileClick : MonoBehaviour
{
    private PlayerInput _playerInput;

    private InputAction _clickAction;
    private InputAction _pointAction;
    
    private Tilemap _tilemap;

    [SerializeField] private int digSpeed = 2;
    [SerializeField] private float digTime = 1f;
    private float _digCooldown = 0f;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();

        _clickAction = _playerInput.actions["click"];
        _pointAction = _playerInput.actions["point"];

        _tilemap = FindAnyObjectByType<Tilemap>();
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
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(_pointAction.ReadValue<Vector2>());
        var hit = _tilemap.GetTile(new Vector3Int((int)mousePos.x, (int)mousePos.y, 0)) as Tile;
        if (!hit) return;
        
        _digCooldown = digTime / digSpeed;
    }
}
