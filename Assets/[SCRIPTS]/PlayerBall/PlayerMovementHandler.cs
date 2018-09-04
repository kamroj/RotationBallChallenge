using RotationBall.Audio;
using UnityEngine;
using Zenject;

namespace RotationBall
{
    public class PlayerMovementHandler : ITickable
    {
        BallComponents ballComponents;
        CheckIfObjectIsGrounded checkIfObjectIsGrounded;

        [Zenject.Inject] AudioMenager audioMenager;
        [Zenject.Inject] AudioComponents audioComponents;

        private float acceleration;
        private float jumpForce;

        public PlayerMovementHandler(BallComponents _ballComponents, CheckIfObjectIsGrounded _checkIfObjectIsGrounded)
        {
            this.ballComponents = _ballComponents;
            checkIfObjectIsGrounded = _checkIfObjectIsGrounded;
        }

        public void TryMove()
        {
            acceleration = ballComponents.speed * Time.deltaTime;
            var horizontal = Input.GetAxis("Horizontal");
            ballComponents.AddForce(new Vector2(horizontal * acceleration, 0f));
        }

        public void TryJump()
        {
            if (ballComponents.BallStateMain == BallPositionEnum.Jumping && ballComponents.Rigidbody2D.velocity.y != 0f)
            {
                return;
            }
            else if (ballComponents.BallStateMain == BallPositionEnum.Grounded)
            {
                jumpForce = ballComponents.jumpForce * Time.deltaTime * 100f;
                var vertical = Input.GetAxis("Vertical");
                ballComponents.JumpVelocity(new Vector2(0f, jumpForce));
                audioMenager.PlayOneShot(audioComponents.jumpClip);
            }
        }

        private void SetStates()
        {
            if (checkIfObjectIsGrounded.isGrounded == true)
            {
                ballComponents.ChangeState(BallPositionEnum.Grounded);
            }
            else
            {
                ballComponents.ChangeState(BallPositionEnum.Jumping);
            }
        }

        public void Tick()
        {
            SetStates();
        }
    }
}
