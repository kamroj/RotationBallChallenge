using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RotationBall.Audio
{
    public class AudioComponents : MonoBehaviour
    {
        [SerializeField] AudioClip _jumpClip;
        //[SerializeField] AudioSource _audioSource;

        public AudioClip jumpClip { get { return _jumpClip; } }
        //public AudioSource audioSource { get { return _audioSource; } }
    }
}