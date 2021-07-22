//This application should compile and run.  However, there are multiple areas where this code could be improved.
//It will take in an object, validate the results, and return any failed validation items that a user would need to correct.

//Task 1: Without breaking the functionality; refactor the code.  Think in terms of design patterns and SOLID principles.
//Task 2: Modify/validate the following rules exist (some are already completed):
//Task 3: There is a bug in the "RunValidation". The console will write "Request was valid!" but the overall request has errors. Fix this bug.
//Task 4: Add the following validations using Fluent Validation
    //1.There must be at least one offense in the NibrsRequest
    //2. Offense IDs must be unique
    //3. Offense Type is required
    //4. An arrestee must have both a name and age
    //5. If the Offense Type is Assault, there must be at least one victim 
    //6. If an offense cannot be applied to a minor and the arrestee is under 18, there needs to be validation rules at both the offense and arrestee levels
 
//Hints: We want to see what improvements you can identify and implement and not as concerned about the organization of the project.
//Additionally, in some cases best practices were followed but not consistently.  This could be a hint if you see code written cleaner
//than other code.

using OmnigoSampleApp.Models;
using OmnigoSampleApp.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FluentValidation.Results;

namespace OmnigoSampleApp
{
    public class Program
    {
        private static NibrsRequest Setup_DoNotModify()
        {
            //This would be the request object sent to an API.  This method is just setting some data for the example.
            //This should not be modified.

            var offense = new NibrsRequest();

            var o1 = new Offense();
            o1.OffenseId = 1;
            o1.OffenseDescription = "Robbery";
            o1.Type = OffenseType.Theft;
            o1.WasAttempted = true;

            var v1 = new Victim();
            v1.Name = "Jane Doe";
            v1.Age = 18;

            var s1 = new Suspect();
            s1.Name = "Joe Suspect";
            s1.Age = 21;

            o1.Victims.Add(v1);
            o1.Suspects.Add(s1);

            offense.Offenses.Add(o1);

            //
            var o2 = new Offense();
            o2.OffenseId = 1;
            o2.Type = OffenseType.Assault;
            o2.OffenseDescription = "Assault of a civilian";
            o2.WasAttempted = false;

            offense.Offenses.Add(o2);
            //

            //
            var o3 = new Offense();
            o3.OffenseId = 999;
            o3.OffenseDescription = "Public Intoxication As Adult";
            o3.CanBeAppliedToAMinor = false;

            var a3 = new Arrestee();
            a3.Age = 15;

            o3.Arrestees.Add(a3);
            offense.Offenses.Add(o3);
            //

            var o4 = new Offense();
            o4.OffenseId = 3;
            o4.OffenseDescription = "Aggrivated Assault";
            o4.WasAttempted = false;

            var v4 = new Victim();
            v4.Name = "Joe Suspect";
            v4.Age = 21;

            var s4 = new Suspect();
            s4.Name = "Joe Suspect";
            s4.Age = 21;

            o4.Victims.Add(v4);
            o4.Suspects.Add(s4);

            offense.Offenses.Add(o4);

            return offense;
        }

        static void Main(string[] args)
        {
            var request =
                Setup_DoNotModify(); //assume offenses was posted or passed to this application as a parameter and should not be modified.

            RunValidation(request);

        }

        private static void RunValidation(NibrsRequest request)
        {
            OffenseValidator validator = new OffenseValidator();

            foreach (var offense in request.Offenses)
            {
                var result = validator.Validate(offense);

                string validationErrors = "";
                int i = 0;

                foreach (var error in result.Errors)
                {
                    validationErrors +=
                        $"Property Name: {error.PropertyName}{Environment.NewLine}Attempted Value: {error.AttemptedValue}{Environment.NewLine}Error Message: {error.ErrorMessage}{Environment.NewLine}{Environment.NewLine}";
                    i++;
                }

                if (result.IsValid)
                {
                    Console.WriteLine("Request was valid!");
                }
                else
                {
                    validationErrors = validationErrors +
                        $"There were {i} error(s) found in the payload.{Environment.NewLine}{Environment.NewLine}";

                    Console.WriteLine(validationErrors.ToString());
                }
            }
        }
    }
}
