using UnityEngine;
using UnityEngine.UI;
using RotationBall.LevelChange;
using RotationBall;
using Zenject;

namespace RotationBall.UI
{
    public class BackToMenuButton : MonoBehaviour
    {
        [SerializeField] Button mainMenuButton;
        [Zenject.Inject] LevelChanger levelChanger;
        [Zenject.Inject] GameController gameController;


        public void Start()
        {
            DontDestroyOnLoad(this);
            mainMenuButton.onClick.AddListener(GoBackToMainMenu);
        }

        public void GoBackToMainMenu()
        {
            Debug.Log("I was pressed");
            gameController.ChangeGameState(GameStates.Playing);
            levelChanger.ChangeToLevel(0);
        }
    }
}
