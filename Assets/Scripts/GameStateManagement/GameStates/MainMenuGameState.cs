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
        [SerializeField] Inventory playerInventory;
        protected override SceneData SceneData => mainMenuScene;

        [SerializeField] private SimplePersistentSound mainMenuMusic;
        public bool PlayGame { get; private set; }

        private PersistentSoundPlayer _musicPlayer;

        public override void OnEnter(IState previous)
        {
            base.OnEnter(previous);
            PlayGame = false;
        }

        protected override void OnSceneLoaded()
        {
            base.OnSceneLoaded();
            _musicPlayer = ServiceLocator.GetService<AudioManager>().PlayPersistentSound(mainMenuMusic);
        }

        public override void OnExit(IState next)
        {
            base.OnExit(next);
            playerInventory.ClearInventory();
        }

        public void StartGame()
        {
            Debug.Log("PLAY!");
            PlayGame = true;
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}