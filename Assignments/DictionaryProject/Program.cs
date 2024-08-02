namespace DictionaryProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> myDict = new Dictionary<int,string>();
            myDict.Add(1, "Arjun");
            myDict.Add(2, "Sachin");
            myDict.Add(3, "Arun");

            foreach(KeyValuePair<int,string> dictValues in myDict)
            {
                Console.WriteLine( "Key : {0}, Value : {1}",dictValues.Key,dictValues.Value );
            }


            Console.WriteLine("****************************");

            HashSet<int> myHashset = new HashSet<int>();        
            myHashset.Add(1);
            myHashset.Add(2);   
            myHashset.Add(3);
            myHashset.Add(4);
            foreach(var item in myHashset)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("**************************");

            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            while(myQueue.Count>0)
            {
                Console.WriteLine(myQueue.Dequeue());  
            }

            Console.WriteLine("*********************");


            Stack<int> myStack = new Stack<int>();  
            myStack.Push(1);
            myStack.Push(2);    
            myStack.Push(3);

            while(myStack.Count>0)
            {
                Console.WriteLine(myStack.Pop());
            }

        }
    }
}