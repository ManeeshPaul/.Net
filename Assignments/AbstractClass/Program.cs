namespace AbstractClass
{
    internal class Abstract
    {
        abstract class Animal
        {
            public abstract string Sound { get; }
            public virtual void Move()
            {
                Console.WriteLine("Animal is moving in the base class");
            }
        }
        class Cat : Animal
        {
            public override string Sound => "Meow";
            public override void Move()
            {
                Console.WriteLine("Cat is moving in the derived class");
            }
        }
        class Dog : Animal
        {
            public override string Sound => "Bark";
            public override void Move()
            {
                Console.WriteLine("Dog is moving in the derived class");
            }
        }
        static void Main(string[] args)
        {
            Animal[] animal = new Animal[] { new Cat(), new Dog() };

            foreach (var anim in animal)
            {
                Console.WriteLine($"The {anim.GetType().Name} goes {anim.Sound}");
                anim.Move();
            }
        }
    }
}