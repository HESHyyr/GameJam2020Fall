using SpookuleleGames.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpookuleleGames.Audio
{
    public class PersistentSoundPlayer : MonoBehaviour
    {
        [SerializeField] AudioSource source;
        public AudioSource Source => source;

        public void Init(AudioClip clip, float volume, float pitch)
        {
            source.clip = clip;
            source.volume = volume;
            source.pitch = pitch;
            source.Play();
        }

        public void FadeOut(float time)
        {

            StartCoroutine(FadeOutCoroutine());

            IEnumerator FadeOutCoroutine()
            {
                float startingVolume = source.volume;
                float t = 0f;
                while (t < 1.1f)
                {
                    t += Time.deltaTime / time;
                    source.volume = startingVolume * Mathf.Clamp01(1-t);
                    yield return null;
                }
                Stop();
            }
        }


        public void Stop()
        {
            gameObject.SetActive(false);
        }
    }
}