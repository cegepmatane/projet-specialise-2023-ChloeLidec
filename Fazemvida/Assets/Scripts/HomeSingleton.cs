using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomeSingleton 
{
    private static HomeSingleton instance;
    private PlayerSingleton player = PlayerSingleton.Instance();
    private bool inHome;
    private Vector3 housePos;
    private Vector3 playerPos;

    private HomeSingleton()
    {
       this.inHome = false;
    }

    public static HomeSingleton Instance()
    {
        {
            if (instance == null)
            {
                instance = new HomeSingleton();
            }
            return instance;
        }
    }

    public bool IsHouseOfPlayer(Vector3 housePos)
    {
        //cget absolute value of the difference between the player's house and the house that is being checked
        float x = Mathf.Abs(player.GetHousePosition().x - housePos.x);
        float y = Mathf.Abs(player.GetHousePosition().y - housePos.y);
        float z = Mathf.Abs(player.GetHousePosition().z - housePos.z);
        if (x < 0.8f && y < 0.5f && z < 0.8f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetInHome(bool inHome)
    {
        this.inHome = inHome;
    }

    public bool GetInHome()
    {
        return inHome;
    }

    public void SetHouse(Vector3 housePos)
    {
        this.housePos = housePos;
    }

    public Vector3 GetHousePos()
    {
        return housePos;
    }

    public void SetPlayerPos(Vector3 playerPos)
    {
        this.playerPos = playerPos;
    }

    public Vector3 GetPlayerPos()
    {
        return playerPos;
    }

    public void DeleteInstance()
    {
        instance = null;
    }
}
