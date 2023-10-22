using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Character
{
    //what variables does the player need?
    public Queue<GameObject> goats = new Queue<GameObject>(); // a list storing all the goats the player has collected.

    //game over UI
    GameObject gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void TakeDamage(float n)
    {
        base.TakeDamage(n);
        //kill PLAYER
        if (health <=0)
        {
            //game over UI screen
            gameOver.SetActive(true);
         }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.tag == "EnemyProjectile") //change this tag later
        {
            TakeDamage(-1); //other.getcomponent....damage
            
        }
    }

    public void AddGoat(GameObject _goat)
    {
        goats.Enqueue(_goat);
    }

    public GameObject GoatThrown()
    {
        GameObject thrownGoat = goats.Dequeue();
        goats.Enqueue(thrownGoat);
        return thrownGoat;
    }
}
