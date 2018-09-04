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
        [SerializeField] Transform playerBallTransform = null;
        [SerializeField] BallPositionEnum _ballStateMain;        

        SignalBus _signalBus;       
        public float speed;
        public float jumpForce;        

        [Inject]
        public void Contr(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public Transform ballTransform
        {
            get { return playerBallTransform; }
        }

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
            set { _ballStateMain = BallStateMain; }
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
