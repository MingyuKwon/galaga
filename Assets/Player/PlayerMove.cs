using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    
    [Header("Padding")]
    [SerializeField] float rightPadding;
    [SerializeField] float leftPadding;
    [SerializeField] float upPadding;
    [SerializeField] float downPadding;

    [Header("speed")]
    [SerializeField] float speed = 10f;

    Rigidbody2D myRigidBody;
    Vector2 rawInput;
    
    Vector2 minBound;
    Vector2 maxBound;

    Shooter shooter;

     void Awake() 
    {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        InitBounds();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        shooter.isShooting = value.isPressed;
    }

    void Move()
    {
        Vector2 realInput = new Vector2(rawInput.x * speed * Time.deltaTime, rawInput.y * speed * Time.deltaTime);
        myRigidBody.velocity = realInput;

        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, minBound.x + leftPadding, maxBound.x - rightPadding);
        newPosition.y = Mathf.Clamp(newPosition.y, minBound.y + downPadding, maxBound.y - upPadding);
        transform.position = newPosition;
    }
}
