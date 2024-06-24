using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PC_Gyro : MonoBehaviour
{
    // Warning text
    // [SerializeField] GameObject gyroWarning;
    // [SerializeField] TMP_Text warningText;
    // [SerializeField] TMP_Text velocityText;

    // Gyro
    Gyroscope m_Gyro; // Gyroscope variable is no longer needed
    Rigidbody rb;

    float gyroMultiplier = 5f;
    public Quaternion initialOrientation;

    // Gravity
    Transform gravityNormalGameObject; // Gravity normal game object defaultnya harus hadap ke atas (sumbu Y positif)
    Vector3 gravityDirection;
    float gravityMultiplier = 9.8f;

    // Keyboard movement speed
    // public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // gravityNormalGameObject = gameObject.GetComponentInParent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();

        SetupGyro();

        // gyroWarning.SetActive(true);
    }

    private void SetupGyro() {
        // Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;

        // Set the gyroscope update interval to the highest frequency
        Input.gyro.updateInterval = 0.005f; // Update every 10ms, adjust as needed
    }

    public void InitializeOrientation() {
        Debug.Log("Orientation set");
        SetupGyro();
        rb = gameObject.GetComponent<Rigidbody>();
        initialOrientation = Input.gyro.attitude;
        initialOrientation = new Quaternion(initialOrientation.x, initialOrientation.y, -initialOrientation.z, -initialOrientation.w);

        rb.velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Keyboard Input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a vector for the direction of movement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the force to the ball's Rigidbody
        rb.AddForce(movement * 2);

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
            

            // Add Force
            Vector3 normalized = rotationEuler.normalized;
            Vector3 forceToAdd = new Vector3(normalized.x * 1, 0, normalized.y * 1);
            rb.AddForce(forceToAdd * gyroMultiplier);
            // warningText.text = (forceToAdd).ToString(); // TODO: Matikan ini
            // rb.AddForce(rotationEuler.normalized * gyroMultiplier, ForceMode.Impulse);
            // velocityText.text = (rb.velocity).ToString(); // TODO: Matikan ini
        }
        else
        {
            Debug.LogError("Device doesn't support gyro");
        }
        
        
        // Custom Gravity
        // gravityDirection = gravityNormalGameObject.transform.up;
        // Vector3 gravity = gravityDirection.normalized * gravityMultiplier;
        // rb.AddForce(gravity);
    }
}
