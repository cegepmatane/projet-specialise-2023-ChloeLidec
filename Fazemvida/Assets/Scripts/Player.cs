using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    [SerializeField]
    public string playerName;
    [SerializeField]
    public int playerMoney;
    public Vector3 playerPosition;
    public Vector3 house;

    
    public Player(string name, int money)
    {
        playerName = name;
        playerMoney = money;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetMoney()
    {
        return playerMoney;
    }

    public Vector3 GetPosition()
    {
        return playerPosition;
    }

    public Vector3 GetHousePosition()
    {
        return house;
    }
}
