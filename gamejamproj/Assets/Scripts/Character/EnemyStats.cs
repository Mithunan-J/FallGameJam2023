using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class EnemyStats : Character
{
    Transform player;
    public GameObject goatPrefab;

    public GameObject deathEffect;
    public GameObject fireEffect;

    bool poisoned = false;
    public float poisonTicker;
    float nextPoisonTime;

    public override void TakeDamage(float n)
    {
        base.TakeDamage(n);
        //kill enemy
        if (health <=0)
        {
            //make death particle effect appear
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            //Spawn New Goat
            GameObject newGoat;
            newGoat = Object.Instantiate(goatPrefab, GameObject.FindWithTag("Player").transform.position, Quaternion.identity);


            Destroy(gameObject);            
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.Log(GetSpeed());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //move enemy towards player
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed);

        //if poisoined
        if (poisoned)
        {
            //do poison damage every x amount of time
            if (Time.time > nextPoisonTime)
            {
                nextPoisonTime = Time.time + poisonTicker;
                //damage enemy
                TakeDamage(0.1f); //how much does poison damage do?
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goat") //change this tag later?
        {
            float damage = 1; //default amount of damage dealt
            //check goat type
            switch (other.GetComponent<GoatStats>().GetGoatType())
            {
                case GoatType.Fire:
               { 
                    damage *=2; //twice as effective. can change this. 
                    //add fire effect?
                    //make death particle effect appear
                    Instantiate(fireEffect, transform.position, Quaternion.identity);
                    //+AOE? aoe on the effect?
               }
                break;
            case GoatType.Ice:
                {
                    //slow down enemy
                    DecreaseSpeed(-1); //change this later
                    //add ice effect?
                }
                break;
            case GoatType.Poison:
                {
                    poisoned = true;
                }
                break;
            case GoatType.Chunky:
                {
                    damage += 2;
                }
                break;
            default:
                break;
            }
            TakeDamage(damage); //other.getcomponent....damage
            
        }
        if (other.tag == "Fire") //taking damage from fire AOE
        {
            TakeDamage(0.1f); //small damage, can change later
        }
        if (other.tag == "Player") //if enemy collides with player, what happens?
        {
            GameObject _player = GameObject.FindGameObjectWithTag("Player");
            _player.GetComponent<PlayerStats>().TakeDamage(1);
        }
    }
}
