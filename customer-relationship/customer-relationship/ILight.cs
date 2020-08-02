
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace customer_relationship
{
    public interface ILight
    {
        void SwitchOn();
        void SwitchOff();
        bool IsOn();
        public PowerStatus Power => PowerStatus.NoPower;
    }

    interface ITimerLight : ILight
    {
        public async Task TurnOnFor(int duration)
        {
            Console.WriteLine("Using the default interface method for the ITimerLight.TurnOnFor.");
            SwitchOn();
            await Task.Delay(duration);
            SwitchOff();
            Console.WriteLine("Completed ITimerLight.TurnOnFor sequence.");
        }

    }

    public interface IBlinkingLight : ILight
    {
        public async Task Blink(int duration, int repeatCount)
        {
            Console.WriteLine("Using the default interface method for IBlinkingLight.Blink.");
            for (int count = 0; count < repeatCount; count++)
            {
                SwitchOn();
                await Task.Delay(duration);
                SwitchOff();
                await Task.Delay(duration);
            }
            Console.WriteLine("Done with the default interface method for IBlinkingLight.Blink.");
        }
    }
}
