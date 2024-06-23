using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] int level;
    public GameObject gameFinishCanvas;
    public GameObject maze;
    [SerializeField] SoundManager soundManager;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            soundManager.PlayFinishSFX();
            gameFinishCanvas.SetActive(true);
            maze.SetActive(false);
        }    
    }
}
