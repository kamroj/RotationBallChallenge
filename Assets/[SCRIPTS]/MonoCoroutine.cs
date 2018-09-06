using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RotationBall
{
    public class MonoCoroutine : MonoBehaviour
    {
        public void WaitAndSetActive(GameObject gameObject, float time, bool active)
        {
            StartCoroutine(WaitAndSetActives(gameObject, time, active));
        }

        IEnumerator WaitAndSetActives(GameObject gameObject, float time, bool active)
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(active);
        }
    }
}
