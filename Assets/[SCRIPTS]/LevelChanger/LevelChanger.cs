﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelChanger
{
    public class LevelChanger : MonoBehaviour
    {
        public Animator animator;
        private int levelToLoad;              

        public void FadeToLevel(int levelIndex)
        {
            levelToLoad = levelIndex;
            animator.SetTrigger("FadeOut");
        }
        
        public void OnFadeComplete()
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
