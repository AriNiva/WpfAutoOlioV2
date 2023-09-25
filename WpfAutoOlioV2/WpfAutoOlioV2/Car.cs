using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfAutoOlioV2
{
    public class Car
    {
        public string Color { get; set; }
        public int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                if (value > 0 && value <= 400)
                {
                    maxSpeed = value;
                }
                else
                {
                    maxSpeed = 0;
                    throw new ArgumentOutOfRangeException();
                }
            }

        }
        private int maxSpeed;
        private int gearCount;
        public Boolean Running { get; set; }
        public string Model { get; set; }
        public int CurrentSpeed { get; set; }
        public int Horsepower { get; set; }
        public string TransMission { get; set; }
        public int GearCount
        {
            get
            {
                return gearCount;
            }
            set
            {
                if (Regex.IsMatch(value.ToString(), "^[4-9]{1,1}$"))
                {
                    gearCount = value;
                }
                else
                {
                    gearCount = 0;
                    throw new ArgumentOutOfRangeException();
                }
            }
        }


        public void StartEngine()
        {
            Running = true;
        }

        public void StopEngine()
        {
            Running = false;
        }

        public void Accelerate()
        {
            CurrentSpeed++;
        }

        public void Brake() 
        { 
            CurrentSpeed--;
        }
    }
}
