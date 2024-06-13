using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private GameObject playGame;
    [SerializeField] private GameObject maze;
    //[SerializeField] private GameObject buttonCanvas;
    //[SerializeField] private GameObject arrowCanvas;
    //[SerializeField] private GameObject spikeCanvas;
    //[SerializeField] private GameObject threeDCanvas;

    public void ScanMazePortal()
    {
        SceneManager.LoadScene(1);
    }
    public void ScanMazeButton()
    {
        SceneManager.LoadScene(2);
    }
    //public void ScanMazeArrow()
    //{
    //    SceneManager.LoadScene(3);
    //}
    public void ScanMazeSpike()
    {
        SceneManager.LoadScene(4);
    }
    public void ScanMaze3D()
    {
        SceneManager.LoadScene(5);
    }
     
    public void PlayGame()
    {
        playGame.SetActive(false);
        maze.SetActive(true);

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
