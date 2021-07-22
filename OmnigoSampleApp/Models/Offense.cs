using System;
using System.Collections.Generic;
using System.Text;

namespace OmnigoSampleApp.Models
{
    public class Offense
    {
        public Offense()
        {
            this.Victims = new List<Victim>();
            this.Arrestees = new List<Arrestee>();
            this.Suspects = new List<Suspect>();

            OffenseNumber = Guid.NewGuid();
        }

        public Guid OffenseNumber { get; set; }
        public int OffenseId { get; set; }
        public OffenseType Type { get; set; }
        public string OffenseDescription { get; set; }
        public List<Arrestee> Arrestees { get; set; }
        public List<Suspect> Suspects { get; set; }
        public List<Victim> Victims { get; set; }
        public bool WasAttempted { get; set; } //If false it means the offense was completed.  True means it was attempted but not completed.
        public bool CanBeAppliedToAMinor { get; set; } //applies to someone under 18 years old
    }
    public enum OffenseType
    {
        Theft,
        Assault,
        PublicIntoxication
    }
}
