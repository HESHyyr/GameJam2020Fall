using SpookuleleGames.Utilities;
using System.Collections;
using UnityEngine;

namespace SpookuleleGames.SceneManagement
{
    public class LoadingScreenUI : MonoBehaviour
    {

        [SerializeField] Canvas canvas;
        [SerializeField] Camera loadScreenCamera;
        [SerializeField] CanvasGroup alphaGroup;

        bool _startFade = false;

        private void Start()
        {
            SceneLoader.OnSceneLoadProcessStart += Open;
            SceneLoader.OnSceneLoadProcessEnd += Close;
        }

        private void OnDestroy()
        {
            SceneLoader.OnSceneLoadProcessStart -= Open;
            SceneLoader.OnSceneLoadProcessEnd -= Close;
        }

        IEnumerator _fadeCoroutine;
        private void Open()
        {
            if (_fadeCoroutine != null) StopCoroutine(_fadeCoroutine);
            _fadeCoroutine = FadeCoroutine();
            StartCoroutine(_fadeCoroutine);
        }

        private void Close()
        {
            _startFade = true;
        }

        IEnumerator FadeCoroutine()
        {
            canvas.enabled = true;
            loadScreenCamera.enabled = true;
            alphaGroup.alpha = 1f;

            while (!_startFade) yield return null;

            float t = 0f;

            yield return new WaitForSeconds(.5f);
            
            while(t < 1.1f)
            {
                t += Time.deltaTime;
                alphaGroup.alpha = 1 - t;
                yield return null;
            }

            canvas.enabled = false;
            loadScreenCamera.enabled = false;
        }
    }
}