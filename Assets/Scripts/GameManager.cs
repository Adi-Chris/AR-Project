using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Ini buat testing gyro
    Gyroscope m_Gyro;
    [SerializeField] private TMP_Text testingGyroText;

    // Start is called before the first frame update
    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Gyro != null) {
            testingGyroText.text = Input.gyro.rotationRate.ToString();
        } else {
            testingGyroText.text = "Not Found?";
        }
        
    }
}
