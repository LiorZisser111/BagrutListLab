using BagrutListLab;
using ListLab;
using System.Collections.Generic;

public class Program
{
    private static void Main(string[] args)
    {
        Node<int> lst1 = new Node<int>(10);
        Node<int> currNode= new Node<int>(9,lst1);
        lst1 = currNode;
        currNode= new(8,lst1);
        lst1 = currNode;
        currNode = new(6,lst1);
        lst1 = currNode;
        currNode = new(5,lst1);
        lst1 = currNode;
        currNode = new(4,lst1);
        lst1 = currNode;
        currNode = new(3,lst1);
        lst1 = currNode;
        currNode = new(2,lst1);
        lst1 = currNode;
        Console.WriteLine("sum is:"+SumLinked(lst1));
        Console.WriteLine("amount of evens:"+ EvenInList(lst1));
        InsertSortedList(lst1,7);
        lst1 = new(1, lst1);
        Console.WriteLine(lst1);
        Console.WriteLine("size is: "+ SizeLst(lst1));
        Console.WriteLine("is it perf: "+CheckPerfLst(lst1));


        Ranges r1 = new Ranges(1,9);
        Ranges r2 = new Ranges(20, 22);
        Ranges r3 = new Ranges(30, 69);
        Ranges r4 = new Ranges(76, 99);
        Node<BagrutListLab.Ranges> lst3 = new(r4);
        lst3 = new(r3,lst3);
        lst3 = new(r2,lst3);
        lst3 = new(r1,lst3);
        Console.WriteLine(lst3);
        Console.WriteLine(IsInRange(lst3, 1000));

        Console.WriteLine("The new list is: "+ CreateRangeForNumber(lst3,23));


        //homeword for passover:
        Console.WriteLine("\n------------HomeWork for passover------------");
        //ex1:
        Student s1 = new Student(85, "Noa");
        Student s2 = new Student(92, "Lior");
        Student s3 = new Student(76, "Maya");

        Node<Student> list = new Node<Student>(s3);
        list = new Node<Student>(s2, list);
        list = new Node<Student>(s1, list);

        Console.WriteLine("\nThe memoza: "+ MemozaStud(list));

        //ex2:
        Student s4 = new Student(30, "Lior");
        Student s5 = new Student(80, "Mark");
        Student s6 = new Student(95, "Harel");
        Student s7 = new Student(100, "Shlomi");
        Student s8 = new Student(77, "yahin");
        Node<Student> lst4 = new(s7);
        lst4 = new(s6, lst4);
        lst4= new(s5, lst4);
        lst4 = new(s4, lst4);

        Node<Student> newStud = new(s8);
        Console.WriteLine("\nThe new list is: " + InsertNodeStud(lst4, newStud));




        //ex3:
        Group g1 = new Group(1);
        g1.AddStudent("David");
        g1.AddStudent("Noa");
        g1.AddStudent("Lior");

        Group g2 = new Group(2);
        g2.AddStudent("David");
        g2.AddStudent("Lior");
        g2.AddStudent("Sara");

        Group g3 = new Group(3);
        g3.AddStudent("David");
        g3.AddStudent("Lior");
        g3.AddStudent("Maya");
        Group[] groupArr = new Group[] { g1, g2, g3 };
        Console.WriteLine("\nNames that appear on all lists:");
        Node<string> commonNames = AllGroups(groupArr);
        Console.WriteLine(commonNames);

    }
    public static int SumLinked(Node<int> first)
    {
        Node<int> pos = first;
        int sum = 0;
        while (pos != null)
        {
            sum += pos.GetValue();
            pos = pos.GetNext();
        }
        return sum;
    }
    public static int EvenInList(Node<int> first)
    {
        Node<int> pos = first;
        int evens = 0;
        while (pos != null)
        {
            if (pos.GetValue() % 2 == 0)
            {
                evens++;
            }
            pos = pos.GetNext();
        }
        return evens;
    }
    public static int BiggestInList (Node<int> first)
    {
        Node<int> pos = first;
        int biggest=pos.GetValue();
        while (pos != null)
        {
            if (pos.GetValue() > biggest)
            {
                biggest = pos.GetValue();
            }
            pos = pos.GetNext();
        }
        return biggest;

    }
    public static void InsertSortedList(Node<int> first,int hadash)
    {
        Node<int> pos= first;
        Node<int> insert = new(hadash);
        while (pos.GetNext().GetValue() < insert.GetValue())
        {
            pos = pos.GetNext();
        }
        insert.SetNext(pos.GetNext());
        pos.SetNext(insert);
    }
    public static int SizeLst(Node<int> first)
    {
        Node<int> pos = first;
        int size = 0;
        while (pos != null)
        {
            size++;
            pos = pos.GetNext();
        }
        return size;
    }
    public static bool CheckPerfLst(Node<int> first)
    {
        Node<int> last = first;
        Node<int> pos = first;
        for(int i = 0;i<SizeLst(first)/2; i++)
        {
            last = last.GetNext();
        }
        for (int i = 0; i<SizeLst(last)/2; i++)
        {
            for(int j = 0; j<SizeLst(last)/2; j++)
            {
                if(last.GetValue() < pos.GetValue())
                {
                    return false;
                }
                pos = pos.GetNext();
            }
            last = last.GetNext();
            pos = first;
        }
        return true;
    }

    public static bool IsInRange(Node<BagrutListLab.Ranges> first, int number)
    {
        Node<BagrutListLab.Ranges> pos = first;
        while(pos != null)
        {
            if(pos.GetValue().GetHigh() >= number && pos.GetValue().GetLow() <= number)
            {
                return true;
            }

            pos = pos.GetNext();
        }

        return false;
    }

    public static Node<BagrutListLab.Ranges> CreateRangeForNumber(Node<BagrutListLab.Ranges> first, int number)
    {
        Node<BagrutListLab.Ranges> pos = first;
        while (number > pos.GetNext().GetValue().GetHigh())
        {
            pos = pos.GetNext();
            if (pos.HasNext())
            {
                break;
            }
        }
        int uppernum;
        if(pos.HasNext() && pos.GetNext().GetValue().GetLow() > number +5)
        {
            uppernum = number + 5;
        }
        else if(pos.HasNext() && pos.GetNext().GetValue().GetLow() <= number + 5)
        {
            uppernum = pos.GetNext().GetValue().GetHigh() -1 ;
        }
        else
        {
            uppernum = number - 5;
        }

        int lowerNum;
        if (pos.HasNext() && pos.GetValue().GetHigh() < number - 5)
        {
            lowerNum = number - 5;
        }
        else if (pos.HasNext() && pos.GetValue().GetHigh() >= number - 5)
        {
            lowerNum = pos.GetValue().GetHigh() +1;
        }
        else
        {
            lowerNum = number - 5;
        }
        
        Ranges r = new(lowerNum, uppernum);
        Node<BagrutListLab.Ranges> newR = new(r, pos.GetNext());
        pos.SetNext(newR);

        return pos;
    }




    // homework for passover:

    //ex1:
    public static double MemozaStud(Node<Student> lst)
    {
        int sum = 0;
        int countOfStud = 0;
        Node<Student> pos = lst;
        while (pos != null)
        {
            sum += pos.GetValue().GetGrade();
            pos = pos.GetNext();
            countOfStud++;
        }
        int memoza = sum / countOfStud;
        return memoza;
    }

    //ex2:
    public static Node<Student> InsertNodeStud(Node<Student> first, Node<Student> newNode)
    {
        if(first == null || first.GetValue().GetGrade() > newNode.GetValue().GetGrade())
        {
            newNode.SetNext(first);
            return newNode;
        }
        Node<Student> currNode = first;
        while(currNode.HasNext() && currNode.GetNext().GetValue().GetGrade() < newNode.GetValue().GetGrade())
        {
            currNode = currNode.GetNext();
        }

        newNode.SetNext(currNode.GetNext());
        currNode.SetNext(newNode);
        return first;

    }

    //ex3:
    public static bool IsInList(Node<string> lst, string name)
    {
        Node<string> pos = lst;
        while (pos != null)
        {
            if(pos.GetValue() == name)
            {
                return true;
            }
            pos = pos.GetNext();
        }
        return false;
    }

    public static Node<string> AllGroups(Group[] groupArr)
    {
        Node<string> commonNames = null;

        Group firstGroup = groupArr[0];
        for (int i = 0; i < firstGroup.GetKamut(); i++)
        {
            string name = firstGroup.GetNamesArr()[i];
            bool isInAll = true;
            for (int j = 1; j < groupArr.Length && isInAll; j++)
            {
                if (!groupArr[j].IsIncluded(name))
                    isInAll = false;
            }
            if (isInAll && !IsInList(commonNames, name))
            {
                commonNames = new Node<string>(name, commonNames);
            }
        }
        return commonNames;
    }


}
