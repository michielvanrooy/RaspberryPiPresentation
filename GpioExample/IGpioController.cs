namespace GpioExample
{
    public interface IGpioController
    {
        void WritePin(PinValue value);

        void Dispose();
    }
}
