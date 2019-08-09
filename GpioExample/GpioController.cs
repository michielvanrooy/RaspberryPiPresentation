using System.IO;

namespace GpioExample
{
    public class GpioController : IGpioController
    {
        private readonly int pinNumber;
        private readonly string gpioPath = "/sys/class/gpio/";

        public GpioController(int pinNumber)
        {
            this.pinNumber = pinNumber;
            Init();
        }

        public void Init()
        {
            //Check if port is already open
            if (Directory.Exists($"{gpioPath}gpio{pinNumber.ToString()}"))
            {
                return;
            }

            File.WriteAllText($"{gpioPath}export", pinNumber.ToString());
            File.WriteAllText($"{gpioPath}gpio{pinNumber.ToString()}/direction", "out");
        }

        public void WritePin(PinValue value)
        {
            var valueStr = ((byte)value).ToString();
            File.WriteAllText($"{gpioPath}gpio{pinNumber.ToString()}/value", valueStr);
        }

        public void Dispose()
        {
            File.WriteAllText($"{gpioPath}unexport", pinNumber.ToString());
        }
    }
}
