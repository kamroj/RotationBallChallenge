using UnityEngine;
using UnityEngine.UI;
using RotationBall.LevelChange;
using RotationBall;
using Zenject;

public class BackToMenuButton : MonoBehaviour
{
    [SerializeField] Button mainMenuButton;
    [Zenject.Inject] LevelChanger levelChanger;
    [Zenject.Inject] GameController gameController;

	
    public void Start()
    {
        mainMenuButton.onClick.AddListener(GoBackToMainMenu);
    }	

    private void GoBackToMainMenu()
    {
        gameController.ChangeGameState(GameStates.Playing);
        levelChanger.ChangeToLevel(0);
    }
}
