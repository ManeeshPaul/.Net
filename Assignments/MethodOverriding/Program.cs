namespace MethodOverriding
{
    class BaseClass
    {
        public BaseClass()
        {
            Console.WriteLine("Constructor of Base class");
        }
        public virtual void Show()
        {
            Console.WriteLine("Base class");
        }
    }
    class DerivedClass : BaseClass
    {
        public DerivedClass() : base()   
        {
            Console.WriteLine("Constructor of Derived class");
        }
        public override void Show()
        {
            Console.WriteLine("Derived Class");
        }
    }

    internal class Overriding
    {
        static void Main(string[] args)
        {
            BaseClass b1 = new BaseClass();
            b1.Show();

            b1 = new DerivedClass();
            b1.Show();
        }
    }
}