using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    /// <summary>
    /// The facade pattern is a design pattern that is used to simplify access to functionality in complex or poorly designed subsystems.
    /// The facade class provides a simple, single-class interface that hides the implementation details of the underlying code.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MyJoggingFacade facade = new MyJoggingFacade();

            facade.StartJogging();
            Console.WriteLine();
            facade.StopJogging();
        }

        class GPSController
        {
            bool isSwitchedOn = false;

            public bool IsSwitchedOn
            {
                get
                {
                    return isSwitchedOn;
                }
                set
                {
                    isSwitchedOn = value;
                    DisplayStatus();
                }
            }

            private void DisplayStatus()
            {
                string status = (isSwitchedOn == true) ? "ON" : "OFF";
                Console.WriteLine("GPS Switched {0}", status);
            }
        }

        class MobileDataController
        {
            bool isSwitchedOn = false;

            public bool IsSwitchedOn
            {
                get
                {
                    return isSwitchedOn;
                }
                set
                {
                    isSwitchedOn = value;
                    DisplayStatus();
                }
            }

            private void DisplayStatus()
            {
                string status = (isSwitchedOn == true) ? "ON" : "OFF";
                Console.WriteLine("Mobile Data Switched {0}", status);
            }
        }

        class MusicController
        {
            bool isSwitchedOn = false;

            public bool IsSwitchedOn
            {
                get
                {
                    return isSwitchedOn;
                }
                set
                {
                    isSwitchedOn = value;
                    DisplayStatus();
                }
            }

            private void DisplayStatus()
            {
                string status = (isSwitchedOn == true) ? "ON" : "OFF";
                Console.WriteLine("Music Switched {0}", status);
            }
        }

        class WifiController
        {
            bool isSwitchedOn = false;

            public bool IsSwitchedOn
            {
                get
                {
                    return isSwitchedOn;
                }
                set
                {
                    isSwitchedOn = value;
                    DisplayStatus();
                }
            }

            private void DisplayStatus()
            {
                string status = (isSwitchedOn == true) ? "ON" : "OFF";
                Console.WriteLine("WIFI Switched {0}", status);
            }
        }

        class SportsTrackerApp
        {
            public void Start()
            {
                Console.WriteLine("Sports Tracker App STARTED");
            }

            public void Stop()
            {
                Console.WriteLine("Sports Tracker App STOPPED");
            }

            public void Share()
            {
                Console.WriteLine("Sports Tracker: Stats shared on twitter and facebook.");
            }
        }

        class MyJoggingFacade
        {
            // These handles will be passed to this facade in a real application
            // also on actual device these controllers will be singleton too.
            GPSController gps = new GPSController();
            MobileDataController data = new MobileDataController();
            MusicController zune = new MusicController();
            WifiController wifi = new WifiController();

            SportsTrackerApp app = null;

            public void StartJogging()
            {
                // 1. Turn off the wifi
                wifi.IsSwitchedOn = false;

                // 2. Switch on the Mobile Data
                data.IsSwitchedOn = true;

                // 3. Turn on the GPS
                gps.IsSwitchedOn = true;

                // 4. Turn on the Music
                zune.IsSwitchedOn = true;

                // 5. Start the Sports-Tracker
                app = new SportsTrackerApp();
                app.Start();
            }

            public void StopJogging()
            {
                // 0. Share Sports tracker stats on twitter and facebook
                app.Share();

                // 1. Stop the Sports Tracker
                app.Stop();

                // 2. Turn off the Music
                zune.IsSwitchedOn = false;

                // 3. Turn off the GPS
                gps.IsSwitchedOn = false;

                // 4. Turn off the Mobile Data
                data.IsSwitchedOn = false;

                // 5. Turn on the wifi
                wifi.IsSwitchedOn = true;
            }
        }
    }
}
