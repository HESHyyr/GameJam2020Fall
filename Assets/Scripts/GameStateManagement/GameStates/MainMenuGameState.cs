using SpookuleleGames.Audio;
using SpookuleleGames.SceneManagement;
using SpookuleleGames.ServiceLocator;
using SpookuleleGames.StateMachine;
using UnityEngine;

namespace GameJam2020 {

    [CreateAssetMenu(fileName = "NewMenuState", menuName = "GameManagement/MenuState")]
    public class MainMenuGameState : GameState
    {
        [SerializeField] SceneData mainMenuScene;
        protected override SceneData SceneData => mainMenuScene;

        [SerializeField] private SimplePersistentSound mainMenuMusic;
        public bool PlayGame { get; private set; }
        public bool LoadGame { get; private set; }

        private PersistentSoundPlayer _musicPlayer;

        public override void OnEnter(IState previous)
        {
            base.OnEnter(previous);
            PlayGame = false;
            LoadGame = false;
        }

        protected override void OnSceneLoaded()
        {
            base.OnSceneLoaded();
            _musicPlayer = ServiceLocator.GetService<AudioManager>().PlayPersistentSound(mainMenuMusic);
        }

        public override void OnExit(IState next)
        {
            base.OnExit(next);
            _musicPlayer.FadeOut(1f);
        }

        public void StartGame() => PlayGame = true;
        public void StartLoadGame() => LoadGame = true;
    }
}