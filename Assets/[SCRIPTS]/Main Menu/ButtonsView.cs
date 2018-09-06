using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;
using RotationBall.LevelChange;
using System.Collections.Generic;
using System.Collections;
using RotationBall.Audio;

namespace RotationBall.UI
{
    public class ButtonsView : IInitializable, ITickable
    {
        [Zenject.Inject] ButtonsCompoments button;
        [Zenject.Inject] LevelChanger levelChanger;
        [Zenject.Inject] GameController gameController;
        [Zenject.Inject] BackToMenuButton backToMenuButton;
        [Zenject.Inject] MonoCoroutine monoCoroutine;

        [Zenject.Inject] AudioMenager audioMenager;
        [Zenject.Inject] AudioComponents audioComponents;        


        public void Initialize()
        {
            UnlockLevel();
            AddListenersToButtons();            
        }

        public void Tick()
        {            
            BackToMenuButtonView();
        }

        private void AddListenersToButtons()
        {
            button.selectLevelButton.onClick.AddListener(SelectLevelView);
            button.backButton.onClick.AddListener(BackToMainMenu);
            button.startButton.onClick.AddListener(StartGame);

            for (int i = 0; i < button.LevelButton.Count; i++)
            {
                button.LevelButton[i].onClick.AddListener(ChooseLevelFromSelectLevelMenu);
            }            
        }

        private void UnlockLevel()
        {
            gameController.levelUnlocked = PlayerPrefs.GetInt("levelReached", gameController.levelReached);

            for (int i = 0; i < button.LevelButton.Count; i++)
            {
                if (i + 1 > gameController.levelUnlocked)
                {
                    button.LevelButton[i].interactable = false;
                }
            }
        }

        void SelectLevelView()
        {
            monoCoroutine.WaitAndSetActive(button.mainMenu, 0.4f, false);
            monoCoroutine.WaitAndSetActive(button.levels, 0.4f, true);
            //button.mainMenu.SetActive(false);
            //button.levels.SetActive(true);
        }

        void BackToMainMenu()
        {
            monoCoroutine.WaitAndSetActive(button.mainMenu, 0.4f, true);
            monoCoroutine.WaitAndSetActive(button.levels, 0.4f, false);
            //button.mainMenu.SetActive(true);
            //button.levels.SetActive(false);
        }

        void StartGame()
        {
            levelChanger.ChangeToLevel(1);
            gameController.gameState = GameStates.Playing;
        }

        private void BackToMenuButtonView()
        {
            bool setActive = gameController.gameState == GameStates.Playing;
            if (setActive == backToMenuButton.gameObject.activeInHierarchy)
            {
                return;
            }
            else monoCoroutine.WaitAndSetActive(backToMenuButton.gameObject, 0.95f, setActive);
        }        

        //IEnumerator Start()
        //{
        //    yield return new WaitForSeconds(1f);
        //    backToMenuButton.gameObject.SetActive(true);
        //}
        

        void ChooseLevelFromSelectLevelMenu()
        {
            string name = EventSystem.current.currentSelectedGameObject.name;

            switch (name)
            {
                case "1":
                    {
                        levelChanger.ChangeToLevel(1);
                        gameController.nextLevelToLoad = 1;
                        break;
                    }                    
                case "2":
                    {
                        levelChanger.ChangeToLevel(2);
                        gameController.nextLevelToLoad = 2;
                        break;
                    }
                case "3":
                    {
                        levelChanger.ChangeToLevel(3);
                        break;
                    }
                default:
                    break;
            }
            gameController.gameState = GameStates.Playing;
        }        
    }
}
