using UnityEngine;
using UnityEngine.UI;
using RotationBall.LevelChange;
using System.Collections;
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
        }
        

        public void GoBackToMainMenu()
        {
            Debug.Log("I was pressed");
            gameController.ChangeGameState(GameStates.WaitingToStart);
            levelChanger.ChangeToLevel(0);
            StartCoroutine(waitTillFadeOut());
        }     

        IEnumerator waitTillFadeOut()
        {
            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);
        }
    }
}
