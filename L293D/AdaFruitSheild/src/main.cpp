#include <Arduino.h>
#include <AccelStepper.h>
#include <AFMotor.h>

AF_Stepper motor1(200, 1);


// you can change these to DOUBLE or INTERLEAVE or MICROSTEP!
void forwardstep() {  
  motor1.onestep(FORWARD, SINGLE);
}
void backwardstep() {  
  motor1.onestep(BACKWARD, SINGLE);
}

AccelStepper stepper(forwardstep, backwardstep); // use functions to step

void setup()
{  
   Serial.begin(115200);           // set up Serial library at 9600 bps
   Serial.println("Stepper test!");
  
   stepper.setSpeed(50);	
}

void loop()
{  
   stepper.runSpeed();
}