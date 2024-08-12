using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Utils; 

public class TimerController : Singleton<TimerController>
{
    public float startTime = 60f; // Timer starts at 60 seconds
    private float currentTime;
    public Text timerText; // UI Text to display the timer

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        // Decrease time
        currentTime -= Time.deltaTime;

        // Update the timer display
        timerText.text = currentTime.ToString("F2");

        // Check if time has run out
        if (currentTime <= 0)
        {
            EndGame();
        }
    }

    public void AddTime(float timeToAdd)
    {
        currentTime += timeToAdd;
    }

    void EndGame()
    {
        // End the game by loading a Main Menu scene or any other end game logic
        SceneManager.LoadScene(0); 
    }
}