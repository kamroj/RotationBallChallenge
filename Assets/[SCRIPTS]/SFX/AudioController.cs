using UnityEngine;
using Zenject;
using RotationBall.LevelChange;

namespace RotationBall.Audio
{
    public class AudioController : ITickable
    {
        [Zenject.Inject] AudioComponents audioComponents;
        [Zenject.Inject] AudioMenager audioMenager;
        [Zenject.Inject] LevelChanger levelChanger;

        private int? currentScene = null;
              

        public void SwitchAudioBetweenScenes()
        {
            switch (currentScene)
            {
                case 0:
                    audioMenager.Play(audioComponents.musicMainMenu);
                    break;
                case 1:
                    audioMenager.Play(audioComponents.musicLevelOne);
                    break;
                default:
                    break;
            }
        }

        public void Tick()
        {
            if (currentScene == levelChanger.currLevel)
            {
                return;
            }
            else
            {
                currentScene = levelChanger.currLevel;
            }

            SwitchAudioBetweenScenes();
        }
    }
}