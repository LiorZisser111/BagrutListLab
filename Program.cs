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


        Student s1 = new Student(30, "Lior");
        Student s2 = new Student(80, "Mark");
        Student s3 = new Student(95, "Harel");
        Student s4 = new Student(100, "Shlomi");
        Student s5 = new Student(77, "yahin");
        Node<Student> lst4 = new(s4);
        lst4 = new(s3, lst4);
        lst4= new(s2, lst4);
        lst4 = new(s1, lst4);

        Node<Student> newStud = new(s5);
        Console.WriteLine("The new list is: " + InsertNodeStud(lst4, newStud));

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

}
