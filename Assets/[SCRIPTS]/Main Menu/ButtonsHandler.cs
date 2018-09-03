using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RotationBall.UI
{
    public class ButtonsHandler
    {
        [Zenject.Inject] ButtonsCompoments button;
        [Zenject.Inject] ButtonsView buttonsView;

        private void GoToSelectLevelView()
        {
            button.selectLevelButton.onClick.Invoke();
        }

        private void BackToMainMenu()
        {
            button.backButton.onClick.Invoke();
        }
    }
}
