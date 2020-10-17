using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GameJam2020
{
    public class MainMenuOpeningAnimation : MonoBehaviour
    {

        [SerializeField] Image bunnyIcon;
        [SerializeField] CanvasGroup alphaMenu;

        readonly AnimationCurve CURVE = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        void Start()
        {
            StartCoroutine(Opener());
        }

        IEnumerator Opener()
        {
            bunnyIcon.rectTransform.anchoredPosition = Vector2.zero;
            alphaMenu.alpha = 0f;

            yield return new WaitForSeconds(6.0f);
            float t = 0f;

            while (t < 1.1f)
            {
                t += Time.deltaTime * .25f;
                float bunnyEval = CURVE.Evaluate(t * 1.5f);
                bunnyIcon.rectTransform.anchoredPosition = Vector3.up * 350f * bunnyEval;
                float alphaEval = CURVE.Evaluate(t * 2f - 1f);
                alphaMenu.alpha = alphaEval;
                yield return null;
            }

        }

    }
}