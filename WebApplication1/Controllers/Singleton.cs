using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();

        private Singleton()
        {
            Populate();
        }

        public static Singleton Interns
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }

                    return instance;
                }
            }
        }
        private static List<Intern> interns = new List<Intern>();

        private void Populate()
        {
            interns.Add(new Intern(interns.Count + 1, "Test", "Test"));
            interns.Add(new Intern(interns.Count + 1, "Test", "Test"));
            interns.Add(new Intern(interns.Count + 1, "Test", "Test"));
        }

        public int GetCount()
        {
            return interns.Count;
        }

        public List<Intern> GetAll()
        {
            return interns;
        }

        public Intern GetOne(long Id)
        {
            foreach (var intern in interns)
            {
                if (intern.Id == Id)
                {
                    return intern;
                }
            }

            return null;
        }

        public bool AddIntern(Intern internToBeAdded)
        {
            foreach (var intern in interns)
            {
                if (intern.Id == internToBeAdded.Id)
                {
                    return false;
                }
            }

            if (internToBeAdded.Firstname == null)
            {
                return false;
            }

            if (internToBeAdded.Lastname == null)
            {
                return false;
            }

            if (internToBeAdded.Email == null)
            {
                return false;
            }

            if (internToBeAdded.Position == null)
            {
                return false;
            }

            interns.Add(internToBeAdded);
            return true;
        }

        public bool DeleteIntern(long id)
        {
            int position = 0;
            foreach (var intern in interns)
            {
                if (intern.Id == id)
                {
                    interns.RemoveAt(position);
                    return true;
                }
                position++;
            }
            return false;
        }
    }
}

