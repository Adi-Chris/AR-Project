using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private GameObject playGameCanvas;
    [SerializeField] private GameObject maze;
    [SerializeField] private PC_Gyro playerController;
    //[SerializeField] private GameObject buttonCanvas;
    //[SerializeField] private GameObject arrowCanvas;
    //[SerializeField] private GameObject spikeCanvas;
    //[SerializeField] private GameObject threeDCanvas;

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
    public void ScanMazeArrow()
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
        playGameCanvas.SetActive(false);
        maze.SetActive(true);
        if (playerController != null) {
            playerController.InitializeOrientation();
        }
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