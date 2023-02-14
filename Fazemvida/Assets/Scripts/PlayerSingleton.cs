using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton 
{
    private static PlayerSingleton instance;

    public string playerName;
    public int playerMoney;
    public Vector3 playerPosition;

    private PlayerSingleton()
    {
        playerName = "";
        playerMoney = 0;
    }
    public static PlayerSingleton Instance()
    {
        {
            if (instance == null)
            {
                instance = new PlayerSingleton();
            }
            return instance;
        }
    }

    public void AddMoney(int amount)
    {
        playerMoney += amount;
    }

    public void RemoveMoney(int amount)
    {
        playerMoney -= amount;
    }

    public void SetMoney(int amount)
    {
        playerMoney = amount;
    }
    public void SetName(string name)
    {
        playerName = name;
    }

    public void SetPosition(Vector3 position)
    {
        playerPosition = position;
    }

}
