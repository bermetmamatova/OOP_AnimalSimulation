using Microsoft.VisualStudio.TestPlatform.TestHost;
using oop2;

namespace Testingg
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void NoAnimal()
        {
            List<Animal> animals = new List<Animal>();
            oop2.Program.Start("input1.txt", ref animals);
            Assert.AreEqual(0, animals.Count);
        }
        
        [TestMethod]
        public void OneAnimal()
        {
            List<Animal> animals = new List<Animal>();
            oop2.Program.Start("input.txt", ref animals);
            List<Animal> res = animals.Where(a => a is Dog).ToList();
            Assert.AreEqual("Lassie", res[0].name);
            Assert.AreEqual(1, res.Count);
        }

        
        [TestMethod]
        public void MoreThanOneAnimal()
        {
            List<Animal> animals = new List<Animal>();
            oop2.Program.Start("input2.txt", ref animals);
            List<Animal> res = animals.Where(a => a is Dog).ToList();
            Assert.AreEqual(2, res.Count);
            Assert.AreEqual("Lassie", res[0].name);
            Assert.IsTrue(res[0].isAlive());
            Assert.AreEqual("Akdosh", res[1].name);
            Assert.IsTrue(res[1].isAlive());
        }


        [TestMethod]
        public void AllDead()
        {
            List<Animal> animals = new List<Animal>();
            oop2.Program.Start("input3.txt", ref animals);
            List<Animal> res = animals.Where(a => a.isAlive()).ToList(); 
            Assert.AreEqual(0, res.Count); 
        }


    }
}

