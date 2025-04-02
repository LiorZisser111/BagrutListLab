using ListLab;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Node<int> lst = new Node<int>(5);//יצירת חוליה ראשונה ששם הרשימה מצביע עליה
                                         //null בעת היצירה החוליה היחידה מצביעה על
        Console.WriteLine(lst);
        Node<int> currNode = new Node<int>(7, lst);//יצירת חוליה נוספת, שמוצבת לפני ליסט ומצביעה
                                                   //על החוליה הראשונה של ליסט
        lst = currNode;//גורמים למצביע ליסט להצביע על החוליה שהוספנו בתחילת הרשימה
        Console.WriteLine(lst);
        currNode = new Node<int>(9, lst);
        lst = currNode;
        currNode = new Node<int>(-2, lst);
        lst = currNode;
        currNode = new Node<int>(10, lst);
        lst = currNode;
        currNode = new Node<int>(22, lst);
        lst = currNode;
        currNode = new Node<int>(1, lst);
        lst = currNode;
        currNode = new Node<int>(-1, lst);
        lst = currNode;
        currNode = new Node<int>(-9, lst);
        lst = currNode;
        lst = new Node<int>(-55, lst);//צורת כתיבה שמאפשרת להוסיף חוליה בראש שרשרת החוליות ולהעביר אתיה את מצביע ראש הרשימה
        Console.WriteLine(lst);

        Console.WriteLine(lst.GetValue());//הדפסת הערך של החוליה הראשונה ברשימה

        Console.WriteLine(lst.GetNext().GetValue());//הדפסת הערך של החוליה השנייה ברשימה

        currNode = lst.GetNext();//הצבעה על החוליה השניה בשרשרת החוליות

        currNode = currNode.GetNext();//קידום ההצבעה של החוליות הנוכחית באחת

        //שילוב חוליה חדשה בשרשרת אחרי חוליה נתונה
        //נהנה למשל שרשרת חוליות מסודרת בסדר עולה
        Node<int> lst1 = new Node<int>(10);// 10-->null
        lst1 = new Node<int>(8, lst1);// 8-->10-->null
        lst1 = new Node<int>(6, lst1);// 6-->8-->10-->null
        lst1 = new Node<int>(4, lst1);// 4-->6-->8-->10-->null
        Console.WriteLine(lst1);

        //ניצור חולייה חדשה ונכניס אותה לשרשרת לפי ערך המספר
        Node<int> NewNode = new Node<int>(12);// 7-->null
        currNode = lst1;//הצבעה על החוליה הראשונה בשרשרת
        if (currNode.GetValue() > NewNode.GetValue())
        {
            NewNode.SetNext(lst1);//הצבת החוליה החדשה לפני החוליה הראשונה בשרשרת
            lst1 = NewNode;//ההצבת שם השרשרת על המספר החדש שנוסף בראשה
        }
        else
        {
            while (currNode.HasNext() && currNode.GetNext().GetValue() < NewNode.GetValue())
            {
                currNode = currNode.GetNext();//כל עוד יש חוליה עוקבת והערך שלה קטן מהחוליה החדשה מתקדמים חוליה
            }
            NewNode.SetNext(currNode.GetNext());//הצבת החוליה החדשה לפני החוליה העוקבת את הנוכחית
            currNode.SetNext(NewNode);//הצבת החוליה החדשה אחרי החוליה הנוכחית        
        }
        Console.WriteLine(lst1);

        Console.WriteLine("The size is: "+LengthList(lst1));

        Console.WriteLine("Result: "+ IsPefectList(lst1));

    }





    public static int LengthList(Node<int> first)
    {
        int count = 0;
        Node<int> pos = first;
        while (first != null)
        {
            pos = first.GetNext();
            count++;
        }
        return count;
    }

    public static bool IsPefectList(Node<int> first)
    {
        Node<int> pos = first;
        Node<int> lastNode = first;

        for (int i = 0; i < LengthList(first) / 2; i++)
        {
            lastNode = lastNode.GetNext();
        }
        for(int i = 0; i < LengthList(lastNode) / 2; i++)
        {
            for(int j = 0; j < LengthList(lastNode) /2; j++)
            {
                if(lastNode.GetValue() >= first.GetValue())
                {
                    return false;
                }
                lastNode = lastNode.GetNext();
                pos = pos.GetNext();

            }
        }

        return true;
    }
}
