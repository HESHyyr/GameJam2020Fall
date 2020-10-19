using GameJam2020;
using GameJam2020.GameManagement;
using SpookuleleGames.Audio;
using SpookuleleGames.ServiceLocator;
using SpookuleleGames.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootleg : MonoBehaviour
{

    [SerializeField] Item matchesItem;
    [SerializeField] Item candleHolderItem;
    [SerializeField] Item candleItem;
    [SerializeField] BasicGameState amongUsState;

    private void Start()
    {
        Inventory inventory = ServiceLocator.GetService<Inventory>();

        if(inventory.ContainsItem(matchesItem) && inventory.ContainsItem(candleHolderItem) && inventory.ContainsItem(candleItem))
        {

        } else
        {
            Destroy(gameObject);
        }
    }

    public void GoToAmongUs()
    {
        MethodDelayer.DelayMethodByTimeAsync(() => GameStateManager.SetState(amongUsState), 5.0f);
    }

}
