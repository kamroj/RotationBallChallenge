using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMovementHandler
{
    BallComponents _ballComponents;

    public PlayerMovementHandler(BallComponents ballComponents)
    {
        _ballComponents = ballComponents;
    }

    public void TryMove()
    {
        var horizontal = Input.GetAxis("Horizontal");
        _ballComponents.AddForce( new Vector2(horizontal * 10f, 0f));
    }
}
