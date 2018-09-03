using UnityEngine;
using Zenject;
using RotationBall.LevelChange;
using ModestTree;

namespace RotationBall
{

    public enum GameStates
    {
        WaitingToStart,
        Playing,
        GameOver,
        NextRound
    }

    public class GameController : ITickable
    {
        [Zenject.Inject] LevelChanger levelChanger;
        
        //SignalBus _signalBus;
        //ChangeSceneByZoomView _changeSceneByZoom;
        public GameStates gameState;
               

        //public GameController(SignalBus signalBus, ChangeSceneByZoomView changeSceneByZoom)
        //{
            
        //    _signalBus = signalBus;
        //    _changeSceneByZoom = changeSceneByZoom;
        //}

        //public void Initialize()
        //{
        //    _signalBus.Subscribe<BallTouchedColliderSignal>(OnBallTouchedCollider);            
        //}

        public void Tick()
        {            
            switch (gameState)
            {                
                case GameStates.Playing:
                    {
                        UpdateGameOver();
                        break;
                    }
                case GameStates.GameOver:
                    {
                        UpdateGameOver();
                        break;
                    }
                case GameStates.NextRound:
                    {
                        UpdateNextRound();
                        break;
                    }
                default:                                            
                        break;
                    
            }
        }

        public void ChangeGameState(GameStates gameStates)
        {
            gameState = gameStates;
        }
        

        void UpdateGameOver()
        {
            
            Debug.Log("Update gameover is fired");
        }

        void UpdateNextRound()
        {
            gameState = GameStates.Playing;
            Debug.Log("ShouldChange");
            levelChanger.ChangeToLevel(1);            
        }
        
    }
}