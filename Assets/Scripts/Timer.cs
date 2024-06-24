using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeElapsed;
    private bool gameStarted;
    private bool isGameWin;
    [SerializeField] private GameManager gameManagerScript;

    // Screen Timer
    [SerializeField] private TMP_Text firstMinutes;
    [SerializeField] private TMP_Text secondMinutes;
    [SerializeField] private TMP_Text separator;
    [SerializeField] private TMP_Text firstSecond;
    [SerializeField] private TMP_Text secondSecond;
    [SerializeField] private TMP_Text textMillisecond;

    // Best Timer
    private float bestTime;
    [SerializeField] private TMP_Text bestFirstMinutes;
    [SerializeField] private TMP_Text bestSecondMinutes;
    [SerializeField] private TMP_Text bestSeparator;
    [SerializeField] private TMP_Text bestFirstSecond;
    [SerializeField] private TMP_Text bestSecondSecond;
    [SerializeField] private TMP_Text bestTextMillisecond;

    // Result
    [SerializeField] private TMP_Text resFinishTime;
    [SerializeField] private GameObject resNewBestBadge;

    public bool GameStarted { get => gameStarted; set => gameStarted = value; }
    public bool IsGameWin { get => isGameWin; set => isGameWin = value; }

    void Start()
    {
        ResetTimer();
        SetBestTimerDisplay();
        UpdateTimerDisplay(timeElapsed);
    }

    void Update()
    {
        if (GameStarted && !IsGameWin) {
            timeElapsed += Time.deltaTime;
            UpdateTimerDisplay(timeElapsed);
        }
    }

    public void StartTimer() {
        gameStarted = true;
    }

    public void ResetTimer()
    {
        timeElapsed = 0f;
        UpdateTimerDisplay(timeElapsed);
        Debug.Log(timeElapsed);
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = (time * 1000) % 1000;

        string currentTime = string.Format("{0:00}{1:00}{2:000}", minutes, seconds, milliseconds);
        firstMinutes.text = currentTime[0].ToString();
        secondMinutes.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
        textMillisecond.text = currentTime.Substring(4, 3);
    }

    public void SetBestTimerDisplay() {
        // Load Best Time
        if (PlayerPrefs.HasKey("time" + gameManagerScript.Level))
        {
            bestTime = PlayerPrefs.GetFloat("time" + gameManagerScript.Level);
            Debug.Log("Found");
        } else {
            Debug.Log("None");
            return;
        }

        float minutes = Mathf.FloorToInt(bestTime / 60);
        float seconds = Mathf.FloorToInt(bestTime % 60);
        float milliseconds = (bestTime * 1000) % 1000;

        string currentTime = string.Format("{0:00}{1:00}{2:000}", minutes, seconds, milliseconds);
        bestFirstMinutes.text = currentTime[0].ToString();
        bestSecondMinutes.text = currentTime[1].ToString();
        bestFirstSecond.text = currentTime[2].ToString();
        bestSecondSecond.text = currentTime[3].ToString();
        bestTextMillisecond.text = currentTime.Substring(4, 3);
    }

    public void SetResultTimerDisplay() {
        float minutes = Mathf.FloorToInt(timeElapsed / 60);
        float seconds = Mathf.FloorToInt(timeElapsed % 60);
        float milliseconds = (timeElapsed * 1000) % 1000;

        string currentTime = string.Format("{0:00}{1:00}{2:000}", minutes, seconds, milliseconds);
        resFinishTime.text = currentTime.Substring(0, 2) + " : " + currentTime.Substring(2, 2) + " : " + currentTime.Substring(4, 3);

        // TODO: Kalau new best, diaktifkan best badgenya
        if (bestTime == 0f || (timeElapsed < bestTime)) {
            // Save New Best Time
            PlayerPrefs.SetFloat("time" + gameManagerScript.Level, timeElapsed);
            PlayerPrefs.Save();

            // Show UI
            resNewBestBadge.SetActive(true);
        }
    }

    private void DebugDeleteAllPlayerPrefs() {
        Debug.LogWarning("Player Prefs Deleted");
        PlayerPrefs.DeleteAll();
    }
}
