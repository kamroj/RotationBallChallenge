using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RotationBall
{
    public abstract class BallState
    {
        public abstract void Update();
        public virtual void Start() {}
        public virtual void OnTriggerEnter(Collider2D collider) {}
    }

    public enum BallPositionEnum
    {
        Grounded,
        Jumping,
        Die
    }
}