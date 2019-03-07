using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TryAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = false;
            var path = @"C:\Users\Joel.Crunk\source\repos\TryAgain\TryAgain\Testingfile.txt";
            //var task = new List<string>();
            bool EXIT = false;
            List<Task> task = new List<Task>();
            //string path = @"C:\Users\Joel.Crunk\source\repos\TaskTrackingAppVersion2.0\TaskTrackingAppVersion2.0\TaskList1.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                //string line;
                //    // Read and display lines from the file until the end of 
                //    // the file is reached.
                while (!sr.EndOfStream)
                {
                    string newTask = sr.ReadLine();
                    task.Add(new Task(newTask));
                }
            }
            //var task = new List<Task>();

            Console.WriteLine($"  { task.Count} tasks in your list");

            do
            {
                Console.WriteLine(" \n  MAKE A SELECTION: \n\n");
                Console.WriteLine("  Select 0. to EXIT.");
                Console.WriteLine("  Select 1. to ENTER.");
                Console.WriteLine("  Select 2. to VIEW.");
                Console.Write("  Select 3. to MODIFY.\n\n  ");


                string input = Console.ReadLine();


                if (input == "0")
                {
                    EXIT = true;
                }
                else if (input == "1")
                {
                    do
                    {




                        Console.Clear();
                        Console.Write("\n\n  Menu = 0\n  or\n  Enter new task: \n\n  ");
                        string newTask = Console.ReadLine();
                        if (newTask == "0")
                        {
                            menu = true;
                        }
                        else
                        {
                            task.Add(new Task(newTask));
                        }



                    } while (!menu);

                }
                else if (input == "2")
                {
                    //Console.Clear();
                    for (int i = 0; i < task.Count; i++)
                    {
                        Console.WriteLine($"\n  {i + 1}. {task[i].Details}\n");

                    }
                    //Console.WriteLine();



                }
                else if (input == "3")
                {
                    for (int i = 0; i < task.Count; i++)
                    {
                        Console.WriteLine($"\n  {i + 1}. {task[i].Details}\n");
                      
                    }
                    Console.WriteLine("  Which one do you want to modify?  ");
                    var mod = int.Parse(Console.ReadLine());

                    //task.FindIndex(mod < Task > string input);
                    //Console.WriteLine(task.);
                    task.RemoveAt(mod -1);
                    //string Replace(string oldValue, string newValue);
                    //task.
                    //for (int i = 1; i < mod; i++)
                    //{
                    //    Console.WriteLine(task[mod].Details);
                    //}


                }
               


            } while (!EXIT);

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var newTask in task )
                {
                    sw.WriteLine( newTask.Details);

                }
            }

            // File.WriteAllLines(path, task.ToArray());
        }
    }
}
