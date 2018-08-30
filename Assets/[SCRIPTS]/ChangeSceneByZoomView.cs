using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneByZoomView : MonoBehaviour {

    [SerializeField] Camera _camera;
    public float zoomSpeed;
    private float currentCameraSize;
    
    // Use this for initialization
	void Start () {
        currentCameraSize = _camera.orthographicSize;
	}	
	
    public void StartZoomingInTheCamera()
    {
        StartCoroutine(cameraEnumerator());
    }

    IEnumerator cameraEnumerator()
    {
        yield return new WaitForSeconds(1f);
        while (_camera.orthographicSize >= 0.01f)
        {
            yield return new WaitForSeconds(0.001f);
            _camera.orthographicSize -= 0.1f;
        }
        _camera.orthographicSize = 0.01f;
        
        //if (_camera.orthographicSize > 0.1f)
        //{
        //    for (var t = 0f; t < 5f; ++t)
        //    {
        //        _camera.orthographicSize -= t;
        //        yield return null;
        //    }
        //}        
    }
}
