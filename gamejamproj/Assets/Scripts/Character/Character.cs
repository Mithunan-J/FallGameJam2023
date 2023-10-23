using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    
    //shared variables
    public float health;
    public float moveSpeed;

    protected float MAX_SPEED = 5;
    
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
    public virtual void IncreaseHealth(float n)
    {
        health +=n;
    }
}
