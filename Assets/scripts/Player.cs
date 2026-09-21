using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Turns turns;
    [SerializeField] GameObject overworld;
    
    Rigidbody2D rb;

    float moveSpeed = 6;

    bool dead = false;

    float moveHorizontal, moveVertical;
    Vector2 movement;

    int facingDirection = 1; // 1 = right, -1 = left

    bool notalreadyavtice = true;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        
        if (dead)
        {
            movement = Vector2.zero;
            
            return;
        }

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized.normalized;

        

        if (movement.x != 0)
            facingDirection = movement.x > 0 ? 1 : -1;

        transform.localScale = new Vector2(facingDirection, 1);
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }


}

