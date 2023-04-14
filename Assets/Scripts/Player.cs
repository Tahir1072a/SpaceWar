using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float playerMoveSpeed;
    [Header("Borders")]
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;

    Vector2 rawInput;
    Vector2 minBounds,maxBounds;

    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    private void Start()
    {
        InitBounds();
    }
    void Update()
    {
        PlayerMovement();
    }
    void InitBounds()
    {
        Camera main = Camera.main;
        minBounds = main.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = main.ViewportToWorldPoint(new Vector2(1,1));
    }
    private void PlayerMovement()
    {
        Vector2 delta = rawInput * playerMoveSpeed * Time.deltaTime;
        Vector2 newPos = new();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
