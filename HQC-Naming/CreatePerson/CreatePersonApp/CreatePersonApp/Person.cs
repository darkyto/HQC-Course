namespace CreatePersonApp
{
    using System;

    public class Person
    {
        public Person() 
        {
            
        }

        public Gender Gender { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void createPerson(int id) 
        {
            Person newPerson = new Person();
            newPerson.Age = id;
            if (id % 2 == 0)
            {
                this.Name = "Petur";
                this.Gender = Gender.male;
                this.Age = id;
            }
            else
            {
                this.Name = "Maria";
                this.Gender = Gender.female;
                this.Age = id;
            }
        }
        public override string ToString()
        {
            return "Name: " + this.Name + "\nAge: "+this.Age + "\nGender: "+this.Gender;
        }
    }
}
