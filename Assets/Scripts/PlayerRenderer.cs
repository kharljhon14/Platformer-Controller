using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerRenderer : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(float velocity)
    {
        velocity = Input.GetAxisRaw("Horizontal");

        if (velocity > 0)
            sr.flipX = false;

        else if (velocity < 0)
            sr.flipX = true;
    }
}
