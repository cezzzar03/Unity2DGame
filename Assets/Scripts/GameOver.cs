using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text resultText;
    public Button playAgainButton;
    public Button mainMenuButton;
    public Button quitButton;

    void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        quitButton.onClick.AddListener(QuitGame);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    public void ShowGameOver(string message)
    {
        gameObject.SetActive(true);
        resultText.text = message;
    }

     void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

     void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

     void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}