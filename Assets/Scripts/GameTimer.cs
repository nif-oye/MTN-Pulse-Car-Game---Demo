using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public int minutes = 1;
    public int seconds = 30; 
    public TextMeshProUGUI countdownText; 
    private float totalTimeInSeconds;
    private bool isTimerRunning = false;

    void Start()
    {
        totalTimeInSeconds = (minutes * 60) + seconds;
        isTimerRunning = true; 
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (totalTimeInSeconds > 0)
            {
                totalTimeInSeconds -= Time.deltaTime;

                int remainingMinutes = Mathf.FloorToInt(totalTimeInSeconds / 60);
                int remainingSeconds = Mathf.FloorToInt(totalTimeInSeconds % 60);

                countdownText.text = string.Format("{0:00}:{1:00}", remainingMinutes, remainingSeconds);
            }
            else
            {
                totalTimeInSeconds = 0;
                isTimerRunning = false;
                countdownText.text = "00:00";
                Debug.Log("Countdown finished!");

                GameManager.instance.EndGame();
            }
        }
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        Debug.Log("Timer stopped.");
    }
}
