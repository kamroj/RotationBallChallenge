using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RotationBall
{
    public class BallStateDead : BallState
    {
        readonly BallComponents _ballComponents;

        public BallStateDead(BallComponents ballComponents)
        {
            _ballComponents = ballComponents;
        }

        public override void Start()
        {
            _ballComponents.ballObject.SetActive(false);
        }

        public override void Update()
        {
            //TODO
        }
        public class Factory : PlaceholderFactory<BallStateDead>
        {
        }
    }
       
}
