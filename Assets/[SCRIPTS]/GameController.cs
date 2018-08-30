using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RotationBall
{

    public enum GameStates
    {
        WaitingToStart,
        Playing,
        GameOver,
    }

    public class GameController : IInitializable, ITickable
    {
        BallComponents _ballComponents;
        SignalBus _signalBus;
        ChangeSceneByZoomView _changeSceneByZoom;
        GameStates _state = GameStates.Playing;

        public GameStates State
        {
            get { return _state; }
        }

        public GameController(BallComponents ballComponents, SignalBus signalBus, ChangeSceneByZoomView changeSceneByZoom)
        {
            _ballComponents = ballComponents;
            _signalBus = signalBus;
            _changeSceneByZoom = changeSceneByZoom;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<BallTouchedColliderSignal>(OnBallTouchedCollider);
        }

        public void Tick()
        {
            switch (_state)
            {                
                case GameStates.Playing:
                    {
                        UpdatePlaying();
                        break;
                    }
                case GameStates.GameOver:
                    {
                        UpdateGameOver();
                        break;
                    }
                default:                                            
                        break;
                    
            }
        }

        void OnBallTouchedCollider()
        {
            //Debug.Log("I hit colider");
            //_changeSceneByZoom.StartZoomingInTheCamera();
        }

        void UpdateGameOver()
        {
            Debug.Log("Update gameover is fired");
        }

        void UpdatePlaying()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("Update playing is fired");
            }            
        }
        
    }
}