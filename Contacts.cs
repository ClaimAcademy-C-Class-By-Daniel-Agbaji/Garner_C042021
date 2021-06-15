using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhoneBook
{
    public class Contacts
    {
        public string FirstName;
        public string LastName;
        public string[] Address;
        public string PhoneNumber;
        public string filePath = @"C:\Users\trgar\OneDrive\Desktop\Contacts.txt";


        public static List<Contacts> People = new List<Contacts>();



        public void DisplayContacts(Contacts contacts)
        {
            Console.WriteLine($"First Name: {contacts.FirstName}");
            Console.WriteLine($"Last Name: {contacts.LastName}");
            Console.WriteLine($"Address 1: {contacts.Address[0]}");
            Console.WriteLine($"Address 2: {contacts.Address[1]}");
            Console.WriteLine($"Phone Number: {contacts.PhoneNumber}");
            Console.WriteLine($"<-------------------------------->");
        }

        // make sure the following below works using any method
        // add users to .txt file(simple, try to do), then delete with regex (harder, practice but not required)

        public void addUser()
        {
            #region addUser
            bool isCorrect = true;
            while (isCorrect) // change to a foreach loop if possible
            {

                Contacts contacts = new Contacts();
                Console.Write("Enter first name: ");
                contacts.FirstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                contacts.LastName = Console.ReadLine();

                Console.Write("Enter address 1 : ");
                string[] addresses = new string[2];
                addresses[0] = Console.ReadLine();
                Console.Write("Enter address 2 : (Optional) ");
                addresses[1] = Console.ReadLine();
                contacts.Address = addresses;

                Console.Write("Enter phone number: ");
                contacts.PhoneNumber = Console.ReadLine();


                Console.WriteLine($"You added {contacts.FirstName} {contacts.LastName}, address 1: {contacts.Address[0]}, address 2: {contacts.Address[1]}, phone number: {contacts.PhoneNumber} " + " Is that correct? Y/N: ");
                var correct = Console.ReadLine();
                if (correct.ToLower() == "y")
                {
                    People.Add(contacts);
                    using (StreamWriter txt = new StreamWriter(filePath))
                    {
                        foreach (var person in People)
                        {
                            txt.WriteLine(contacts.FirstName);
                            txt.WriteLine(contacts.LastName);
                            txt.WriteLine(contacts.Address[0]);
                            txt.WriteLine(contacts.Address[1]);
                            txt.WriteLine(contacts.PhoneNumber);
                        }
                    }
                    Console.WriteLine("Alright, we got them added for you!! ");
                    isCorrect = false;
                    break;

                }
                else
                {
                    Console.WriteLine("Sorry bout that, lets try again! ");
                    isCorrect = true;
                    continue;
                }

            }
            #endregion  
        }

        public void editUser()
        {
            Console.WriteLine("Please enter the first name of the user you wish to edit: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Please enter the last name of the user you wish to edit: ");
            var lastName = Console.ReadLine();
            Contacts contacts = Contacts.People.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());
            contacts = Contacts.People.FirstOrDefault(y => y.LastName.ToLower() == lastName.ToLower());

            //private void isNullOrBlank(this String text)
            //{
            //    return text == null || text.Trim().Length == 0;
            //}

            if (contacts == null)
            {
                Console.WriteLine("This contact is not found. Press any key to continue ");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Are you sure you want to edit this person: Y/N");
                DisplayContacts(contacts);
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine("Okay");
                    Console.WriteLine("What would you like to edit: 1. First name, 2. Last name, 3. Address 1, 4. Address 2, 5. Phone Number? Please enter the corresponding phone number: ");
                    int userChooses = Convert.ToInt32(Console.ReadLine());
                    switch (userChooses)
                    {
                        case 1:
                            changeFirstName(contacts);
                            break;
                        case 2:
                            changeLastName(contacts);
                            break;
                        case 3:
                            changeAddress1(contacts);
                            break;
                        case 4:
                            changeAddress2(contacts);
                            break;
                        case 5:
                            changePhoneNumber(contacts);
                            break;
                    }
                }
                else
                {
                    return;
                }
            }

        }
        public void deleteUser()
        {
            Console.WriteLine("Delete User");
            Console.WriteLine("Please enter the first name of the user you wish to delete: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Please enter the last name of the user you wish to delete: ");
            var lastName = Console.ReadLine();
            Contacts contacts = Contacts.People.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());
            contacts = Contacts.People.FirstOrDefault(y => y.LastName.ToLower() == lastName.ToLower());

            if (contacts == null)
            {
                Console.WriteLine("This contact is not found. Press any key to continue ");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Are you sure you want to delete this person: Y/N");
                DisplayContacts(contacts);
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine("Okay, this person has been deleted");
                    Console.ReadLine();
                }
                else
                {
                    return;
                }
            }
        }
        public void viewAllContacts()
        {
            if (Contacts.People.Count == 0)
            {
                Console.WriteLine("You have not added anyone yet. Please add a contact and then come back. Press any key to continue: ");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("All contacts: ");
            foreach (var person in People)
            {
                DisplayContacts(person);
            }
            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();
        }
        public void viewText()
        {
            if (Contacts.People.Count == 0)
            {
                Console.WriteLine("You have no added anyone yet. Would you like to add someone? Y/N: ");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    return;
                }
            }
            else
            {
                using (StreamReader txtr = new StreamReader(filePath))
                {
                    foreach (var person in People)
                    {
                        Console.WriteLine("First Name: " + txtr.ReadLine());
                        Console.WriteLine("Last Name: " + txtr.ReadLine());
                        Console.WriteLine("Address: " + txtr.ReadLine());
                        Console.WriteLine("Phone Number: " + txtr.ReadLine());
                    }
                }
            }
        }
        public void changeFirstName(Contacts contacts)
        {
            Console.WriteLine($"What would you like to change {contacts.FirstName} to? Please enter it below: ");
            contacts.FirstName = Console.ReadLine();
            Console.WriteLine($"Okay, first name now change to {contacts.FirstName}");
        }
        public void changeLastName(Contacts contacts)
        {
            Console.WriteLine($"What would you like to change {contacts.LastName} to? Please enter it below: ");
            contacts.LastName = Console.ReadLine();
            Console.WriteLine($"Okay, first name now change to {contacts.LastName}");
        }
        public void changeAddress1(Contacts contacts)
        {
            Console.WriteLine($"What would you like to change {contacts.Address} to? Please enter it below: ");
            contacts.Address = Console.ReadLine();
            Console.WriteLine($"Okay, first name now change to {contacts.Address}");
        }
        public void changeAddress2(Contacts contacts)
        {
            Console.WriteLine($"What would you like to change {contacts.Address} to? Please enter it below: ");
            contacts.Address = Console.ReadLine();
            Console.WriteLine($"Okay, first name now change to {contacts.Address}");
        }
        public void changePhoneNumber(Contacts contacts)
        {
            Console.WriteLine($"What would you like to change {contacts.PhoneNumber} to? Please enter it below: ");
            contacts.PhoneNumber = Console.ReadLine();
            Console.WriteLine($"Okay, first name now change to {contacts.PhoneNumber}");
        }
    }
}