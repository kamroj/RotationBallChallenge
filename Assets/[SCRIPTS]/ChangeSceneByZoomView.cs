using System.Collections;
using UnityEngine;
using Zenject;

namespace RotationBall
{
    public class ChangeSceneByZoomView : MonoBehaviour {

        [SerializeField] Camera _camera;
        [SerializeField] Transform finalHollTransform;

        [Zenject.Inject] BallComponents ball;
        [Zenject.Inject] GameController gameController;

        

        [SerializeField] float zoomSpeed1;
        [SerializeField] float zoomSpeed2;
        [SerializeField] float waitingTime = 1f;
        [SerializeField] float ballToHoleSpeed = 0.04f;

        private float currentCameraSize;
        Vector2 currHolePosition;
        Vector2 currballPosition;
        Vector2 currCameraPosition;

        // Use this for initialization
        void Start()
        {
            currentCameraSize = _camera.orthographicSize;
            currCameraPosition = _camera.transform.position;
        }

        private void Update()
        {
            currballPosition = ball.transform.position;
            currHolePosition = finalHollTransform.transform.position;
        }

        public void StartZoomingInTheCamera()
        {
            StartCoroutine(cameraEnumerator());            
            StartCoroutine(cameraEnumeratorToPlayer());
            StartCoroutine(ballToHolePosition());
        }

        IEnumerator cameraEnumerator()
        {
            yield return new WaitForSeconds(waitingTime);
            while (_camera.orthographicSize >= 0.01f)
            {
                yield return new WaitForSeconds(0.001f);
                _camera.orthographicSize -= zoomSpeed1;                
            }
            _camera.orthographicSize = 0.01f;
            gameController.gameState = GameStates.NextRound;

        }

        IEnumerator cameraEnumeratorToPlayer()
        {
            yield return new WaitForSeconds(waitingTime);
            Debug.Log("UWAGA");
            for (var t = 0f; t < 1; t += zoomSpeed2)
            {                
                _camera.transform.position = Vector2.Lerp(currCameraPosition, currHolePosition, t);
                yield return null;
            }            
        }

        IEnumerator ballToHolePosition()
        {            
            Debug.Log("UWAGA");
            for (var t = 0f; t < 1; t += ballToHoleSpeed)
            {
                ball.transform.position = Vector2.Lerp(currballPosition, currHolePosition, t);
                yield return null;
            }
        }
    }
}
