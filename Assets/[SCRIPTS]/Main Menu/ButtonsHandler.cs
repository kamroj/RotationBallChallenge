using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using RotationBall.LevelChange;

namespace RotationBall.UI
{
    public class ButtonsHandler
    {
        [Zenject.Inject] ButtonsCompoments button;
        [Zenject.Inject] ButtonsView buttonsView;
        [Zenject.Inject] LevelChanger levelChanger;

        private void GoToSelectLevelView()
        {
            button.selectLevelButton.onClick.Invoke();
        }

        private void BackToMainMenu()
        {
            button.backButton.onClick.Invoke();
        }

        private void StartGame()
        {
            button.startButton.onClick.Invoke();
        }

        private void ChooseLevelFromSelectLevelMenu()
        {            
            for (int i = 0; i < button.LevelButton.Count; i++)
            {
                button.LevelButton[i].onClick.Invoke();
            }
        }
    }
}
