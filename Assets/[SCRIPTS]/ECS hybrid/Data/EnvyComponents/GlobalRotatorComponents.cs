using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalRotatorComponents : MonoBehaviour
{
    Transform transform;
    public float timeForRotation;
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StartCoroutine(RotationWait());
    //    }
    //}


    //IEnumerator RotationWait()
    //{
    //    var fromAngle = transform.rotation;
    //    var toAngle = Quaternion.Euler(transform.eulerAngles + (Vector3.forward * 90));

    //    for (var t = 0f; t <= 1; t += Time.deltaTime / 0.8f)
    //    {
    //        transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
    //        yield return null;
    //    }
    //    transform.rotation = toAngle;
    //}
}
