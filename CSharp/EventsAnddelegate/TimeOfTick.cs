//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CSharp.EventsAnddelegate
//{
//    public class TimeOfTick : EventArgs
//    {
//        private DateTime TimeNow;
//        public DateTime Time
//        {
//            set
//            {
//                TimeNow = value;
//            }
//            get
//            {
//                return this.TimeNow;
//            }
//        }
//    }
//    public class Metronome
//    {
//        public event TickHandler Tick;
//        public delegate void TickHandler(Metronome m, TimeOfTick e);
//        public void Start()
//        {
//            while (true)
//            {
//                System.Threading.Thread.Sleep(3000);
//                if (Tick != null)
//                {
//                    TimeOfTick TOT = new TimeOfTick();
//                    TOT.Time = DateTime.Now;
//                    Tick(this, TOT);
//                }
//            }
//        }
//    }
//    public class Listener
//    {
//        public void Subscribe(Metronome m)
//        {
//            m.Tick += new Metronome.TickHandler(HeardIt);
//        }
//        private void HeardIt(Metronome m, TimeOfTick e)
//        {
//            System.Console.WriteLine("HEARD IT AT {0}", e.Time);
//        }

//    }
//    class Test
//    {
//        static void Main()
//        {
//            Metronome m = new Metronome();
//            Listener l = new Listener();
//            l.Subscribe(m);
//            m.Start();
//        }
//    }

//}
