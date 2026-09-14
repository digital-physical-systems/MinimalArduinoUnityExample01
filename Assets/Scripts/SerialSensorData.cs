using UnityEngine;
using System.IO.Ports;
using System;  


public class SerialSensorData : MonoBehaviour
{
    public string portName = "COM3"; // Replace with your Arduino's port name
    public int baudRate = 115200; // Replace with your Arduino's baud rate
    private SerialPort stream;

    public int potentiometerValue;
    public bool buttonState;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
