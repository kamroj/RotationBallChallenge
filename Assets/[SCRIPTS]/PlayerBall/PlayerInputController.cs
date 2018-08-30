using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RotationBall
{
    public class PlayerInputController : MonoBehaviour
    {

        EnvyRotationHandler rotationHandler;
        PlayerMovementHandler movementHandler;


        [Header("Adjust parameters")]
        [SerializeField] GameObject envy;
        [SerializeField] Transform playerBall;
        [SerializeField] LayerMask layerMask;

        public float speed;
        public float rotationTime;        
        //public float sizeOfCube;
        //public float cubeYpossiotion;
        //public bool isGrounded;


        [Inject]
        private void Initialize(EnvyRotationHandler _rotationHandler, PlayerMovementHandler _movementHandler)
        {
            rotationHandler = _rotationHandler;
            movementHandler = _movementHandler;
        }

        private void Update()
        {
            //CheckIfGrounded();
            TryRotate();
            movementHandler.TryMove();
            TryJump();
        }

        private void OnDestroy()
        {
            rotationHandler = null;
        }

        private void TryRotate()
        {
            var fromAngle = envy.transform.rotation;
            var toAngle = Quaternion.Euler(envy.transform.eulerAngles + (Vector3.forward * 90));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(rotationHandler.rotationEnumerator(fromAngle, toAngle, envy, rotationTime));
            }
        }

        private void TryJump()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                movementHandler.TryJump();
            }
        }


        ////gdzie to dać
        //private void CheckIfGrounded()
        //{
        //    //Debug.Log($"Position of ball is x={playerBall.position.x}, y={playerBall.position.y}");

        //    isGrounded = Physics2D.OverlapBox(new Vector2(playerBall.position.x, playerBall.position.y - cubeYpossiotion), new Vector2(sizeOfCube, sizeOfCube), 0f, layerMask);
        //}

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = new Color(0, 1, 0, 0.5f);
        //    Gizmos.DrawCube(new Vector2(playerBall.position.x, playerBall.position.y - cubeYpossiotion), new Vector2(sizeOfCube, sizeOfCube));
        //}
    }
}
