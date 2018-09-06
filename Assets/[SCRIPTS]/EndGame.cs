using UnityEngine;
using RotationBall.LevelChange;
using System.Collections;
using RotationBall.UI;

namespace RotationBall
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private float timeToWait = 4f;
        [Zenject.Inject] LevelChanger levelChanger;
        [Zenject.Inject] GameController gameController;
        [Zenject.Inject] BackToMenuButton backToMenuButton;

        private void Start()
        {
            //todo wywalić buttonView niech odpowiedzialne za to będą stany gry
            backToMenuButton.gameObject.SetActive(false);
            StartCoroutine(EndGameSceneEnumeratior());
        }

        IEnumerator EndGameSceneEnumeratior()
        {
            yield return new WaitForSeconds(timeToWait);            
            levelChanger.ChangeToLevel(0);
        }
    }
}
