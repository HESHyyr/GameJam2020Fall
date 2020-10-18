using SpookuleleGames.Audio;
using SpookuleleGames.ServiceLocator;
using System.Collections;
using UnityEngine;

namespace GameJam2020
{
    public class GameStartOpeningAnimation : MonoBehaviour
    {
        [SerializeField] private SimplePersistentSound mainTheme;
        [SerializeField] private CanvasGroup[] groups;

        private void Start()
        {
            StartCoroutine(Opener());
        }

        IEnumerator Opener()
        {
            for (int i = 0; i < groups.Length; i++)
            {
                groups[i].alpha = 0f;
            }

            yield return new WaitForSeconds(3f);

            float t = 0f;
            for (int i = 0; i < groups.Length; i++)
            {
                
                t = 0f;
                while (t < 1.1f)
                {
                    t += Time.deltaTime;
                    groups[i].alpha = t;
                    yield return null;
                }
                yield return new WaitForSeconds(3f);
            }

            if(ServiceLocator.GetService<AudioManager>().TryGetPersistentSound(mainTheme, out PersistentSoundPlayer player)) {

                player.FadeOut(2f);

            }

        }



    }
}