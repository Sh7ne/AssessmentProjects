using System;
namespace RBCAssessmentAPI
{
	public class HelloWorld: IHelloWorld
    {
        public string Greetings(string firstName, string lastName)
        {
            return "Hello," + firstName + " " + lastName;
        }
    }
}
