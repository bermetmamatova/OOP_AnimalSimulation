using TextFile;


namespace oop2
{
   
    public class Program
    {
        public static void Start(string filename,ref List<Animal> animals)
        {
            TextFileReader reader = new(filename);

            // populating creatures
            reader.ReadLine(out string line); int n = int.Parse(line);
            animals = new();
            for (int i = 0; i < n; ++i)
            {
                char[] separators = new char[] { ' ', '\t' };
                Animal animal = null;

                if (reader.ReadLine(out line))
                {
                    string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    char ch = char.Parse(tokens[0]);
                    string name = tokens[1];
                    int p = int.Parse(tokens[2]);

                    switch (ch)
                    {
                        case 'F': animal = new Fish(name, p); break;
                        case 'D': animal = new Dog(name, p); break;
                        case 'B': animal = new Bird(name, p); break;
                    }
                }
                animals.Add(animal);
            }


            // populating moods
            reader.ReadLine(out line);
            char[] dayType = line.ToCharArray();
            List<IMood> mood = new List<IMood>();

            foreach (char day in dayType)
            {
                switch (day)
                {
                    case 'o': mood.Add(Ordinary.Instance()); break;
                    case 'b': mood.Add(Bad.Instance()); break;
                    case 'g': mood.Add(Good.Instance()); break;
                }
            }
          
            try
            {
                for (int i = 0; i < n; ++i)
                {
                    animals[i].Stimulation(ref mood);
                   
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.ToString());
            }

            //cond. min search:
            List<Animal> result = new List<Animal>();
            int min = int.MaxValue;
            
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].isAlive())
                {
                    if (animals[i].eLevel < min)
                    {
                        min = animals[i].eLevel;
                        result.Clear();
                        result.Add(animals[i]);

                    }
                    else if(animals[i].eLevel == min)
                    {
                        result.Add(animals[i]);
                    }
                }
                
            }
           
            //reesult
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i].name);
            }

        }
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            if (animals != null)
            {
                Console.WriteLine("Please give the file name: ");
                string filename = Console.ReadLine();
                Start(filename,ref animals);
            }
            else
            {
                // nothing happens, because we are sure that the file is correct.
            }
        }
    }
}