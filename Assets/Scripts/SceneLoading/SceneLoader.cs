using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpookuleleGames.SceneManagement
{
    public class SceneLoader
    {
        #region statics
        public static string LOADING_PROGRESS_DESCRIPTION = "";
        public static float LOADING_PROGRESS_PERCENT => loadingProgress * 100f;
        public static bool CURRENTLY_LOADING { get; private set; }

        static List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

        private static float loadingProgress = 0f;

        public static event Action OnSceneLoadProcessStart = delegate { };
        public static event Action OnSceneLoadProcessEnd = delegate { };

        #endregion
        #region loading & unloading
        public static void LoadScene(SceneData scene) => LoadScene(scene.BuildIndex);
        public static void LoadScene(int sceneIndex)
        {
            if (sceneIndex == -1) { return; } //If -1, return
            if (SceneManager.GetSceneByBuildIndex(sceneIndex).isLoaded) { return; } //If scene alr loaded, return
            AddSceneOperation(SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive));
        }
        public static void UnloadScene(SceneData scene) => UnloadScene(scene.BuildIndex);
        public static void UnloadScene(int sceneIndex)
        {
            if (sceneIndex == -1) { return; } //If -1, return
            if (!SceneManager.GetSceneByBuildIndex(sceneIndex).isLoaded) { return; } //If scene not loaded, return
            AddSceneOperation(SceneManager.UnloadSceneAsync(sceneIndex));
        }
        public static void UnloadAll()
        {
            int sceneCount = SceneManager.sceneCount;
            for (int i = sceneCount-1; i > 0; i--)
            {
                int index = SceneManager.GetSceneAt(i).buildIndex;
                UnloadScene(index);
            }
        }

        #endregion
        #region progress updating
        private static void AddSceneOperation(AsyncOperation operation)
        {
            if (scenesLoading.Contains(operation)) { return; }
            scenesLoading.Add(operation);
            UpdateSceneLoadProgress();
        }
        private async static void UpdateSceneLoadProgress()
        {
            if (CURRENTLY_LOADING) { return; }
            CURRENTLY_LOADING = true;
            OnSceneLoadProcessStart();

            for (int i = 0; i < scenesLoading.Count; i++)
            {
                while (!scenesLoading[i].isDone)
                {
                    loadingProgress = 0f;
                    foreach (AsyncOperation op in scenesLoading)
                    {
                        loadingProgress += op.progress;
                    }

                    loadingProgress = (loadingProgress) / scenesLoading.Count;
                    await Task.Yield();
                }
            }

            await Task.Delay(1000);

            scenesLoading.Clear();
            CURRENTLY_LOADING = false;
            OnSceneLoadProcessEnd();
        }

        #endregion
    }
}