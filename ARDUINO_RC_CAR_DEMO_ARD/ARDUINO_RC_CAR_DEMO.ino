#include <dht.h>
#include <SoftwareSerial.h>
int period = 2000;
unsigned long time_now = 0;
int data;
const int leftFwrd = 5;
const int rightFwrd = 9;
const int leftBckwrd = 6;
const int rightBckwrd = 10;
const int zum = 11;
const int btn = 12;
const int led = 13;
const int trig = 3;
const int echo = 8;
const int dht11 = 2;

dht DHT;
SoftwareSerial Blue(4, 3); // RX | TX

void setup() {

  Serial.begin(9600);
  Blue.begin(9600); //Default Baud for comm, it may be different for your Module. 
  Serial.println("The bluetooth gates are open.\n Connect to HC-05 from any other bluetooth device with 1234 as pairing key!.");
}

void loop() {
  delay(1);
  // Feed any data from bluetooth to Terminal.
  if(millis() > 500)
  StartSound();
  
  if (Blue.available())
    data = Blue.read();
  Serial.write(data);

  // Feed all data from termial to bluetooth
  if (Serial.available())
    Blue.write(Serial.read());
  switch (data) {
  case '0':
    Stop();
    break;
  case '1':
    Forward();
    break;
  case '2':
    Backward();
    break;
  case '3':
    Left();
    break;
  case '4':
    Right();
    break;
  default:
    break;

  }

  if (millis() > time_now + period) {
    time_now = millis();
    SendSensorData();
  }

}

void Forward() {
  digitalWrite(leftFwrd, 1);
  digitalWrite(rightFwrd, 1);
}
void Backward() {
  digitalWrite(leftBckwrd, 1);
  digitalWrite(rightBckwrd, 1);
}
void Left() {
  digitalWrite(leftBckwrd, 1);
  digitalWrite(rightFwrd, 1);
}
void Right() {
  digitalWrite(leftFwrd, 1);
  digitalWrite(rightBckwrd, 1);
}
void Stop() {
  digitalWrite(leftFwrd, 0);
  digitalWrite(rightFwrd, 0);
  digitalWrite(leftBckwrd, 0);
  digitalWrite(rightBckwrd, 0);
}
void SendSensorData() {
  String data = "";
  char buff[30];
  
  int chk = DHT.read11(dht11);
  float temp = DHT.temperature;
  float humidity = DHT.humidity;
  
  data += humidity;
  data += "\n";
  data += temp;
  data += "\n";
  data.toCharArray(buff,30);
  if(temp != -999.00)
  {
  Serial.println(buff);
  Blue.write(buff);
  }
}
void StartSound(){
  digitalWrite(zum,1);
  delay(40);
  digitalWrite(zum,0);
  delay(30);
  digitalWrite(zum,1);
  delay(20);
  digitalWrite(zum,0);
  delay(10);
  digitalWrite(zum,1);
  delay(5);
  digitalWrite(zum,0);
}
