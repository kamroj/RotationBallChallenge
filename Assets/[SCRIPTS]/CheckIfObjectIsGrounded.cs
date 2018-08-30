using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RotationBall
{
    public class CheckIfObjectIsGrounded : MonoBehaviour
    {
        [SerializeField] Transform objectToCheck;
        [SerializeField] LayerMask layerMask;

        public bool isGrounded;
        public float sizeOfCube;
        public float cubeYpossiotion;

        public CheckIfObjectIsGrounded(Transform _objectToCheck)
        {
            objectToCheck = _objectToCheck;
        }
        

        public void Update()
        {
            CheckIfGrounded();
        }

        private void CheckIfGrounded()
        {
            //Debug.Log($"Position of ball is x={playerBall.position.x}, y={playerBall.position.y}");

            isGrounded = Physics2D.OverlapBox(new Vector2(objectToCheck.position.x, objectToCheck.position.y - cubeYpossiotion), new Vector2(sizeOfCube, sizeOfCube), 0f, layerMask);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 1, 0, 0.5f);
            Gizmos.DrawCube(new Vector2(objectToCheck.position.x, objectToCheck.position.y - cubeYpossiotion), new Vector2(sizeOfCube, sizeOfCube));
        }
    }
}