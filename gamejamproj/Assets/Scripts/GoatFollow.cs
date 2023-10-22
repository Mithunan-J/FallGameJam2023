using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatFollow : MonoBehaviour
{
    GameObject player;
    public float speed;
    public float distance;
    public float stoppingDistance = 0.5f;
    public bool follow = true;
    Animator goat_animator;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       goat_animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(follow == true)
        {
            goat_animator.SetBool("isMoving", true);
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            //Might remove later
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            ///end



            if (distance > stoppingDistance)
            {
                goat_animator.SetBool("isMoving", true);
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.fixedDeltaTime);
                //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            else
            {
                goat_animator.SetBool("isMoving", false);
            }
        } 
        else
        {
            //goat_animator.SetBool("isMoving", false);
        }
        
        
    }

    IEnumerator GoatThrownCooldown()
    {
        goat_animator.SetBool("isFlying", true);
        Debug.Log("Goat Cooldown started");
        follow = false;
        float currentTime = 0f;
        float targetTime = 3f;

        while(currentTime < targetTime)
        {
            currentTime += Time.deltaTime;
            Debug.Log("Current Time: " + currentTime);
            yield return null;
        }
        follow = true;
        Debug.Log("Goat cooldown ended");
        goat_animator.SetBool("isFlying", false);
    }

    public void StartGoatCooldown()
    {
        StartCoroutine(GoatThrownCooldown());
    }
}
