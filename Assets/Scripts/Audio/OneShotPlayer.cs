using SpookuleleGames.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpookuleleGames.Audio
{
    public class OneShotPlayer : MonoBehaviour
    {
        [SerializeField] AudioSource source;

        public void Init(AudioClip clip, float volume, float pitch)
        {
            source.clip = clip;
            source.volume = volume;
            source.pitch = pitch;
            source.Play();
            MethodDelayer.DelayMethodByTimeAsync(() => gameObject.SetActive(false), clip.length);
        }
    }
}