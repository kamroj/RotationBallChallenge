using UnityEngine;
using UnityEngine.SceneManagement;

namespace RotationBall.LevelChange
{
    public class LevelChanger : MonoBehaviour
    {
        public Animator animator;        

        private int levelToLoad;              

        public void ChangeToLevel(int levelIndex)
        {
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
