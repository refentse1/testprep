using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
    public class BusinessLogicClass
    {
        public BusinessLogicClass()
        {
            
        }

        DataAccessClass DataAccessObject = new DataAccessClass();
        string currentUserEmail = "";
        string newEmail = "";
        string newPassword = "";
        public void RegisterUser()
        {
            Console.Write("Enter your Fullname: ");
            string FullNames = Console.ReadLine();
            Console.Write("Enter your Email: ");
            string Email = Console.ReadLine();

            while (FullNames!="" && Email !="")
            {
                Console.Write("Enter a password: ");
                string pass1 = Console.ReadLine();
                Console.Write("Confirm password: ");
                string password = Console.ReadLine();

                if (pass1 == password)
                {
                    //Register user here(add user to repository)
                    string userObject = $"{FullNames},{Email},{password}\n";
                    DataAccessObject.AddUser(userObject);
                    Console.WriteLine("User successfully added");
                    break;
                }
                else
                {
                    Console.WriteLine("Passwords don't match...");
                }
            }
            Console.WriteLine("===========================================================\n\n");
        }


        public void LoginUser(string email,string password)
        {
            //Check if user with email and password exist
            List<string> users = DataAccessObject.GetUsers();

            foreach (var user in users)
            {
                string[] userDetails = user.Split(',');

                if (userDetails[1]==email && userDetails[2]==password)
                {
                    Console.WriteLine($"Welcome {userDetails[0]}\n\n");

                    currentUserEmail = $"{userDetails[1]}";

                    while (true)
                    {
                        Console.Write("Enter 1 to create a blog or 2 to read blogs or 3 to go to profile or 0 to logout: ");
                        string input = Console.ReadLine();

                        if(input == "0")
                        {
                            break;
                        }
                        if(input == "1")
                        {
                            Console.WriteLine("\n");
                            //Create blog here
                            Console.Write("Enter blog title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter blog text: ");
                            string text = Console.ReadLine();
                            if(title!="" && text != "")
                            {
                                string blogObject = $"{title},{userDetails[0]},{text},{DateTime.Now}\n";
                                //Insert to blog repository
                                DataAccessObject.AddBlog(blogObject);
                                Console.WriteLine("Blog added successfully\n");
                            }

                            
                        }
                        else if (input == "2")
                        {
                            //Retrieve all blogs
                            List<string> blogs = DataAccessObject.GetBlogs();

                            Console.Write("\nEnter 1 to display all blogs or 2 to filter by user: ");
                            string option = Console.ReadLine();


                            if (option == "1")
                            {
                                Console.WriteLine("=====================================");
                                Console.WriteLine("\nBlogs\n");
                                foreach (var item in blogs)
                                {
                                    string[] blog = item.Split(',');

                                    foreach (var blogdetail in blog)
                                    {
                                        Console.WriteLine(blogdetail);
                                    }
                                    Console.WriteLine("\n");
                                }
                            }else if(option == "2")
                            {
                                Console.Write("Enter user name: ");
                                string filter = Console.ReadLine();
                                string filterd = filter[0].ToString().ToUpper() + filter.Substring(1);
                                foreach (var item in blogs)
                                {
                                    if (item.Contains(filterd))
                                    {
                                        string[] blog = item.Split(',');

                                        Console.WriteLine("=====================================");
                                        Console.WriteLine($"\nBlogs by {filter}\n");
                                        foreach (var blogDetail in blog)
                                        {
                                            Console.WriteLine(blogDetail);
                                        }
                                    }
                                }
                            }
                          

                        }
                        else if (input == "3")
                        {
                            while (true)
                            {
                                Console.WriteLine("Enter 1 to edit email or 2 to edit password or 0 to go back to Home");
                                string profileOptions = Console.ReadLine();

                                if (profileOptions == "1")
                                {
                                    //Edit details
                                    Console.Write("Enter new email: ");
                                    newEmail = Console.ReadLine();
                                    UpdateUserDetails(newPassword,newEmail);
                                }
                                else if (profileOptions == "2")
                                {
                                    Console.Write("Enter new password: ");
                                    newPassword = Console.ReadLine();
                                    UpdateUserDetails(newPassword, newEmail);
                                }
                                else if (profileOptions == "0")
                                {
                                    break;
                                }
                            }
                        }
                        Console.WriteLine("===========================================================\n\n");
                    }
                }
            }
        }
        public void UpdateUserDetails(string password,string newEmail)
        {
            List<string> user = DataAccessObject.GetUsers();


            for (int i = 0; i < user.Count; i++)
            {
                if (user[i].Contains(currentUserEmail))
                {
                    
                    string[] newUser = user[i].Split(',');

                    if (newEmail != "")
                    {
                        newUser[1] = newEmail;

                        if (password != "")
                        {
                            newUser[2] = password;
                        }
                    }
                    else if (password != "")
                    {
                        newUser[2] = password;
                    }

                    user[i] = $"{newUser[0]},{newUser[1]},{newUser[2]}";
                    

                    break;
                }
            }

            DataAccessObject.UpdateUser(user.ToArray<string>());
        }
    }
}
