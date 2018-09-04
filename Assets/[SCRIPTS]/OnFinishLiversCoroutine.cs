using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotationBall;

public class OnFinishLiversCoroutine : MonoBehaviour {

    [Zenject.Inject] BallComponents ball;

    public Animator animator;

    public void StartLeversCoroutineEvent()
    {
        ball.Rigidbody2D.simulated = false;
    }

    public void FinishLeversCoroutineEvent()
    {
        ball.Rigidbody2D.simulated = true;
    }
}
