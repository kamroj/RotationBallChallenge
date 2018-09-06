using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RotationBall.Audio
{
    public class AudioComponents : MonoBehaviour
    {
        [SerializeField] AudioClip _jumpClip;
        [SerializeField] AudioClip _musicMainMenu;
        [SerializeField] AudioClip _musicLevelOne;

        public AudioClip jumpClip { get { return _jumpClip; } }
        public AudioClip musicMainMenu { get { return _musicMainMenu; } }
        public AudioClip musicLevelOne { get { return _musicLevelOne; } }
    }
}