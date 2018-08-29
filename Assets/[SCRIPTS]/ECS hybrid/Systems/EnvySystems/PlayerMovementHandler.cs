using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RotationBall
{
    public class PlayerMovementHandler : ITickable
    {
        BallComponents _ballComponents;
        PlayerInputController _playerInputController;

        private float acceleration;
        private float jumpForce;

        public PlayerMovementHandler(BallComponents ballComponents, PlayerInputController playerInputController)
        {
            _ballComponents = ballComponents;
            _playerInputController = playerInputController;
        }

        public void TryMove()
        {
            acceleration = _ballComponents.speed * Time.deltaTime;
            var horizontal = Input.GetAxis("Horizontal");
            _ballComponents.AddForce(new Vector2(horizontal * acceleration, 0f));
        }

        public void TryJump()
        {
            if (_ballComponents.BallStateMain == BallPositionEnum.Jumping && _ballComponents.Rigidbody2D.velocity.y == 0f)
            {
                return;
            }
            else if (_ballComponents.BallStateMain == BallPositionEnum.Grounded)
            {
                jumpForce = _ballComponents.jumpForce * Time.deltaTime * 100f;
                var vertical = Input.GetAxis("Vertical");
                _ballComponents.JumpVelocity(new Vector2(0f, jumpForce));
            }
        }

        private void SetStates()
        {
            if (_playerInputController.isGrounded == true)
            {
                _ballComponents.ChangeState(BallPositionEnum.Grounded);
            }
            else
            {
                _ballComponents.ChangeState(BallPositionEnum.Jumping);
            }
        }

        public void Tick()
        {
            SetStates();
        }
    }
}
