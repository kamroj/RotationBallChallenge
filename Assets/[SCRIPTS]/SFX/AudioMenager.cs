using UnityEngine;
using Zenject;

namespace RotationBall.Audio
{
    public class AudioMenager
    {
        [Zenject.Inject] AudioSource audioSource;

        public void PlayOneShot(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);   
        }

        public void Play(AudioClip audio)
        {
            audioSource.clip = audio;
            audioSource.loop = true;
            audioSource.Play();
        }

    }
}
