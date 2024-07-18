using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace oop2
{
   public interface IMood
    {
        //public void Change(Animal a);
        IMood Change(Dog p);
        IMood Change(Bird p);
        IMood Change(Fish p);
    }
    class Ordinary : IMood
    {
        public IMood Change(Dog p)
        {
           //do nothing
            return this;
            
        }
        public IMood Change(Fish p)
        {
            p.LevelChange(-3);
            return this;
            
        }
        public IMood Change(Bird p)
        {
            p.LevelChange(-1);
            return this;
            
        }

        private Ordinary() { }

        private static Ordinary instance = null;
        public static Ordinary Instance()
        {
            if (instance == null)
            {
                instance = new Ordinary();
            }
            return instance;
        }
    }

    class Good : IMood
    {
        public IMood Change(Dog p)
        {
            p.LevelChange(3);
            return this;

        }
        public IMood Change(Fish p)
        {
            p.LevelChange(1);
            return this;

        }
        public IMood Change(Bird p)
        {
            p.LevelChange(2);
            return this;

        }

        private Good() { }

        private static Good instance = null;
        public static Good Instance()
        {
            if (instance == null)
            {
                instance = new Good();
            }
            return instance;
        }
    }
    class Bad : IMood
    {
        public IMood Change(Dog p)
        {
            p.LevelChange(-10);
            return this;

        }
        public IMood Change(Fish p)
        {
            p.LevelChange(-5);
            return this;

        }
        public IMood Change(Bird p)
        {
            p.LevelChange(-3);
            return this;

        }
        private Bad() { }

        private static Bad instance = null;
        public static Bad Instance()
        {
            if (instance == null)
            {
                instance = new Bad();
            }
            return instance;
        }
    }


}
