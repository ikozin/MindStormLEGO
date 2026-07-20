#include <Arduino.h>
#include <SparkFun_TB6612.h>
/*
┌─────────────────────────────────────────┐
│      ┌───┐                   ┌───┐      │
│   VM ┤   │                   │   ├ PWMA │
│      ├───┤                   ├───┤      │
│  VCC ┤   │                   │   ├ AIN2 │
│      ├───┤                   ├───┤      │
│  GND ┤   │                   │   ├ AIN1 │
│      ├───┤                   ├───┤      │
│  AO1 ┤   │                   │   ├ STBY │
│      ├───┤                   ├───┤      │
│  AO2 ┤   │                   │   ├ BIN1 │
│      ├───┤                   ├───┤      │
│  BO2 ┤   │                   │   ├ BIN2 │
│      ├───┤                   ├───┤      │
│  BO1 ┤   │                   │   ├ PWMB │
│      ├───┤                   ├───┤      │
│  GND ┤   │                   │   ├ GND  │
│      └───┘                   └───┘      │
└─────────────────────────────────────────┘
*/

#define AIN1 2
#define AIN2 4
#define PWMA 3

#define BIN1 7
#define BIN2 8
#define PWMB 6

#define STBY 9

#define A_READ_1  A0
#define B_READ_1  A1

const int offsetA = 1;
const int offsetB = 1;

Motor motor1 = Motor(AIN1, AIN2, PWMA, offsetA, STBY);
Motor motor2 = Motor(BIN1, BIN2, PWMB, offsetB, STBY);

void setup() {
    Serial.begin(115200);
    Serial.println("Start");
}

const unsigned long interval = 1000;
unsigned long previousMillis;
unsigned long currentMillis;

void loop() {
    motor1.drive(255);
    motor2.drive(255);
    previousMillis = millis();
    do {
        uint32_t a = analogRead(A_READ_1);  
        uint32_t b = analogRead(B_READ_1);  
        Serial.print(a);
        Serial.print(',');
        Serial.print(b);
        Serial.println();
        currentMillis = millis();
    } while (currentMillis - previousMillis >= interval);
    motor1.brake();
    motor2.brake();

    motor1.drive(-255);
    motor2.drive(-255);
    previousMillis = millis();
    do {
        Serial.println("");
        currentMillis = millis();
    } while (currentMillis - previousMillis >= interval);
    motor1.brake();
    motor2.brake();

}
