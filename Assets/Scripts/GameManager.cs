using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
    [SerializeField] private SoundManager soundManager;

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
        SceneManager.LoadScene(1);
    }

    public void EnterMazeButton()
    {
        SceneManager.LoadScene(2);
    }

    public void EnterMazeArrow()
    {
        SceneManager.LoadScene(3);
    }

    public void EnterMazeSpike()
    {
        SceneManager.LoadScene(4);
    }

    public void EnterMaze3D()
    {
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
        if (playerController != null)
        {
            playerController.InitializeOrientation();
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
    }

    public void Restart()
    {
        soundManager.PlayUIButtonSFX();
        Time.timeScale = 1f;
        playerController.transform.position = startPos.position;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Back()
    {
        soundManager.PlayUIButtonSFX();
        SceneManager.LoadScene(0);
    }
}
