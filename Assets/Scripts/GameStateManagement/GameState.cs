using Sirenix.OdinInspector;
using SpookuleleGames.SceneManagement;
using SpookuleleGames.StateMachine;
using UnityEngine;

public abstract class GameState : ScriptableObject, IState
{
    protected virtual SceneData SceneData { get; }

    public virtual void OnEnter(IState previous)
    {
        SceneLoader.LoadScene(SceneData);
        SceneLoader.OnSceneLoadProcessEnd += OnSceneLoaded;
    }

    protected virtual void OnSceneLoaded()
    {
        SceneLoader.OnSceneLoadProcessEnd -= OnSceneLoaded;
    }

    public virtual void OnExit(IState next)
    {
        SceneLoader.UnloadScene(SceneData);
    }

    public virtual void Tick() { }

#if UNITY_EDITOR

    [Button("Load Game State")]
    void LoadGameStateEditor() => SceneData.LoadSceneEditor();

#endif

}
