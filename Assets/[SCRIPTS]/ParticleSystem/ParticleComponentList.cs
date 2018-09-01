using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RotationBall
{
    public class ParticleComponentList : MonoBehaviour
    {

        [SerializeField] ParticleSystem jumpingParticles;

        [Zenject.Inject] BallComponents ballComponents;
        [Zenject.Inject] CheckIfObjectIsGrounded check;
        //private Vector3 jumpingParticlePosition;        

        private void Start()
        {
            //jumpingParticlePosition = jumpingParticles.transform.position;
        }

        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        //    {
        //        jumpingParticles.transform.position = ballComponents.ballTransform.position;
        //    }            
        //}

        public void PlayJumpingParticles()
        {
            if (Input.GetKeyDown(KeyCode.W) && check.isGrounded == true)
            {
                jumpingParticles.transform.position = ballComponents.ballTransform.position - new Vector3(0f, 0.1f, 0f);
                jumpingParticles.Play();
            }
            Debug.Log("asdsad");
            
        }
    }
}
