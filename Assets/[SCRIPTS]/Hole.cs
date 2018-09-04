using UnityEngine;
using Zenject;
using RotationBall;

public class Hole : IInitializable
{
    [Zenject.Inject] SignalBus signalBus;
    [Zenject.Inject] GameController gameController;
    [Zenject.Inject] ChangeSceneByZoomView changeSceneByZoomView;

    public void Initialize()
    {
        signalBus.Subscribe<BallTouchedColliderSignal>(OnBallTouchedCollider);
    }

    void OnBallTouchedCollider()
    {
        //_changeSceneByZoom.StartZoomingInTheCamera();
        Debug.Log("I hit the hole");
        changeSceneByZoomView.StartZoomingInTheCamera();
    }
}
