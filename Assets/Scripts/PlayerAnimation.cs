using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void AnimatePlayer(float velocity)
    {
        SetRunningAnimation(velocity > 0);
    }

    public void SetJumpingAnimation(bool value)
    {
        anim.SetBool("Jumping", !value);
    }

    private void SetRunningAnimation(bool value)
    {
        anim.SetBool("Running", value);
    }
}
