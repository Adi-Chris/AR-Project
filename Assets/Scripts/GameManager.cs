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
    [SerializeField] private GameObject namaMaze;
    //[SerializeField] private GameObject buttonCanvas;
    //[SerializeField] private GameObject arrowCanvas;
    //[SerializeField] private GameObject spikeCanvas;
    //[SerializeField] private GameObject threeDCanvas;

    public GameObject finishTrigger;
    public GameObject gameFinishCanvas;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameFinishCanvas.SetActive(true);
        }
    }

    public void TestDebug() {
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
        namaMaze.SetActive(false);
        playGameCanvas.SetActive(false);
        pauseButton.SetActive(true);
        maze.SetActive(true);
        if (playerController != null) {
            playerController.InitializeOrientation();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        namaMaze.SetActive(true);
        maze.SetActive(false);
        pauseCanvas.SetActive(true);
        pauseButton.SetActive(false );
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        namaMaze.SetActive(false);
        maze.SetActive(true);
        pauseCanvas.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public void ScannedMazeButton()
    //{
    //    buttonCanvas.SetActive(true);
    //}
    //public void ScannedMazeArrow()
    //{
    //    arrowCanvas.SetActive(true);
    //}
    //public void ScannedMazeSpike()
    //{
    //    spikeCanvas.SetActive(true);
    //}
    //public void ScannedMaze3D()
    //{
    //    threeDCanvas.SetActive(true);
    //}

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
