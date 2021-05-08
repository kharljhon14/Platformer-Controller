using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : Stats
{
    [Header("Movement")]
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    //Make a SO for the variables

    [field: SerializeField] public UnityEvent<float> OnVelocityChange { get; set; }

    [Header("Flags and Stats")]
    [SerializeField] private float currentVelocity;
    [SerializeField] private float moveDirection;

    protected override void Initialize()
    {
        base.Initialize();
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(currentVelocity);
        
        // Apply current velocity to the rigidbody velocity
        player.rb2d.velocity = new Vector2(currentVelocity * moveDirection, rb2d.velocity.y);
    }

    public void MovePlayer(float horizontalInput)
    {
        // Check if there is an input
        if(Mathf.Abs(horizontalInput) > 0)
        {
            // Check if the player changes direction set current velocity to zero
            if (horizontalInput != moveDirection)
                currentVelocity = 0;

            moveDirection = horizontalInput;
        }

        currentVelocity = CalaculateSpeed(horizontalInput); 
    }
    
    private float CalaculateSpeed(float horizontalInput)
    {
        // Increase velocity by the acceleration rate
        if (Mathf.Abs(horizontalInput) > 0)
            currentVelocity += acceleration * Time.deltaTime;

        // Decrease velocity by the deceleration rate
        else
            currentVelocity -= deceleration * Time.deltaTime;

        return Mathf.Clamp(currentVelocity, 0, maxSpeed);
    }
}
