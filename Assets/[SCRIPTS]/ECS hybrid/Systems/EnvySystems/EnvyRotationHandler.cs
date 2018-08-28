using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnvyRotationHandler
{
    private bool isRotating = false;

    public IEnumerator rotationEnumerator(Quaternion fromAngle, Quaternion toAngle, GameObject gameObject, float rotationTime)
    {
        if (isRotating == false)
        {            
            for (var t = 0f; t < 1; t += Time.deltaTime / rotationTime)
            {
                isRotating = true;
                gameObject.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
                yield return null;
            }            
            gameObject.transform.rotation = toAngle;            
        }
        isRotating = false;
    }
}
    
