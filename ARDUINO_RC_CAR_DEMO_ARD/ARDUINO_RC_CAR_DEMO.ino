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
const int trig = 7;
const int echo = 8;
const int dht11 = 2;
const int photoResistor = A0;
const int gasSensor = A1;

dht DHT;
SoftwareSerial Blue(4, 3); // RX | TX

void setup() {

  Serial.begin(9600);
  Blue.begin(9600); //Default Baud for comm, it may be different for your Module. 
  Serial.println("The bluetooth gates are open.\n Connect to HC-05 from any other bluetooth device with 1234 as pairing key!.");
  pinMode(leftFwrd, OUTPUT);
  pinMode(rightFwrd, OUTPUT);
  pinMode(leftBckwrd, OUTPUT);
  pinMode(rightBckwrd, OUTPUT);
  pinMode(zum, OUTPUT);
  pinMode(btn, INPUT);
  pinMode(led, OUTPUT);
  pinMode(trig, OUTPUT);
  pinMode(echo, INPUT);
  pinMode(dht11, INPUT);
  pinMode(photoResistor, INPUT);
  pinMode(gasSensor, INPUT);

}

void loop() {
  //Sound(3);
  // Feed any data from bluetooth to Terminal.
  
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
void Sound(int n)
{
  for(int i = 0; i < n; i++)
  {
    digitalWrite(zum,1);
    delay(30);
    digitalWrite(zum,0);
  }
}
void SendSensorData() {
  String data = "";
  char buff[30];

  int chk = DHT.read11(dht11);
  float temp = DHT.temperature;
  float humidity = DHT.humidity;
  
  int smokeData = digitalRead(gasSensor);
  
  data += humidity;
  data += "%\n";
  data += temp;
  data += "C\n";
  data += UltrasonicSensorDistance();
  data += "d\n";
  if(smokeData == 1)
  {
    data += "no";
  }
  else
  {
    data += "yes";
    
  }
  if (temp != -999.00) {
    Serial.println(data);
    Blue.println(data);
  }
}
int UltrasonicSensorDistance() {
  long duration;
  int distance;
  // Clears the trigPin
  digitalWrite(trig, 0);
  delayMicroseconds(2);
  // Sets the trigPin on HIGH state for 10 micro seconds
  digitalWrite(trig, 1);
  delayMicroseconds(10);
  digitalWrite(trig, 0);
  // Reads the echoPin, returns the sound wave travel time in microseconds
  duration = pulseIn(echo, 1);
  // Calculating the distance
  distance = duration * 0.034 / 2;
  // Prints the distance on the Serial Monitor

  if (distance <= 40 && distance >= 0) {
    return distance;
  }
  else{
    return 0;
    }
}
