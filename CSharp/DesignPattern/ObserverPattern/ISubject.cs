using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.DesignPattern.ObserverPattern
{
    interface ISubject
    {
        void Subscribe(Observer observer);
        void Unsubscribe(Observer observer);
        void Notify();
    }
}
