using System.Collections;
using UnityEngine;
using SpookuleleGames.Audio;
using SpookuleleGames.ServiceLocator;

namespace GameJam2020
{
    public class GameStartOpeningAnimation : MonoBehaviour
    {
        [SerializeField] private SimplePersistentSound gameMusic;
        [SerializeField] private SimpleOneShot fadeSound;
        [SerializeField] private CanvasGroup[] groups;

        private void Start()
        {
            StartCoroutine(Opener());
            ServiceLocator.GetService<AudioManager>().PlayPersistentSound(gameMusic);
        }

        IEnumerator Opener()
        {
            for (int i = 0; i < groups.Length; i++)
            {
                groups[i].alpha = 0f;
            }

            yield return new WaitForSeconds(3f);

            AudioManager audioManager = ServiceLocator.GetService<AudioManager>();

            float t = 0f;
            for (int i = 0; i < groups.Length; i++)
            {
                t = 0f;
                audioManager.PlayOneShot(fadeSound);
                while (t < 1.1f)
                {
                    t += Time.deltaTime;
                    groups[i].alpha = t;
                    yield return null;
                }

                yield return new WaitForSeconds(3f);
            }
        }
    }
}