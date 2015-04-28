using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcceptanceTest
{
    class Calculator
    {
        readonly IList<int> numbers = new List<int>();
        public void Number(int enteredValue)
        {
            numbers.Add(enteredValue);
        }

        public int Add()
        {
            return numbers.Sum();
        }

    }
}
