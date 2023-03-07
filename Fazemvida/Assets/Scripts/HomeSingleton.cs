using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomeSingleton 
{
    private static HomeSingleton instance;
    private PlayerSingleton player;
    private bool inHome;
    private GameObject house;
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

    public bool IsHouseOfPlayer(GameObject house)
    {
        if (house.transform.position == player.GetHousePosition())
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

    public void SetHouse(GameObject house)
    {
        this.house = house;
    }

    public GameObject GetHouse()
    {
        return house;
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
