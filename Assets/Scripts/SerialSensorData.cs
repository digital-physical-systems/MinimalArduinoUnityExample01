using UnityEngine;
using System.IO.Ports;
using System;  


public class SerialSensorData : MonoBehaviour
{
    public string portName = "/dev/cu.usbmodem21201"; // Replace with your Arduino's port name
    public int baudRate = 115200; // Replace with your Arduino's baud rate
    private SerialPort stream;

    public int potentiometerValue;
    public bool buttonState;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stream = new SerialPort(portName, baudRate);
        stream.ReadTimeout = 50; // Set a read timeout to avoid blocking the main thread
        try
        {
            stream.Open();
            Debug.Log("Serial port opened successfully.");
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stream != null && stream.IsOpen)
        {
            // Read data from the serial port
            try
            {
                string data = stream.ReadLine();
                string[] values = data.Split(',');

                if (values.Length >= 2)
                {
                    buttonState = values[0] == "1";
                    potentiometerValue = int.Parse(values[1]);
                    
                }
            }
            catch (TimeoutException)
            {
                // Handle timeout exception if no data is received within the specified time
            }
            catch (Exception e)
            {
                Debug.LogError("Error reading from serial port: " + e.Message);
            }
        }
    }
}
