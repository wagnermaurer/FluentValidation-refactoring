using System;
using System.Collections.Generic;
using System.Text;

namespace OmnigoSampleApp.Models
{
    //This class should not be modified as part of your solution.  This is the input to your application.
    public class NibrsRequest
    {
        public NibrsRequest()
        {
            this.Offenses = new List<Offense>();
        }

        public List<Offense> Offenses { get; set; }
    }
}
