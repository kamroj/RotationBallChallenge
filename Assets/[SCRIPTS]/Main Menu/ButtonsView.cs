using UnityEngine;
using UnityEngine.Events;
using Zenject;
using UnityEngine.SceneManagement;

namespace RotationBall.UI
{
    public class ButtonsView : IInitializable
    {
        [Zenject.Inject] ButtonsCompoments button;

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
        }

        private void UnlockLevel()
        {
            int levelReached = PlayerPrefs.GetInt("levelReached", 1);

            for (int i = 0; i < button.LevelButton.Length; i++)
            {
                if (i + 1 > levelReached)
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
            
        }

    }
}
