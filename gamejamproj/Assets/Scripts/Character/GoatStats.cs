using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public enum GoatType
{
    Normal,
    Fire,
    Ice,
    Health,
    Speed,
    Chunky,
    Poison

}

public class GoatStats : MonoBehaviour
{
    GoatType type;
    Color goatColour;
    //player reference
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        //spawning in
        //get the current material
        goatColour = GetComponent<SpriteRenderer>().color;
        //get player
        player = GameObject.FindGameObjectWithTag("Player");

        //ignore player collissions
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //Physics2D.IgnoreLayerCollision(player.layer, gameObject.layer);
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

        //assign random goat type
        type = (GoatType)Random.Range(0, System.Enum.GetValues(typeof(GoatType)).Length);

        //for each goat type, change the material/colour of it? to distinguish
        //also establish any permanent/immediate benefits of goats
        switch (type)
        {
            case GoatType.Fire:
               { 
                    goatColour = Color.red;
                    GetComponent<SpriteRenderer>().color = goatColour;
                    this.gameObject.name = "Fire Goat";
               }
                break;
            case GoatType.Ice:
                {
                    goatColour = Color.blue;
                    GetComponent<SpriteRenderer>().color = goatColour;
                    this.gameObject.name = "Ice Goat";
                }
                break;
            case GoatType.Health:
                {
                    goatColour = Color.magenta;
                    GetComponent<SpriteRenderer>().color = goatColour;
                    this.gameObject.name = "Health Goat";
                }
                break;
            case GoatType.Speed:
                {
                    goatColour = Color.green;
                    GetComponent<SpriteRenderer>().color = goatColour;
                    player.GetComponent<PlayerStats>().IncreaseSpeed(1); //CHANGE THIS NUMBER ACCORDINGLY, HOW MUCH TO INCREASE SPEED
                    this.gameObject.name = "Speed Goat";
                }
                break;
            case GoatType.Chunky:
                {
                    goatColour = Color.yellow;
                    GetComponent<SpriteRenderer>().color = goatColour;
                    this.gameObject.name = "Chunky Goat";
                }
                break;
            case GoatType.Poison:
                {
                    goatColour = Color.grey;
                    GetComponent<SpriteRenderer>().color = goatColour;
                    this.gameObject.name = "Poison Goat";
                }
                break;
            default:
                break;
        }

        player.GetComponent<PlayerStats>().AddGoat(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GoatType GetGoatType()
    {
        return type;
    }
    public void FireGoat()
    {
        //different goats that have effects right away
        switch (type)
        {
            case GoatType.Health:
                {
                    //INCREASE PLAYER HEALTH
                    player.GetComponent<PlayerStats>().IncreaseHealth(1); //ADJUST THIS AS NECESSARY
                }
                break;
            case GoatType.Chunky:
                {
                    this.gameObject.transform.localScale.Set(0.3f, 0.3f, 0.3f);
                }
                break;
            default:
                break;
        }
    }


}
