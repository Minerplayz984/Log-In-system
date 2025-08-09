using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;


namespace Log_in_System
{
    internal class Program
    {
        static List<User> users = new List<User>();
        static Random random_num = new Random();
        static int Access_ID = random_num.Next(1000, 10000);

        public class User 
        {
            public string username;
            public string password;
            public string name;
            public DateTime DateofBirth;
            public string Hobbies;
        }
        static bool LoginState = false;
        static User currentUser;
        static string Msg;
        static void ErrorMsg(string msg)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.Beep();
            Console.ResetColor();
            Menu();
            return;
        }
        static void ErrorMsg2(string msg)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.Beep();
            Console.ResetColor();
        }
        static void CreateAccount()
        {
            if (LoginState == false)
            {
                User user = new User();
                Console.WriteLine("Enter username: ");
                try
                {
                    User N = new User();
                    N.username = Console.ReadLine();
                    foreach (User L in users)
                    {
                        if (L.username == N.username)
                        {
                            ErrorMsg(Msg= "An account with this username already exists !!");
                        }
                    }
                    user.username = N.username;
                    if (string.IsNullOrWhiteSpace(user.username))
                    {
                        throw new ArgumentException("Username can't be empty or have a space");
                    }
                    Console.WriteLine("Enter password: ");
                    user.password = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(user.password))
                    {
                        throw new ArgumentException("Password can't be empty or have a space");
                    }
                    users.Add(user);
                }
                catch (ArgumentException e)
                {
                    if (e.Message == "Username can't be empty or have a space")
                    {
                        ErrorMsg(Msg = "Username can't be empty or have a space !!");
                    }
                    if (e.Message == "Password can't be empty or have a space")
                    {
                        ErrorMsg(Msg = "Password can't be empty or have a space !!");
                    }
                }
                catch (Exception)
                {
                    ErrorMsg("Unknown error occurred");
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("User created successfully!");
                Console.Beep();
                Console.ResetColor();
                Menu();
                return;
            }
            else
            {
                ErrorMsg(Msg = "You must be logged out to create an account !!");
            }
        }


        static void AccountLogin()
        {
            try
            {
                if (LoginState == false)
                {
                    Console.WriteLine("Enter your username :");
                    string LoginAttemptUsername = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(LoginAttemptUsername))
                    {
                        throw new ArgumentException("Username can't be empty or have a space");
                    }
                    Console.WriteLine("Enter your password:");
                    string LoginAttemptPassword = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(LoginAttemptPassword))
                    {
                        throw new ArgumentException("Password can't be empty or have a space");
                    }
                    User LoggedUser = null;
                    foreach (User p in users)
                    {
                        if (p.username == LoginAttemptUsername && p.password == LoginAttemptPassword)
                        {
                            LoggedUser = p;
                            break;
                        }
                    }
                    if (LoggedUser != null)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Login successful!");
                        Console.Beep();
                        Console.ResetColor();
                        LoginState = true;
                        currentUser = LoggedUser;
                        LoginSucces(LoggedUser);
                    }
                    else
                    {
                        ErrorMsg(Msg = "Username or password are incorrect !!");
                    }
                }
                else
                {
                    ErrorMsg(Msg = "You are already logged in !!");
                }
            }
            catch (ArgumentException t)
            {
                if (t.Message == "Username can't be empty or have a space")
                {
                    ErrorMsg(Msg = "Username can't be empty or have a space !!");
                }
                if (t.Message == "Password can't be empty or have a space")
                {
                    ErrorMsg(Msg = "Password can't be empty or have a space !!");
                }
            }
            catch (Exception)
            {
                ErrorMsg(Msg = "Unknown error occurred");
            }
        }



        static void LoginSucces(User user) 
        {
            Console.WriteLine("===================\nAccount information\n===================");
            Console.WriteLine("Username: " + user.username);
            Console.WriteLine("Password: "+ user.password);
            if (string.IsNullOrEmpty(user.name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Full name not set! (Enter 1 to set it)");
                Console.ResetColor();
            }
            else
            {
                Console.Write("Full name: " + user.name);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  (Enter 1 to change it)");
                Console.ResetColor();
            }
            if (user.DateofBirth == DateTime.MinValue)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Date of birth not set! (Enter 2 to set it)");
                Console.ResetColor();
            }
            else
            {
                Console.Write("Date of birth : " + user.DateofBirth.ToString("dd/MM/yyyy"));
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  (Enter 2 to change it)");
                Console.ResetColor();
            }
            if (string.IsNullOrEmpty(user.Hobbies))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hobbies not set! (Enter 3 to set it)");
                Console.ResetColor();
            }
            else
            {
                Console.Write("Hobbies: " + user.Hobbies);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n(Enter 3 to change it)");
                Console.ResetColor();
            }
            Console.WriteLine("Enter a number from the above or enter 4 to return to main menu");
            try
            {
                string choice21 = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(choice21))
                {
                    throw new ArgumentException("Number inputted can't be empty");
                }
                int choice2=0;
                try
                {
                    choice2 = int.Parse(choice21);
                }
                catch(FormatException)
                {
                    ErrorMsg2(Msg= "Number inputted is in the wrong format !!");
                    LoginSucces(user);
                }
                switch (choice2)
                {
                    case 1:
                        Console.Write("Enter your full name: ");
                        User h = new User();
                        h.username = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(h.username))
                        {
                            throw new ArgumentException("Full name can't be empty");
                        }
                        foreach (char f in h.username)
                        {
                            if (!(char.IsLetter(f) || f == ' '))
                            {
                                throw new ArgumentException("Full name can only have alphabets and spaces");
                            }
                        }
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        user.name = h.username;
                        Console.WriteLine("Full name added successfully !!");
                        Console.Beep();
                        Console.ResetColor();
                        LoginSucces(user);
                        break;
                    case 2:
                        Console.Write("Enter your Date of birth (DD/MM/YYYY) : ");
                        string gtry = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(gtry))
                        {
                            throw new ArgumentException("Date of birth can't be empty");
                        }
                        try
                        {
                            user.DateofBirth = DateTime.ParseExact(gtry, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                        catch (FormatException)
                        {
                            ErrorMsg2(Msg = "Date of birth must be in the DD/MM/YYYY format !!");
                            LoginSucces(user);
                        }
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Date of birth added successfully");
                        Console.Beep();
                        Console.ResetColor();
                        LoginSucces(user);
                        break;
                    case 3:
                        Console.Write("Enter your Hobbies: ");
                        User plo = new User();
                        plo.username = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(plo.username))
                        {
                            throw new ArgumentException("Hobbies can't be empty");
                        }
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        user.Hobbies = plo.username;
                        Console.WriteLine("Hobbies added successfully !!");
                        Console.Beep();
                        Console.ResetColor();
                        LoginSucces(user);
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Going back to Main Menu...");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                        Menu();
                        return;
                    default:
                        ErrorMsg2(Msg = "Only numbers 1 to 4 are valid!!");
                        LoginSucces(user);
                        break;
                }
            }
            catch (ArgumentException k)
            {
                if (k.Message == "Full name can't be empty")
                {
                    ErrorMsg2(Msg = "Full name can't be empty !!");
                    LoginSucces(user);
                }
                if (k.Message == "Full name can only have alphabets and spaces")
                {
                    ErrorMsg2(Msg = "Full name can only have alphabets and spaces !!");
                    LoginSucces(user);
                }
                if (k.Message == "Date of birth can't be empty")
                {
                    ErrorMsg2(Msg = "Date of birth can't be empty !!");
                    LoginSucces(user);
                }
                if (k.Message == "Number inputted can't be empty")
                {
                    ErrorMsg2(Msg = "Number inputted can't be empty !!");
                    LoginSucces(user);
                }
                if (k.Message == "Hobbies can't be empty")
                {
                    ErrorMsg2(Msg = "Hobbies can't be empty !!");
                    LoginSucces(user);
                }
            }
            catch (Exception)
            {
                ErrorMsg2(Msg = "Unknown error occurred");
                LoginSucces(user);
            }
        }

        static void ModifyAccount()
        {
            if ((LoginState == true)&&(currentUser != null))
            {
                Console.Clear();
                LoginSucces(currentUser);
            }
            else
            {
                ErrorMsg(Msg = "You must be logged in to use this !!");
            }
        }

        static void AccountLogout()
        {
            if (LoginState == true)
            {
                LoginState = false;
                currentUser = null;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully Logged out");
                Console.Beep();
                Console.ResetColor();
                Menu();
                return;
            }
            else
            {
                ErrorMsg(Msg = "You are already logged out!!");
            }
        }

        static void AccountDeletion()
        {
            if ((LoginState == true) && (currentUser != null))
            {
                users.Remove(currentUser);
                LoginState = false;
                currentUser = null;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Account deleted successfully");
                Console.Beep();
                Console.ResetColor();
                Menu();
                return;
            }
            else
            {
                ErrorMsg(Msg = "You must be logged in to use this !!");
            }
        }

        static void ShowList() 
        {
            Console.Write("Enter Access ID: ");
            Console.WriteLine("                                                                                  Admin access ID: {0}", Access_ID);
            try
            {
                string TryID = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(TryID))
                {
                    throw new ArgumentException();
                }
                int ID = int.Parse(TryID);
                if (ID == Access_ID)
                {
                    if (users.Count != 0)
                    {
                        foreach (var names in users)
                        {
                            Console.WriteLine("-{0}", names.username);

                        }
                        Console.WriteLine("Press any key to return to the main menu ...");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nGoing back to Main Menu...");
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                        Menu();
                        return;
                    }
                    else
                    {
                        ErrorMsg(Msg = "No users have been created yet !!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect Access ID !!");
                    Console.Beep();
                    Console.ResetColor();
                    ShowList();
                    return;
                }
            }
            catch (ArgumentException)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID can't be empty !!");
                Console.Beep();
                Console.ResetColor();
                ShowList();
                return;
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ID is in the wrong format !!");
                Console.Beep();
                Console.ResetColor();
                ShowList();
                return;
            }
            catch (Exception)
            {
                ErrorMsg(Msg = "Unknown error occurred");
            }
        }

        static void Menu()
        {
            Console.WriteLine("1- Create account                                                                                  Admin access ID: {0}",Access_ID);
            Console.WriteLine("2- Login");
            Console.WriteLine("3- Modify account");
            Console.WriteLine("4- Logout");
            Console.WriteLine("5- Delete account");
            Console.WriteLine("6- Show all usernames (Needs special ID)");
            Console.WriteLine("7- Exit");
            try
            {
                string choicetry = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(choicetry))
                {
                    throw new ArgumentException();
                }
                int choice = int.Parse(choicetry);
                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        AccountLogin();
                        break;
                    case 3:
                        ModifyAccount();
                        break;
                    case 4:
                        AccountLogout();
                        break;
                    case 5:
                        AccountDeletion();
                        break;
                    case 6:
                        Console.Clear();
                        ShowList();
                        break;
                    case 7:
                        Console.Write("Exiting program... Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        ErrorMsg(Msg = "Only numbers 1 to 7 are valid!!");
                        return;
                }
            }
            catch (FormatException)
            {
                ErrorMsg(Msg = "Number inputted is in the wrong format !!");
            }
            catch (ArgumentException)
            {
                ErrorMsg(Msg = "Number can't be empty !!");
            }
            catch (Exception)
            {
                ErrorMsg(Msg = "Unknown error occurred");
            }
        }



        static void Main(string[] args)
        {
            Menu();
        }
    }
}

