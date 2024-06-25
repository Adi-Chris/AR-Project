using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] private GameObject playGameCanvas;
    [SerializeField] private GameObject maze;
    [SerializeField] private PC_Gyro playerController;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject namaMaze;
    [SerializeField] private Transform startPos;

    public GameObject finishTrigger;
    public GameObject gameFinishCanvas;
    public GameObject timerCanvas;
    [SerializeField] private Timer timerScript;
    [SerializeField] private SoundManager soundManager;

    public int Level { get => level; set => level = value; }

    // Level specific
    [SerializeField] List<ButtonToggle> mazeButtonToggles;
    [SerializeField] ButtonToggle3dMaze maze3dToggle;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameFinishCanvas.SetActive(true);
        }
    }

    public void TestDebug()
    {
        SceneManager.LoadScene(1);
    }

    public void EnterMazePortal()
    {
        VibratePhone();
        SceneManager.LoadScene(1);
    }

    public void EnterMazeButton()
    {
        VibratePhone();
        SceneManager.LoadScene(2);
    }

    public void EnterMazeArrow()
    {
        VibratePhone();
        SceneManager.LoadScene(3);
    }

    public void EnterMazeSpike()
    {
        VibratePhone();
        SceneManager.LoadScene(4);
    }

    public void EnterMaze3D()
    {
        VibratePhone();
        SceneManager.LoadScene(5);
    }

    public void PlayGame()
    {
        soundManager.PlayUIButtonSFX();
        namaMaze.SetActive(false);
        playGameCanvas.SetActive(false);
        pauseButton.SetActive(true);
        restartButton.SetActive(true);
        maze.SetActive(true);
        timerCanvas.SetActive(true);
        if (playerController != null)
        {
            playerController.InitializeOrientation();
            timerScript.StartTimer();
        }
    }

    public void Pause()
    {
        soundManager.PlayUIButtonSFX();
        Time.timeScale = 0f;
        namaMaze.SetActive(true);
        maze.SetActive(false);
        pauseCanvas.SetActive(true);
        pauseButton.SetActive(false);
        restartButton.SetActive(false);
    }

    public void Resume()
    {
        soundManager.PlayUIButtonSFX();
        Time.timeScale = 1f;
        namaMaze.SetActive(false);
        maze.SetActive(true);
        pauseCanvas.SetActive(false);
        pauseButton.SetActive(true);
        restartButton.SetActive(true);

        playerController.InitializeOrientation();
    }

    public void Restart()
    {
        soundManager.PlayUIButtonSFX();
        Time.timeScale = 1f;
        playerController.transform.position = startPos.position;
        timerScript.ResetTimer();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Reset in MazeButton
        if (mazeButtonToggles != null) {
            foreach (ButtonToggle buttonToggle in mazeButtonToggles)
            {
                buttonToggle.ToggleEnable();
            }
        }

        // Reset in Maze3D
        if (maze3dToggle != null) {
            maze3dToggle.ToggleDisable();
        }
    }

    public void Back()
    {
        Time.timeScale = 1f;
        soundManager.PlayUIButtonSFX();
        SceneManager.LoadScene(0);
    }

    public void VibratePhone() {
        Handheld.Vibrate();
    }
}
