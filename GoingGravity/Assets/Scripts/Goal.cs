using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public GameObject winPanel;
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI playerTimeText;
    public TextMeshProUGUI fastestTimeText;
    public Achievement achievementScript;

    public Unlockable UnlockManager;
    public Achievement AchievementManager;

    private float fastestTime = float.MaxValue;

    public UnityEvent uponReset;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float playerTime = FindObjectOfType<Timer>().ElapsedTime;

            if (playerTime < fastestTime)
            {
                fastestTime = playerTime;
            }

            AchievementManager.CheckAchievementConditions();
            UnlockManager.Load();

            winPanel.SetActive(true);
            headerText.text = "You Win!";
            playerTimeText.text = "Your Time: " + playerTime.ToString("F1") + " seconds";
            fastestTimeText.text = "Fastest Time: " + fastestTime.ToString("F1") + " seconds";

            Time.timeScale = 0f;
        }
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        uponReset?.Invoke();
    }
}

