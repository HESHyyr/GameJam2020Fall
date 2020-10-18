using GameJam2020.GameManagement;
using SpookuleleGames.SceneManagement;
using SpookuleleGames.StateMachine;
using SpookuleleGames.Audio;
using UnityEngine;
using System.Collections.Generic;
using SpookuleleGames.ServiceLocator;

namespace GameJam2020
{

    [CreateAssetMenu(menuName = "GameManagement/EnvironmentState")]
    public class EnvironmentGameState : GameState
    {
        [SerializeField] SceneData environmentScene;

        [System.Serializable]
        public struct Door
        {
            public SimpleOneShot travelSound;
            public EnvironmentGameState destinationEnvironment;
        }

        [SerializeField] List<Door> doors;

        protected override SceneData SceneData => environmentScene;

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
        }

        public void LoadEnvironment()
        {
            GameStateManager.SetState(this);
        }

        public void TryDoor(EnvironmentGameState destination)
        {


            for(int i = 0; i < doors.Count; i++)
            {
                if(doors[i].destinationEnvironment == destination)
                {
                    ServiceLocator.GetService<AudioManager>().PlayOneShot(doors[i].travelSound);
                    doors[i].destinationEnvironment.LoadEnvironment();
                }
            }
        }
    }
}