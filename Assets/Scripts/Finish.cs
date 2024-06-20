using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] int level;
    public GameObject gameFinishCanvas;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            gameFinishCanvas.SetActive(true);
        }    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
