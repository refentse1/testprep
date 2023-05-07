using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccess
{
    public class DataAccessClass
    {
        public DataAccessClass()
        {
            
        }

        //Add user to repository
        string userRepo = "./users.txt";
        string blogRepo = "./blogs.txt";
        public void AddUser(string user)
        {
            File.AppendAllText(userRepo, user);
        }

        //Update user
        public void UpdateUser(string[] user)
        {
            File.WriteAllLines(userRepo,user);
            Console.WriteLine("User Details Updated successfully...\n\n");
        }

        //Get users from repository
        public List<string> GetUsers()
        {
            List<string> users = File.ReadAllLines(userRepo).ToList<string>();

            return users;
        }

        //Add blog to reposiroty
        public void AddBlog(string blog)
        {
            File.AppendAllText(blogRepo, blog);
        }

        //Get blogs from repository
        public List<string> GetBlogs()
        {
            List<string> blogs = File.ReadAllLines(blogRepo).ToList<string>();
            return blogs;
        }
        
    }
}
