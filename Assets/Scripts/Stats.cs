using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : Player
{
    protected Player player;

    protected override void Initialize()
    {
        base.Initialize();
        player = GetComponent<Player>();
    }
}
