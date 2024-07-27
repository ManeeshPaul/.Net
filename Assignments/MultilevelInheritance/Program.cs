namespace MultilevelInheritance
{
    class A
    {
        public A()
        {
            Console.WriteLine("A");
        }
    }
    class B : A
    {
        public B()
        {
            Console.WriteLine("B");
        }
    }
    class C : B
    {
        public C()
        {
            Console.WriteLine("c");
        }
    }
    internal class MutiLevelInheritance
    {
        static void Main(string[] args)
        {
            C c = new C();
        }
    }
}