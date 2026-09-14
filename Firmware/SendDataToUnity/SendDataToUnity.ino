

#include <elapsedMillis.h>

elapsedMillis sendToUnityTimer;
const unsigned long sendToUnityInterval = 25; // adjust this value (higher) if serial communication is getting bogged down

const int switchPin = 2;
const int potentiometerPin = A0;

bool switchState = 0;
int potentiometerValue = 0;

void setup() {
  Serial.begin(115200);
  pinMode(switchPin, INPUT_PULLUP);
  pinMode(potentiometerPin, INPUT);
}

void loop() {
  readSensors();
  sendSensorDataToUnity();
}

void readSensors() {
  switchState = digitalRead(switchPin);
  potentiometerValue = analogRead(potentiometerPin);
}


void sendSensorDataToUnity() {
  if (sendToUnityTimer >= sendToUnityInterval) {
    sendToUnityTimer = 0; // reset the timer

    Serial.print(buttonState);
    Serial.print(',');
    Serial.println(potentiometerValue);
  }
}
