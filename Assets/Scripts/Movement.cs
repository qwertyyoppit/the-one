using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private Stats Stats;
    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 moveInput = Vector2.zero;
    private Vector2 movement = Vector2.zero;

    private RaycastHit2D[] collisions;
    private RaycastHit2D[] collisionsBottom;
    private RaycastHit2D[] collisionsTop;
    private RaycastHit2D[] collisionsLeft;  
    private RaycastHit2D[] collisionsRight;
    [SerializeField, Range(0.005f, 0.25f)] private float collisionCheckDistance = 0.05f;

    private State grounded;
    private State jumping;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        Stats = GetComponent<Entity>().Stats;
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["move"];
        jumpAction = playerInput.actions["jump"];

        grounded = new State();
        jumping = new State();

        grounded.enabled += _ => jumping.Active = false;
        jumping.enabled += _ => grounded.Active = false;
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>().normalized;

        CheckCollisions();
        CheckJump();
        ApplyMovement();
    }

    private void CheckCollisions()
    {
        collisionsBottom = Physics2D.BoxCastAll(new Vector2(transform.position.x, box.bounds.min.y), new Vector2(box.size.x, 0.01f), transform.rotation.z, -Vector2.up, collisionCheckDistance)
            .Where<RaycastHit2D>(hit => hit.collider != box).ToArray();
        collisionsTop = Physics2D.BoxCastAll(new Vector2(transform.position.x, box.bounds.max.y), new Vector2(box.size.x, 0.01f), transform.rotation.z, Vector2.up, collisionCheckDistance)
            .Where<RaycastHit2D>(hit => hit.collider != box).ToArray();
        collisionsLeft = Physics2D.BoxCastAll(new Vector2(box.bounds.min.x, transform.position.y), new Vector2(0.01f, box.size.y), transform.rotation.z, -Vector2.right, collisionCheckDistance)
            .Where<RaycastHit2D>(hit => hit.collider != box).ToArray();
        collisionsRight = Physics2D.BoxCastAll(new Vector2(box.bounds.max.x, transform.position.y), new Vector2(0.01f, box.size.y), transform.rotation.z, Vector2.right, collisionCheckDistance)
            .Where<RaycastHit2D>(hit => hit.collider != box).ToArray();
        if (collisionsBottom.Length > 0)
        {
            movement.y = Mathf.Max(0, movement.y);
            transform.position.Set(transform.position.x, collisionsBottom[0].point.y - transform.position.y, transform.position.z);
            grounded.Active = true;
        }
        else
        {
            grounded.Active = false;
        }
        if (collisionsTop.Length > 0)
        {
            movement.y = Mathf.Min(0, movement.y);
            transform.position.Set(transform.position.x, collisionsTop[0].point.y - transform.position.y, transform.position.z);
        }
        if (collisionsLeft.Length > 0)
        {
            moveInput.x = Mathf.Max(0, moveInput.x);
            transform.position.Set(collisionsLeft[0].point.x - transform.position.x, transform.position.y, transform.position.z);
        }
        if (collisionsRight.Length > 0)
        {
            moveInput.x = Mathf.Min(0, moveInput.x);
            transform.position.Set(collisionsRight[0].point.x - transform.position.x, transform.position.y, transform.position.z);
        }

        if (!grounded.Active)
        {
            movement.y += Physics2D.gravity.y * Time.deltaTime;
            movement.y = Mathf.Max(movement.y, -30);
        }
    }

    private void CheckJump()
    {
        if (!jumpAction.triggered) return;
        if (!grounded.Active) return;

        grounded.Active = false;
        movement.y = Stats.JumpHeight;
    }

    private void ApplyMovement()
    {
        movement.x = Mathf.Round(moveInput.x) * Stats.MoveSpeed;
        
        transform.Translate(movement * Time.deltaTime);
    }
}
