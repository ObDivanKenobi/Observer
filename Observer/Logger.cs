using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Logger : IObserver
    {
        public List<string> Log { get; } = new List<string>();

        public void Update()
        {
            Log.Add("Unidentified evend observed!");
        }

        public void Update(string message)
        {
            Log.Add(message);
        }
    }
}
