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
    }
}
