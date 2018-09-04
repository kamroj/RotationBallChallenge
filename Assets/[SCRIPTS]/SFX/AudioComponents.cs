using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RotationBall.Audio
{
    public class AudioComponents : MonoBehaviour
    {
        [SerializeField] AudioClip _jumpClip;
        [SerializeField] AudioClip _music;

        public AudioClip jumpClip { get { return _jumpClip; } }
        public AudioClip music { get { return _music; } }

    }
}