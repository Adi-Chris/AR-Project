using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeElapsed;

    [SerializeField] private TMP_Text firstMinutes;
    [SerializeField] private TMP_Text secondMinutes;
    [SerializeField] private TMP_Text separator;
    [SerializeField] private TMP_Text firstSecond;
    [SerializeField] private TMP_Text secondSecond;

    private GameManager gameManagerScript;

    void Start()
    {
        GameObject gameManagerObject = GameObject.Find("GameManager");
        if (gameManagerObject != null)
        {
            gameManagerScript = gameManagerObject.GetComponent<GameManager>();
            if (gameManagerScript == null)
            {
                Debug.LogError("GameManager component not found on GameManager object.");
            }
        }
        else
        {
            Debug.LogError("GameManager object not found.");
        }

        UpdateTimerDisplay(timeElapsed);
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        UpdateTimerDisplay(timeElapsed);
    }

    private void ResetTimer()
    {
        timeElapsed = 0f;
        UpdateTimerDisplay(timeElapsed);
        Debug.Log(timeElapsed);
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{0:00}{1:00}", minutes, seconds);
        firstMinutes.text = currentTime[0].ToString();
        secondMinutes.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }
}
