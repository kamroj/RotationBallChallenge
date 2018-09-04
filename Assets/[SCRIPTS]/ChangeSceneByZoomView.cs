using System.Collections;
using UnityEngine;
using Zenject;

namespace RotationBall
{
    public class ChangeSceneByZoomView : MonoBehaviour {

        [SerializeField] Camera _camera;
        [SerializeField] Transform finalHollTransform;
        [Zenject.Inject] GameController gameController;

        

        [SerializeField] float zoomSpeed1;
        [SerializeField] float zoomSpeed2;
        [SerializeField] float waitingTime = 1f;

        private float currentCameraSize;
        Vector2 currHolePosition;
        Vector2 currCameraPosition;

        // Use this for initialization
        void Start()
        {
            currentCameraSize = _camera.orthographicSize;
            currCameraPosition = _camera.transform.position;
        }

        private void Update()
        {
            currHolePosition = finalHollTransform.transform.position;
        }

        public void StartZoomingInTheCamera()
        {
            StartCoroutine(cameraEnumerator());            
            StartCoroutine(cameraEnumeratorToPlayer());
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
    }
}
