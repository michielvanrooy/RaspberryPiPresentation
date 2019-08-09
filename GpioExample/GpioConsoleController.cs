using System;

namespace GpioExample
{
    public class GpioConsoleController : IGpioController
    {
        private readonly int pinNumber;

        public GpioConsoleController(int pinNumber)
        {
            this.pinNumber = pinNumber;
        }

        public void Dispose()
        {
            Console.WriteLine($"--> Pin number {pinNumber} Disposed");
        }

        public void WritePin(PinValue value)
        {
            if (value == PinValue.High)
            {
                Console.WriteLine($"--> Pin number {pinNumber} is turned ON");
            }
            else
            {
                Console.WriteLine($"--> Pin number {pinNumber} is turned OFF");
            }
        }
    }
}
