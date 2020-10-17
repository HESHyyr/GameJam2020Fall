using SpookuleleGames.ObjectPooling;
using SpookuleleGames.ServiceLocator;
using SpookuleleGames.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpookuleleGames.Audio
{
    public class AudioManager : MonoBehaviour, IService
    {
        public int Priority => 0;

        [SerializeField] private ObjectPool oneShotPool;
        [SerializeField] private ObjectPool persistentSoundPool;

        private Dictionary<IPersistentSound, PersistentSoundPlayer> activePersistentSounds;

        public void Init() {
            oneShotPool.Init();
            persistentSoundPool.Init();
            activePersistentSounds = new Dictionary<IPersistentSound, PersistentSoundPlayer>();
        }

        public void PlayOneShot(IOneShot oneShot)
        {
            OneShotPlayer oneShotPlayer = oneShotPool.Get().GetComponent<OneShotPlayer>();

            AudioClip clip = oneShot.Clip;
            float volume = Random.Range(oneShot.MinVolume, oneShot.MaxVolume);
            float pitch = Random.Range(oneShot.MinPitch, oneShot.MaxPitch);
            oneShotPlayer.Init(clip, volume, pitch);
        }

        public PersistentSoundPlayer PlayPersistentSound(IPersistentSound persistentSound)
        {
            PersistentSoundPlayer soundPlayer = persistentSoundPool.Get().GetComponent<PersistentSoundPlayer>();

            AudioClip clip = persistentSound.Clip;
            float volume = Random.Range(persistentSound.MinVolume, persistentSound.MaxVolume);
            float pitch = Random.Range(persistentSound.MinPitch, persistentSound.MaxPitch);
            soundPlayer.Init(clip, volume, pitch);

            activePersistentSounds.Add(persistentSound, soundPlayer);
            MethodDelayer.DelayMethodByPredicateAsync(() => activePersistentSounds.Remove(persistentSound), ()=>soundPlayer.gameObject.activeSelf == false);
            return soundPlayer;
        }

        public bool TryGetPersistentSound(IPersistentSound persistentSound, out PersistentSoundPlayer player)
        => activePersistentSounds.TryGetValue(persistentSound, out player);
        
    }
}