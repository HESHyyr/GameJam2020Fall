using SpookuleleGames.ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameJam2020
{
    public class ActionLogManager : MonoBehaviour
    {
        [SerializeField] ObjectPool actionLogPool;
        [SerializeField] float timer;

        private static ActionLogManager INSTANCE;



        private void Awake()
        {
            INSTANCE = this;
        }

        public static void LogActionStatic(string s)
        {
            INSTANCE.LogAction(s);
        }

        public void LogAction(string s)
        {
            ActionLog actionLog = actionLogPool.Get().GetComponent<ActionLog>();
            actionLog.transform.SetParent(transform);
            actionLog.transform.SetSiblingIndex(actionLog.transform.parent.childCount-1);
            actionLog.SetLabel(s);
        }

    }
}
