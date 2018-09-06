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


        public void Start()
        {
            DontDestroyOnLoad(this);                      
        }
        

        public void GoBackToMainMenu()
        {            
            levelChanger.ChangeToLevel(0);            
        }          
    }
}
