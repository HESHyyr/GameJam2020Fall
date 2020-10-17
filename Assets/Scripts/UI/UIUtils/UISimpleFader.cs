using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameJam2020
{
    public class UISimpleFader : MonoBehaviour
    {
        [SerializeField] float delay = 3f;
        [SerializeField] float fadeOutSpeed = 1f;
        [SerializeField] CanvasGroup alphaGroup;

        private void Start()
        {
            StartCoroutine(FadeCoroutine());
        }

        IEnumerator FadeCoroutine()
        {
            yield return new WaitForSeconds(delay);
            float t = 0f;
            while (t < 1.1f)
            {
                t += Time.deltaTime * fadeOutSpeed;

                alphaGroup.alpha = 1 - t;

                yield return null;
            }

            Destroy(gameObject);
        }

    }
}