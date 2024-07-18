using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;



namespace oop2
{
    public abstract class Animal
    {
        public string name { get; }
        public int eLevel { get; set; }

        protected Animal (string s,int l=0) { name = s; eLevel = l; }

        public void LevelChange(int e) { eLevel += e; }

        public bool isAlive() => eLevel > 0;

        public void Stimulation(ref List<IMood> moods)
        {
            for (int j = 0; isAlive() && j < moods.Count; ++j)
            {
                moods[j] = Traverse(moods[j]);
            }
        }
        protected abstract IMood Traverse(IMood mood);
    }

    public class Dog : Animal
    {
        public Dog(string str, int e = 0) : base(str, e) { }
        protected override IMood Traverse(IMood mood)
        {
            return mood.Change(this);
        }
    }
    public class Bird : Animal
    {
        public Bird(string str, int e = 0) : base(str, e) { }
        protected override IMood Traverse(IMood mood)
        {
            return mood.Change(this);
        }
    }
    public class Fish : Animal
    {
        public Fish(string str, int e = 0) : base(str, e) { }
        protected override IMood Traverse(IMood mood)
        {
            return mood.Change(this);
        }
    }
}
