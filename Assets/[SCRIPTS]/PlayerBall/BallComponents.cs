using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RotationBall
{
    public class BallComponents : MonoBehaviour
    {
        [SerializeField] Rigidbody2D _rigidBody2D = null;
        [SerializeField] GameObject _playerBall = null;
        [SerializeField] BallPositionEnum _ballStateMain;
        //[SerializeField] Collider2D collider2D;

        SignalBus _signalBus;

        [Inject]
        public void Contr(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public float speed;
        public float jumpForce;

        public GameObject ballObject
        {
            get { return _playerBall; }
        }

        public Rigidbody2D Rigidbody2D
        {
            get { return _rigidBody2D; }
        }

        public void AddForce(Vector2 force)
        {
            _rigidBody2D.AddForce(force);
        }

        public void JumpVelocity(Vector2 jump)
        {
            _rigidBody2D.AddForce(jump);
        }

        public BallPositionEnum BallStateMain
        {
            get { return _ballStateMain; }
        }

        public void ChangeState(BallPositionEnum ballState)
        {
            _ballStateMain = ballState;
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "finalholl")
            {
                _signalBus.Fire<BallTouchedColliderSignal>();
            }            
        }
    }
}
