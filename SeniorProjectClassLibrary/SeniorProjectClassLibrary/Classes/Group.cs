using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SeniorProject
{
    public class Group
    {

        private int id;
        private string name;
        private string notes;
        private string type;
        private ArrayList computers;
        private ArrayList equipment;

        public Group()
        {
            computers = new ArrayList();
            equipment = new ArrayList();
        }

        public int ID
        {
            get 
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        public ArrayList Computers
        {
            get
            {
                return computers;
            }
            set
            {
                computers = value;
            }
        }

        public ArrayList Equipment
        {
            get
            {
                return equipment;
            }
            set
            {
                equipment = value;
            }
        }

    }
}
