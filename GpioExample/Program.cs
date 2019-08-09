using System;

namespace GpioExample
{
    public class Program
    {
        private static bool isRedLedOn = false;
        private static bool isYellowLedOn = false;
        private static bool isGreenLedOn = false;

        private static LedDemo ledDemo;

        public static void Main(string[] args)
        {
            ledDemo = new LedDemo();

            while (true)
            {
                BuildMenu();

                var userInput = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.WriteLine();

                if (userInput == 'x')
                {
                    break;
                }

                switch (userInput)
                {
                    case '1':
                        TurnRedLedOnOrOff();
                        break;
                    case '2':
                        TurnYellowLedOnOrOff();
                        break;
                    case '3':
                        TurnGreenLedOnOrOff();
                        break;
                    case '4':
                        ledDemo.RunTrafficLight();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }

            //Dispose Led demo and release all pins
            ledDemo.Dispose();
        }

        public static void BuildMenu()
        {
            var redLedAction = isRedLedOn ? "off" : "on";
            var yellowLedAction = isYellowLedOn ? "off" : "on";
            var greenLedAction = isGreenLedOn ? "off" : "on";

            Console.WriteLine($"1. Turn {redLedAction} Red Led");
            Console.WriteLine($"2. Turn {yellowLedAction} Yellow Led");
            Console.WriteLine($"3. Turn {greenLedAction} Green Led");
            Console.WriteLine($"4. Start Traffic Light");
            Console.WriteLine($"x. Exit");
        }

        public static void TurnRedLedOnOrOff()
        {
            ledDemo.WritePin(EnumLed.Red, (isRedLedOn) ? PinValue.Low : PinValue.High);
            isRedLedOn = !isRedLedOn;
        }

        public static void TurnYellowLedOnOrOff()
        {
            ledDemo.WritePin(EnumLed.Yellow, (isYellowLedOn) ? PinValue.Low : PinValue.High);
            isYellowLedOn = !isYellowLedOn;
        }

        public static void TurnGreenLedOnOrOff()
        {
            ledDemo.WritePin(EnumLed.Green, (isGreenLedOn) ? PinValue.Low : PinValue.High);
            isGreenLedOn = !isGreenLedOn;
        }
    }
}
