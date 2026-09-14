using UnityEngine;

public class RotateTargetObject : MonoBehaviour
{
    public SerialSensorData SensorData; // Reference to the ArduinoController script
    public Transform targetObject; // The object to rotate

    public int minPotentiometerValue = 0; // Minimum potentiometer value
    public int maxPotentiometerValue = 1023; // Maximum potentiometer value
    public float minRotationAngle = 0f; // Minimum rotation angle
    public float maxRotationAngle = 360f; // Maximum rotation angle

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SensorData != null && targetObject != null)
        {
            // Map the potentiometer value to a rotation angle
            float normalizedValue = (float)(SensorData.potentiometerValue - minPotentiometerValue) / (float)(maxPotentiometerValue - minPotentiometerValue);
            float rotationAngle = minRotationAngle + normalizedValue * (maxRotationAngle - minRotationAngle);

            // Rotate the target object
            targetObject.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
        
    }

    
}
