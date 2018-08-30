using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RotationBall
{
    public class ChangeSceneByZoomView : MonoBehaviour {

        [SerializeField] Camera _camera;
        [Zenject.Inject] BallComponents ballComponents;

        public float zoomSpeed1;
        public float zoomSpeed2;
        private float currentCameraSize;
        Vector2 currBallPosition;
        Vector2 currCameraPosition;

        // Use this for initialization
        void Start() {
            currentCameraSize = _camera.orthographicSize;
            currCameraPosition = _camera.transform.position;            
            
        }

        private void Update()
        {
            currBallPosition = ballComponents.ballTransform.position;            
        }

        public void StartZoomingInTheCamera()
        {
            StartCoroutine(cameraEnumerator());            
            StartCoroutine(cameraEnumeratorToPlayer());
        }

        IEnumerator cameraEnumerator()
        {
            yield return new WaitForSeconds(1f);
            while (_camera.orthographicSize >= 0.01f)
            {
                yield return new WaitForSeconds(0.001f);
                _camera.orthographicSize -= zoomSpeed1;
            }
            _camera.orthographicSize = 0.01f;                  
        }

        IEnumerator cameraEnumeratorToPlayer()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("UWAGA");
            for (var t = 0f; t < 1; t += zoomSpeed2)
            {                
                _camera.transform.position = Vector2.Lerp(currCameraPosition, currBallPosition, t);
                yield return null;
            }            
        }
    }
}
