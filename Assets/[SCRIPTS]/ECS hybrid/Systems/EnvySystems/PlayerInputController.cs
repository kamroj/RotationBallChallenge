using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInputController : MonoBehaviour
{

    EnvyRotationHandler rotationHandler;

    [Header("Adjust parameters")]
    public GameObject envy;
    public float speed;
    public float rotationTime;

    private bool isRotating =false;

    [Inject]
    private void Initialize(EnvyRotationHandler _rotationHandler)
    {
        rotationHandler = _rotationHandler;
    }

    private void Update()
    {
        TryRotate();
    }

    private void OnDestroy()
    {
        rotationHandler = null;
    }

    private void TryRotate()
    {        
        var fromAngle = envy.transform.rotation;
        var toAngle = Quaternion.Euler(envy.transform.eulerAngles + (Vector3.forward * 90));

        if (Input.GetKeyDown(KeyCode.Space) && isRotating == false)
        {
            isRotating = true;
            StartCoroutine(rotationHandler.rotationEnumerator(fromAngle, toAngle, envy, rotationTime));
        }
        isRotating = false;
    }
}
