char myserial;
void setup()
{
  pinMode(11,OUTPUT);
    pinMode(10,OUTPUT);
      pinMode(9,OUTPUT);
        pinMode(8,OUTPUT);
  Serial.begin(9600);
}
void loop()
{
  myserial=Serial.read();
  switch(myserial)
  {
  case '0':
  digitalWrite(11,LOW);
  digitalWrite(10,LOW);
  digitalWrite(9,LOW);
  digitalWrite(8,LOW);
  break;


  case '1':
  digitalWrite(11,HIGH);
  digitalWrite(10,LOW);
  digitalWrite(9,HIGH);
  digitalWrite(8,LOW);
  break;
  
  
  case '2':
  digitalWrite(11,LOW);
  digitalWrite(10,HIGH);
  digitalWrite(9,LOW);
  digitalWrite(8,HIGH);
  break;
  
  case '3':
  digitalWrite(11,HIGH);
  digitalWrite(10,LOW);
  digitalWrite(9,LOW);
  digitalWrite(8,HIGH);
  break;
  
  
 
 case '4':
  digitalWrite(11,LOW);
  digitalWrite(10,HIGH);
  digitalWrite(9,HIGH);
  digitalWrite(8,LOW);
  break;
  }
}

