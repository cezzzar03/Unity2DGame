using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoalTrigger : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
    public TMP_Text goalMessageText;

    public Transform player1;
    public Transform player2;
    public Transform ball;

    public AudioSource backgroundAudioSource;
    public AudioSource cheerAudioSource;
    public ParticleSystem confettiParticleSystem;

    public Timer timer;
    public bool isGameActive = true;

    public BoxCollider2D goal1Collider;
    public BoxCollider2D goal2Collider; 

    void Start()
    {
        confettiParticleSystem.Stop();
        goalMessageText.enabled = false;
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (isGameActive && collision.gameObject.CompareTag("Ball"))
        {
            score++;
            scoreText.text = score.ToString();

            backgroundAudioSource.volume = 0.3f;
            cheerAudioSource.volume = 10.0f;
            cheerAudioSource.Play();

            confettiParticleSystem.Play();

            goalMessageText.enabled = true;

            goal1Collider.enabled = false;
            goal2Collider.enabled = false;

            timer.PauseTimer();
            StartCoroutine(ResumeGame(cheerAudioSource.clip.length));
        }
    }

    private IEnumerator ResumeGame(float delay)
    {
        yield return new WaitForSeconds(delay);
            
        backgroundAudioSource.volume = 1.0f;
        confettiParticleSystem.Stop();

        goalMessageText.enabled = false;

        goal1Collider.enabled = true;
        goal2Collider.enabled = true;

        player1.position = new Vector3(-3, 0.07940745f, 0);
        player2.position = new Vector3(3, 0.07940745f, 0);
        ball.position = new Vector3(-0.2f, 0.52f, 0.002843655f);
        ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    
        timer.ResumeTimer();
    }
}