using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    [SerializeField]
    public string playerName;
    [SerializeField]
    public int playerMoney;

    
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


}
