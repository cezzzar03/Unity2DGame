using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Rigidbody2D rb2;
    private bool move_right2;
    private bool move_left2;
    private bool jump2;
    private bool ground2;

    void Update()
    {
        move_right2 = Input.GetKey(KeyCode.RightArrow);
        move_left2 = Input.GetKey(KeyCode.LeftArrow);
        jump2 = Input.GetKey(KeyCode.UpArrow);

        if (jump2 && !ground2)
        {
            rb2.velocity = new Vector2(rb2.velocity.x, 12f);
            ground2 = true;
        }

        if (move_right2)
        {
            rb2.velocity = new Vector2(5f, rb2.velocity.y);
        }
        else if (move_left2)
        {
            rb2.velocity = new Vector2(-5f, rb2.velocity.y);
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coliziuni"))
        {
            ground2 = false;
        }
    }

}