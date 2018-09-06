using UnityEngine;
using Zenject;
using RotationBall.LevelChange;
using RotationBall.Audio;
using RotationBall.UI;
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

    public class GameController : IInitializable, ITickable
    {
        [Zenject.Inject] LevelChanger levelChanger;
        [Zenject.Inject] AudioMenager audioMenager;
        [Zenject.Inject] AudioComponents audio;

        public int levelReached = 1;
        public int levelUnlocked;
        public int nextLevelToLoad = 1;

        //SignalBus _signalBus;
        //ChangeSceneByZoomView _changeSceneByZoom;
        public GameStates gameState = GameStates.WaitingToStart;
               

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
                case GameStates.WaitingToStart:
                    {
                        WaitingForStart();
                        break;
                    }
                case GameStates.Playing:
                    {
                        GameIsInPlayMode();
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
        

        private void UpdateGameOver()
        {
            
            Debug.Log("Update gameover is fired");
        }

        private void UpdateNextRound()
        {
            gameState = GameStates.Playing;

            levelReached = (nextLevelToLoad == levelReached) ? levelReached += 1 : levelReached;
            nextLevelToLoad = (nextLevelToLoad == levelChanger.maxLevel) ? nextLevelToLoad = 0 : nextLevelToLoad = levelChanger.currLevel + 1;

            //if (nextLevelToLoad == levelReached)
            //{
            //    levelReached += 1;
            //}
            //nextLevelToLoad += 1;
            Debug.Log("ShouldChange");

            //nextLevelToLoad > levelChanger.maxLevel ? levelChanger.ChangeToLevel(0) : levelChanger.ChangeToLevel(nextLevelToLoad);
            
            levelChanger.ChangeToLevel(nextLevelToLoad);
        }

        private void GameIsInPlayMode()
        {
            Debug.Log("Playing!!");
        }

        private void WaitingForStart()
        {
            
        }

        public void Initialize()
        {
            audioMenager.Play(audio.music);
        }
    }
}