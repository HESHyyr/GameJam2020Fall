using UnityEngine;

namespace SpookuleleGames.Audio
{
    [CreateAssetMenu(menuName = "Audio/Persistent Sound/Simple Persistent Sound")]
    public class SimplePersistentSound : ScriptableObject, IPersistentSound
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