using System;
using System.Threading;

namespace GpioExample
{
    public class LedDemo : IDisposable
    {
        private IGpioController redLed;
        private IGpioController yellowLed;
        private IGpioController greenLed;

        public LedDemo()
        {
            Init();
        }

        private void Init()
        {
            #if DEBUG
                this.redLed = new GpioConsoleController((int)EnumLed.Red);
                this.yellowLed = new GpioConsoleController((int)EnumLed.Yellow);
                this.greenLed = new GpioConsoleController((int)EnumLed.Green);
            #else
                this.redLed = new GpioController((int)EnumLed.Red);
                this.yellowLed = new GpioController((int)EnumLed.Yellow);
                this.greenLed = new GpioController((int)EnumLed.Green);
            #endif
        }

        public void WritePin(EnumLed led, PinValue pinValue)
        {
            switch(led)
            {
                case EnumLed.Red:
                    this.redLed.WritePin(pinValue);
                    break;
                case EnumLed.Yellow:
                    this.yellowLed.WritePin(pinValue);
                    break;
                case EnumLed.Green:
                    this.greenLed.WritePin(pinValue);
                    break;
            }
        }

        public void RunTrafficLight()
        {
            //Turn all LEDS off
            this.redLed.WritePin(PinValue.Low);
            this.yellowLed.WritePin(PinValue.Low);
            this.greenLed.WritePin(PinValue.Low);

            Console.WriteLine("...Press any key to stop.");
            Console.WriteLine();

            while (!Console.KeyAvailable)
            {
                this.redLed.WritePin(PinValue.Low);
                this.greenLed.WritePin(PinValue.High);
                Thread.Sleep(5000);

                this.greenLed.WritePin(PinValue.Low);
                this.yellowLed.WritePin(PinValue.High);
                Thread.Sleep(1000);

                this.yellowLed.WritePin(PinValue.Low);
                this.redLed.WritePin(PinValue.High);
                Thread.Sleep(5000);
            }

            // Turn all LEDS off after exit
            this.redLed.WritePin(PinValue.Low);
            this.yellowLed.WritePin(PinValue.Low);
            this.greenLed.WritePin(PinValue.Low);
        }

        public void Dispose()
        {
            this.redLed.Dispose();
            this.yellowLed.Dispose();
            this.greenLed.Dispose();
        }
    }

    public enum EnumLed
    {
        Red = 13,
        Yellow = 27,
        Green = 22
    }
}
