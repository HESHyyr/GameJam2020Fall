using SpookuleleGames.SceneManagement;
using SpookuleleGames.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam2020
{
    [CreateAssetMenu(menuName = "GameManagement/BasicGameState")]
    public class BasicGameState : GameState
    {

        [SerializeField] SceneData scene;
        protected override SceneData SceneData => scene;
        public bool StateEnd { get; private set; }
        public override void OnEnter(IState previous)
        {
            base.OnEnter(previous);
            StateEnd = false;
        }

        public void EndState() => StateEnd = true;
    }
}