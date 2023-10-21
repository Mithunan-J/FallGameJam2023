using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatFollow : MonoBehaviour
{
    GameObject player;
    public float speed;
    public float distance;
    public float stoppingDistance = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        
        //Might remove later
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        ///end

        

        if(distance > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}
