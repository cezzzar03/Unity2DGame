using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioSource audioSource;
  
    void Update()
    {
        if(rb.velocity.magnitude > 10f)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10f);
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("players"))
        {
            audioSource.Play();
        }
    }
}