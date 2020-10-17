using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpookuleleGames.Audio
{
    [CreateAssetMenu(menuName = "Audio/One Shot/Simple One Shot")]
    public class SimpleOneShot : ScriptableObject, IOneShot
    {
        [SerializeField] AudioClip clip;
        [SerializeField] Vector2 volumeRange = Vector2.one;
        [SerializeField] Vector2 pitchRange = Vector2.one;

        public AudioClip Clip => clip;
        public float MinVolume => volumeRange.x;
        public float MaxVolume => volumeRange.y;
        public float MinPitch => pitchRange.x;
        public float MaxPitch => pitchRange.y;
    }
}