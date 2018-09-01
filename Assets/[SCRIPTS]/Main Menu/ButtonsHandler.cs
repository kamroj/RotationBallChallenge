using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RotationBall.UI
{
    public class ButtonsHandler : MonoBehaviour
    {
        [Zenject.Inject] ButtonsCompoments button;

       

        public void StartGame()
        {
            Debug.Log("Button was clicked");
            Application.LoadLevel("MainMenu");
        }
    }
}
