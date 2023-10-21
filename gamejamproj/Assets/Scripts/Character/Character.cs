using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    
    //shared variables
    public float health;
    public float moveSpeed;
    
    public float GetHealth()
    {
        return health;
    }
    public virtual void TakeDamage(float n)
    {
        health -=n;
    }
    public float GetSpeed()
    {
        return moveSpeed;
    }
   
    public void IncreaseSpeed(float n)
    {
        moveSpeed +=n;
    }
    public void DecreaseSpeed(float n)
    {
        moveSpeed -=n;
    }
    public void IncreaseHealth(float n)
    {
        health +=n;
    }
}
