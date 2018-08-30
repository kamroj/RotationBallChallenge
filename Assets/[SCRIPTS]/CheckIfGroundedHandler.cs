using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RotationBall
{
    public class CheckIfGroundedHandler : ITickable
    {
        [SerializeField] Transform playerBall;
        [SerializeField] LayerMask layerMask;

        public bool isGrounded;
        public float sizeOfCube;
        public float cubeYpossiotion;

        public CheckIfGroundedHandler(Transform _playerBall)
        {
            playerBall = _playerBall;
        }
        

        public void Tick()
        {
            CheckIfGrounded();
        }

        private void CheckIfGrounded()
        {
            //Debug.Log($"Position of ball is x={playerBall.position.x}, y={playerBall.position.y}");

            isGrounded = Physics2D.OverlapBox(new Vector2(playerBall.position.x, playerBall.position.y - cubeYpossiotion), new Vector2(sizeOfCube, sizeOfCube), 0f, layerMask);
        }        
    }
}