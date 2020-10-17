using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpookuleleGames.StateMachine
{
    public interface IState
    {
        void Tick();
        void OnEnter(IState previous);
        void OnExit(IState next);
    }
}