﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CSharp
//{
//    class EventSample
//    {
//    }
//    public class Metronome
//    {
//        public event TickHandler Tick;
//        public EventArgs e = null;
//        public delegate void TickHandler(Metronome m, EventArgs e);
//        public void Start()
//        {
//            while (true)
//            {
//                System.Threading.Thread.Sleep(3000);
//                if (Tick != null)
//                {
//                    Tick(this, e);
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
//        private void HeardIt(Metronome m, EventArgs e)
//        {
//            System.Console.WriteLine("HEARD IT");
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
