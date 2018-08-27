//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Unity.Entities;

//public class GlobalRotationSystem : ComponentSystem
//{
//    private struct Data
//    {
//        public readonly int Length;
//        //public Transform transform;
//        //public GlobalRotatorComponents globalRotator;
//        public ComponentArray<Transform> Transform;
//        public ComponentArray<GlobalRotatorComponents> GlobalRotation;
//    }

//    [Inject] Data _data;



//    protected override void OnUpdate()
//    {

//        //for (int i = 0; i < _data.Length; ++i)
//        //{
//        //    var fromAngle = entity.transform.rotation;
//        //    var toAngle = Quaternion.Euler(entity.transform.eulerAngles + (Vector3.forward * 90));
//        //}



//        foreach (var entity in GetEntities<Data>())
//        {
//            var fromAngle = entity.transform.rotation;
//            var toAngle = Quaternion.Euler(entity.transform.eulerAngles + (Vector3.forward * 90));

//            if (Input.GetKeyDown(KeyCode.Space))
//            {
//            for (var t = 0f; t < 1; t += Time.deltaTime / entity.globalRotator.timeForRotation)
//            {
//                    actionEnumerator(fromAngle, toAngle);
//            }
//            entity.transform.rotation = toAngle;
            
//        }


//    }
//}

//    IEnumerator actionEnumerator(Quaternion fromAngle, Quaternion toAngle)
//    {
//        for (var t = 0f; t < 1; t += Time.deltaTime / _data.globalRotator.timeForRotation)
//        {
//            _data.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
//            yield return null;
//        }
//        _data.transform.rotation = toAngle;
//    }    
//}