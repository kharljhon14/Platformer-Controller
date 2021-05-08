using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb2d;

    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
}
