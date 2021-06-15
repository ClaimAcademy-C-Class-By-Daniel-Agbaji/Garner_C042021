using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhoneBook
{
    public class Program : PhoneBook
    {

        public static void Main(string[] args)
        {
            RunPhoneBookLab();
        }



        private static void RunPhoneBookLab()
        {
            Contacts pb1 = new Contacts();
            bool cont1 = true;
            while (cont1)
            {


                bool phonebookIsRunning = true;
                while (phonebookIsRunning)
                {
                    Console.Write("Hello, Welcome to the PhoneBook!" + "\n" + "Please choose one of the following options" + "\n" + "1. Add someone to PhoneBook " + "\n" +
                    "2. Remove Someone From PhoneBook " + "\n" + "3. View All PhoneBook Entries (Contacts) " + "\n" + "4. Edit Existing Contact" +
                    "\n" + "5. Exit " + "\n" + "\n");
                    var userEntry = Convert.ToInt32(Console.ReadLine());


                    switch (userEntry)
                    {
                        case 1:
                            pb1.addUser();
                            phonebookIsRunning = false;
                            break;
                        case 2:
                            pb1.deleteUser();
                            phonebookIsRunning = false;
                            break;
                        case 3:
                            pb1.viewAllContacts();
                            phonebookIsRunning = false;
                            break;
                        case 4:
                            pb1.editUser();
                            phonebookIsRunning = false;
                            break;
                        case 5:
                            Console.WriteLine("Thank you for using my Phonebook!!");
                            phonebookIsRunning = false;
                            break;
                        default:
                            Console.WriteLine("I do not recognize that selection, please try again.");
                            phonebookIsRunning = true;
                            break;

                    }


                }
                Console.WriteLine("Would You like to continue? y/n: ");
                var cont = Console.ReadLine();

                if (cont.ToLower() == "y")
                {
                    cont1 = true;
                    phonebookIsRunning = true;
                }
                else
                {
                    Console.WriteLine("Thank You for using this application!");
                    cont1 = false;
                    phonebookIsRunning = false;

                }
            }
            Console.ReadLine();


        }

    }
}
