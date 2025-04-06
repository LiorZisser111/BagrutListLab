using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagrutListLab
{
    public class Student
    {
        private int grade;
        private string name;


        public Student(int grade, string name)
        {
            this.grade = grade;
            this.name = name;
        }

        public int GetGrade()
        {
            return grade;
        }
        public string GetName()
        {
            return name;
        }

        public override string ToString()
        {
            return '['+name+','+grade+']';
        }
    }
}
