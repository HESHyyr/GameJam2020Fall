using Sirenix.OdinInspector;
using UnityEditor;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpookuleleGames.SceneManagement
{
    [CreateAssetMenu(fileName = "NewSceneData", menuName = "SceneManagement/SceneData")]
    public class SceneData : ScriptableObject
    {
        public int BuildIndex => buildIndex;
        [SerializeField, ReadOnly] private int buildIndex;

        public void LoadScene(bool additive = true)
        {
            if (!additive) { SceneLoader.UnloadAll(); }
            SceneLoader.LoadScene(BuildIndex);
        }

        //ONLY FOR USE IN UNITY EDITOR
#if UNITY_EDITOR
        [InfoBox("This scene is not in the build settings.", InfoMessageType.Error, "notInBuildSettings")]
        [SerializeField, OnValueChanged("UpdateBuildIndex")] SceneAsset scene;
        [SerializeField, ReadOnly] private string path;

        public string Path => path;
        private bool notInBuildSettings => buildIndex == -1;

        void UpdateBuildIndex()
        {
            path = AssetDatabase.GetAssetPath(scene);
            buildIndex = SceneUtility.GetBuildIndexByScenePath(path);
        }

        //[OnOpenAssetAttribute(1)]
        private static bool OnOpenAsset(int instanceID, int line)
        {
            ((SceneData)EditorUtility.InstanceIDToObject(instanceID)).LoadSceneEditor();
            return false;
        }

        [Button("Load Scene")]
        public void LoadSceneEditor()
        {
            EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex(0), OpenSceneMode.Single);
            LoadSceneAdditiveEditor();
        }

        //ONLY FOR USE IN UNITY EDITOR
        [Button("Load Scene Additive")]
        public void LoadSceneAdditiveEditor()
        {
            EditorSceneManager.OpenScene(path, OpenSceneMode.Additive);

            if (SceneManager.sceneCount > 1)
                SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));

            //EditorSceneManager.MarkSceneDirty(SceneManager.GetSceneAt(0));
        }

        public void OnEnable() => UpdateBuildIndex();

#endif
    }
}