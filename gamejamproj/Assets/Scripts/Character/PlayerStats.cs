using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Character
{
    //what variables does the player need?
    public Queue<GameObject> goats = new Queue<GameObject>(); // a list storing all the goats the player has collected.

    //game over UI
    public GameObject gameOver;
    public GameObject explosion;

     public Slider healthBar;
    
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
         //health bar
        healthBar.value = health/20;
        Debug.Log("Health Remaining: " + health);
        //kill PLAYER
        if (health <=0)
        {
            //pause game
            Time.timeScale =0; 
            //game over UI screen
            gameOver.SetActive(true);
            explosion.SetActive(true);
            explosion.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
         }
    }
    public override void IncreaseHealth(float n)
    {
        base.IncreaseHealth(n);
        //update health bar
        healthBar.value = health/20;
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
