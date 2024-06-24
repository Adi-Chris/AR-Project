using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject gameFinishCanvas;
    public GameObject maze;
    [SerializeField] SoundManager soundManager;
    [SerializeField] Timer timerScript;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            soundManager.PlayFinishSFX();
            gameFinishCanvas.SetActive(true);
            maze.SetActive(false);

            timerScript.IsGameWin = true;
            timerScript.SetResultTimerDisplay();
        }    
    }
}
