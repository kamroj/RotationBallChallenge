using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Zenject;

namespace RotationBall.UI
{
    public class ButtonsCompoments : MonoBehaviour
    {
        [SerializeField] public GameObject mainMenu;
        [SerializeField] public GameObject levels;
        [SerializeField] public Button startButton;
        [SerializeField] public Button selectLevelButton;
        [SerializeField] public Button backButton;
        [SerializeField] public Button exitButton;

        [SerializeField] public List <Button> LevelButton;
    }
}
