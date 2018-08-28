using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInputController : MonoBehaviour
{

    EnvyRotationHandler rotationHandler;
    PlayerMovementHandler movementHandler;

    [Header("Adjust parameters")]
    public GameObject envy;
    public float speed;
    public float rotationTime;


    [Inject]
    private void Initialize(EnvyRotationHandler _rotationHandler, PlayerMovementHandler _movementHandler)
    {
        rotationHandler = _rotationHandler;
        movementHandler = _movementHandler;        

    }

    private void Update()
    {
        TryRotate();
        movementHandler.TryMove();
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
}
