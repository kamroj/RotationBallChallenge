using UnityEngine;
using UnityEngine.SceneManagement;

namespace RotationBall.LevelChange
{
    public class LevelChanger : MonoBehaviour
    {
        public Animator animator;
        [Zenject.Inject] GameController gameController;

        private int levelToLoad;
        public int maxLevel
        {
            get
            {
                return SceneManager.sceneCountInBuildSettings - 1;
            }            
        }

        public int currLevel
        {
            get
            {
                return SceneManager.GetActiveScene().buildIndex;
            }            
        }


        public void ChangeToLevel(int levelIndex)
        {
            gameController.gameState = (levelIndex == 0) ? GameStates.WaitingToStart : GameStates.Playing;
            levelToLoad = levelIndex;
            //gameController.gameState = _gameState;
            animator.SetTrigger("FadeOut");
        }
        
        public void OnFadeComplete()
        {            
            SceneManager.LoadScene(levelToLoad);
            animator.SetTrigger("FadeIn");
        }
    }
}
