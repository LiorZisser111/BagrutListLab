using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagrutListLab
{
    public class Group
    {
        private int num; 
        private string[] namesArr; 
        private int kamut;

        public Group(int num)
        {
            this.num = num;
            this.namesArr = new string[10];
            this.kamut = 0;
        }

        public int GetNum()
        {
            return num;
        }

        public void SetNum(int num)
        {
            this.num = num;
        }

        public string[] GetNamesArr()
        {
            return namesArr;
        }

        public void SetNamesArr(string[] names)
        {
            this.namesArr = names;
        }

        public int GetKamut()
        {
            return kamut;
        }

        public void SetKamut(int kamut)
        {
            this.kamut = kamut;
        }

        public void AddStudent(string name)
        {
            if (kamut < 10)
            {
                namesArr[kamut] = name;
                kamut++;
            }
            else
            {
                Console.WriteLine("הקבוצה מלאה!");
            }
        }

        public bool IsIncluded(string name)
        {
            for (int i = 0; i < kamut; i++)
            {
                if (namesArr[i] == name)
                    return true;
            }
            return false;
        }
    }
}
