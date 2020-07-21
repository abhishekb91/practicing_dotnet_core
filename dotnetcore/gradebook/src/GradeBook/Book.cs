using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class InMemoryBook : Book
    {
        private List<double> grades;

        public InMemoryBook(string name) : base (name) {
            this.Name = name;
            this.grades = new List<double>();
        }

        public void AddGrade(char letter)
        {
            switch(letter) 
            {
                case 'A':
                    this.AddGrade(90);
                    break;
                case 'B':
                    this.AddGrade(80);
                    break;
                case 'C':
                    this.AddGrade(70);
                    break;
                default:
                    this.AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade) 
        {
            if (grade >= 0 && grade <= 100) 
            {
                grades.Add(grade);
            }
            else 
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Statistics GetStatistics() 
        {
            Statistics result = new Statistics();

            foreach (var grade in this.grades)
            {
                result.Add(grade);
            }

            return result;
        }
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            using (StreamWriter sw = File.AppendText($"{Name}.txt"))
            {
                sw.WriteLine(grade);
            }
        }

        public override Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            try
            {
                using (StreamReader sr = File.OpenText($"{Name}.txt"))
                {
                    String line = sr.ReadLine();
                    while ( line != null )
                    {
                        result.Add(Convert.ToDouble(line));
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
} 