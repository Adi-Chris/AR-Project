using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject gameFinishCanvas;
    public GameObject maze;
    [SerializeField] SoundManager soundManager;
    [SerializeField] Timer timerScript;
    [SerializeField] ParticleSystem winParticle;
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            soundManager.PlayFinishSFX();
            gameFinishCanvas.SetActive(true);
            maze.SetActive(false);

            winParticle.Play();

            gameManager.VibratePhone();

            timerScript.IsGameWin = true;
            timerScript.SetResultTimerDisplay();

            other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            soundManager.SetRollingBallSFXVolume(0);
        }    
    }
}
