using SpookuleleGames.Audio;
using SpookuleleGames.SceneManagement;
using SpookuleleGames.ServiceLocator;
using SpookuleleGames.StateMachine;
using UnityEngine;

namespace GameJam2020
{

    [CreateAssetMenu(menuName = "GameManagement/EnvironmentState")]
    public class EnvironmentGameState : GameState
    {
        [SerializeField] SceneData environmentScene;
        protected override SceneData SceneData => environmentScene;

        private PersistentSoundPlayer _musicPlayer;

        public override void OnEnter(IState previous)
        {
            base.OnEnter(previous);
        }

        protected override void OnSceneLoaded()
        {
            base.OnSceneLoaded();
        }

        public override void OnExit(IState next)
        {
            base.OnExit(next);
            _musicPlayer.FadeOut(1f);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}