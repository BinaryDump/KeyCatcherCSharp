using System;
using System.Threading;
using System.Windows.Input;
using System.Media;

namespace KeyCatcher
{
    class Program
    {
        static SoundPlayer player = new SoundPlayer();

        static void Main(string[] args)
        {
            Thread thread = new Thread(Keyboardd);
            thread.SetApartmentState(ApartmentState.STA);
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\MarcheImperiale.wav";

            thread.Start();

        }

        static bool isRunning = true;
        static void Keyboardd()
        {
            while (isRunning)
            {
                Thread.Sleep(40);
                if ((Keyboard.GetKeyStates(key: Key.Escape) & KeyStates.Down) > 0)  //Key.LeftAlt represent the left alt of your Keyboard
                {
                    Console.WriteLine("Pressed");// + Keyboard.GetKeyStates(Key.LeftAlt));
                    player.Play();

                }
                else
                {
                    Console.WriteLine("Not pressed");//+ Keyboard.GetKeyStates(Key.LeftAlt));
                }
            }
        }

    }
}
