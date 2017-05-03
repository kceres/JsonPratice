using System;

namespace ConsoleApplication.JsonApp.Entities
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }

        public override string ToString(){
            return String.Format("Name: {0} \nAge: {1}",name,age);
        }
    }
}