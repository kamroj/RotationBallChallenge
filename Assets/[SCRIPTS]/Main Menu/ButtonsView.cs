using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zenject;
using RotationBall.LevelChange;

namespace RotationBall.UI
{
    public class ButtonsView : IInitializable
    {
        [Zenject.Inject] ButtonsCompoments button;
        [Zenject.Inject] LevelChanger levelChanger;
        [Zenject.Inject] GameController gameController;

        public UnityEvent selectButton;        


        public void Initialize()
        {
            UnlockLevel();
            AddListenersToButtons();
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
            button.mainMenu.SetActive(false);
            button.levels.SetActive(true);
        }

        void BackToMainMenu()
        {
            button.mainMenu.SetActive(true);
            button.levels.SetActive(false);
        }

        void StartGame()
        {
            levelChanger.ChangeToLevel(1);
        }

        void ChooseLevelFromSelectLevelMenu()
        {
            for (int i = 0; i < button.LevelButton.Count; i++)
            {
                if (button.LevelButton[0])
                {
                    levelChanger.ChangeToLevel(1);
                }
                else if (button.LevelButton[1])
                {
                    levelChanger.ChangeToLevel(2);
                }
            }
        }

    }
}
