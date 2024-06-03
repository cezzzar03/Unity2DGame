using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time = 120f;
    private bool isPaused = false;

    public Text text;
    public GameObject gameOverPanel;
    public GameOver gameResultScreen;

    public Text homeScoreText;
    public Text awayScoreText;

    public GoalTrigger goalTrigger1;
    public GoalTrigger goalTrigger2;

    void Start()
    {
        text.text = Mathf.RoundToInt(time).ToString();
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!isPaused && time > 0)
        {
            time -= Time.deltaTime;
            text.text = Mathf.RoundToInt(time).ToString();
        }
        else if (time <= 0)
        {
            ShowGameOverScreen();
            PauseTimer();
            goalTrigger1.isGameActive = false;
            goalTrigger2.isGameActive = false;
        }
    }

    public void PauseTimer()
    {
        isPaused = true;
    }

    public void ResumeTimer()
    {
        isPaused = false;
    }

     void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);

        if (int.TryParse(homeScoreText.text, out int homeScore) && int.TryParse(awayScoreText.text, out int awayScore))
        {
            if (homeScore > awayScore)
            {
                gameResultScreen.ShowGameOver("HOME TEAM WINS!");
            }
            else if (awayScore > homeScore)
            {
                gameResultScreen.ShowGameOver("AWAY TEAM WINS!");
            }
            else
            {
                gameResultScreen.ShowGameOver("IT IS A DRAW!");
            }
        }
    }
}
