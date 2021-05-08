using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerJump : Stats
{
    [Header("Jump")]
    [SerializeField] private float jumpForce;

    [Header("Jump Feel")]
    [SerializeField] private float hangTime;

    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;

    [field: SerializeField] UnityEvent<bool> OnYVelocityChange { get; set; }

    [Header("Flags and Stats")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private float hangTimer;

    protected override void Initialize()
    {
        base.Initialize();
    }

    private void Update()
    {
        IsPlayerGrounded();
        CheckForGround();
        OnYVelocityChange?.Invoke(isGrounded);
    }

    private bool IsPlayerGrounded()
    {
        return isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void CheckForGround()
    {
        if (isGrounded)
            hangTimer = hangTime;

        else
            hangTimer -= Time.deltaTime;
    }

    public void Jump()
    {
        if (hangTimer > 0)
        {
            player.rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void SmallJump()
    {
        if (rb2d.velocity.y > 0)
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * .4f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
