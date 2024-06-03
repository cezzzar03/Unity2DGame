using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool move_right;
    private bool move_left;
    private bool jump;
    private bool ground;

    void Update()
    {
        move_right = Input.GetKey(KeyCode.D);
        move_left = Input.GetKey(KeyCode.A);
        jump = Input.GetKey(KeyCode.W); 

        if (jump && !ground)
        {
            rb.velocity = new Vector2(rb.velocity.x, 12f);
            ground = true;
        }
        if (move_right)
        {
            rb.velocity = new Vector2(5f, rb.velocity.y);
        }
        else if (move_left)
        {
            rb.velocity = new Vector2(-5f, rb.velocity.y);
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Coliziuni"))
        {
            ground = false;
        }
    }
}