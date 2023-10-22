using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Character
{
    //what variables does the player need?
    public Queue<GameObject> goats = new Queue<GameObject>(); // a list storing all the goats the player has collected.

    //game over UI
    public GameObject gameOver;
    
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
         if (other.tag == "Enemy") //change this tag later
        {
            TakeDamage(1); //other.getcomponent....damage
            //push back?
            Vector2 impulse = (other.transform.position - transform.position).normalized;
           // GetComponent<Rigidbody2D>().AddForce(impulse *1.0f, ForceMode2D.Impulse);
            
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
