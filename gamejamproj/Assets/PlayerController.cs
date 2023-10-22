using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;

    Vector2 movementInput;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    Vector2 mousePosition;

    //shooting mechanic
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 0.5f;

    Vector3 mouse_pos;
    Vector3 object_pos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    private void FixedUpdate()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success && movementInput.x > 0)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }

                if (!success && movementInput.y > 0)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

                animator.SetBool("isMoving", success);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            //set direction of sprite to movement direction
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }

        
    }

    public bool TryMove(Vector2 direction)
    {
        if(direction != Vector2.zero)
        {
            int count = rb.Cast(direction, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0) //when count is zero, there are no collisions present
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else //can't move if there is no direction to move in
        {
            return false;
        }
        
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 _direction = new Vector2(mousePosition.x - firePoint.position.x, mousePosition.y - firePoint.position.y);
        firePoint.transform.up = _direction;


        GameObject goatProjectile = GetComponent<PlayerStats>().GoatThrown(); //goat gets dequeued and re-entered into the back of the queue
        goatProjectile.GetComponent<GoatStats>().FireGoat();
        goatProjectile.transform.position = firePoint.position;
        goatProjectile.transform.rotation = firePoint.rotation;
        //goatProjectile.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //Object.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        goatProjectile.GetComponent<GoatFollow>().StartGoatCooldown();
        goatProjectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

        animator.SetTrigger("swordAttack");
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
