using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    
    //shared variables
    public int health;
    public int moveSpeed;
    
    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int n)
    {
        health = n;
    }
    public int GetSpeed()
    {
        return moveSpeed;
    }
    public void SetSpeed(int n)
    {
        moveSpeed = n;
    }
}
