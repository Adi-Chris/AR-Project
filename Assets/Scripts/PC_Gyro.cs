using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PC_Gyro : MonoBehaviour
{
    // Warning text
    [SerializeField] GameObject gyroWarning;
    [SerializeField] TMP_Text warningText;

    // Gyro
    Gyroscope m_Gyro;
    Rigidbody rb;

    float gyroMultiplier = 2f;
    public Quaternion initialOrientation;

    // Gravity
    Transform gravityNormalGameObject; // Gravity normal game object defaultnya harus hadap ke atas (sumbu Y positif)
    Vector3 gravityDirection;
    float gravityMultiplier = 9.8f;
    

    // Start is called before the first frame update
    void Start()
    {
        gravityNormalGameObject = gameObject.GetComponentInParent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();

        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;

        gyroWarning.SetActive(true); // TODO: Matikan ini
    }

    public void InitializeOrientation() {
        Debug.Log("Orientation set");
        initialOrientation = Input.gyro.attitude;
        initialOrientation = new Quaternion(initialOrientation.x, initialOrientation.y, -initialOrientation.z, -initialOrientation.w);

        rb.velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Gyro Input
        if (m_Gyro != null)
        {
            // Debug.Log(Input.gyro.rotationRate.ToString());
            // Get the current orientation of the device
            Quaternion currentOrientation = Input.gyro.attitude;
            currentOrientation = new Quaternion(currentOrientation.x, currentOrientation.y, -currentOrientation.z, -currentOrientation.w);

            // Compute the rotation difference
            Quaternion rotationDifference = currentOrientation * Quaternion.Inverse(initialOrientation);

            // Convert the rotation difference to Euler angles
            Vector3 rotationEuler = rotationDifference.eulerAngles;

            // Cari kiri kanan
            // Intinya, kalau >= 180, maka harusnya bergerak ke arah sebaliknya, alias sumbu negatif
            rotationEuler = new Vector3(
                rotationEuler.x >= 180 ? rotationEuler.x - 360 : rotationEuler.x,
                rotationEuler.y >= 180 ? rotationEuler.y - 360 : rotationEuler.y,
                rotationEuler.z >= 180 ? rotationEuler.z - 360 : rotationEuler.z
            );
            // TODO: Mungkin di sumbu Y bisa ditambah 25 derajat untuk kedua ifnya
            warningText.text = (rotationEuler).ToString(); // TODO: Matikan ini

            // Add Force
            rb.AddForce(rotationEuler.normalized * gyroMultiplier);
            // warningText.text = (rb.velocity).ToString(); // TODO: Matikan ini
        }
        else
        {
            gyroWarning.SetActive(true);
            Debug.LogError("Device doesn't support gyro");
        }
        
        // // Custom Gravity
        // gravityDirection = gravityNormalGameObject.transform.up;
        // Vector3 gravity = gravityDirection.normalized * gravityMultiplier;
        // rb.AddForce(gravity);
    }
}
