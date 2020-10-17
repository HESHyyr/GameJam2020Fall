using System;
using UnityEngine;
using SpookuleleGames.StateMachine;
using SpookuleleGames.SceneManagement;
using GameJam2020;

namespace GameJam2020.GameManagement
{
    public class GameStateManager : MonoBehaviour
    {
        StateMachine _gameStateMachine;

        //These all inherit from GameState, and contain some specialized state
        [SerializeField] private MainMenuGameState mainMenu;
        [SerializeField] private EnvironmentGameState startingAreaEnvironmentState;

        private static GameStateManager INSTANCE;

        public static T GetCurrentState<T>() where T : IState { return (T) GetCurrentState(); }
        public static IState GetCurrentState() { return INSTANCE._gameStateMachine.CurrentState; }

        private void Awake()
        {
            INSTANCE = this;
        }

        private void Start()
        {
            SceneLoader.UnloadAll();
            Initialize();
        }

        private void Update()
        {
            _gameStateMachine.Tick();
        }

        void Initialize()
        {
            _gameStateMachine = new StateMachine();
            void AT(IState to, IState from, Func<bool> predicate) => _gameStateMachine.AddTransition(to, from, predicate);
            AT(mainMenu, startingAreaEnvironmentState, MainMenuPlay());


            _gameStateMachine.SetState(mainMenu);

            Func<bool> MainMenuPlay() => () => mainMenu.PlayGame;
            
        }

        public static void SetState(IState state)
        {
            INSTANCE._gameStateMachine.SetState(state);
        }
    }
}