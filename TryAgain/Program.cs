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
            const char rs = '\x1e';
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

                    if (newTask.Contains(rs))
                    {
                        task.Add(new Task(newTask, true));
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.ResetColor();
                    }
                    else
                    {
                        task.Add(new Task(newTask));
                    }
                }
            }
            //var task = new List<Task>();

            Console.WriteLine($"  { task.Count} tasks in your list");
            void PrintListAction()
            {

            }

            void PrintList()
            {
                for (int x = 0; x < task.Count; x++)
                {
                    if (!task[x].Complete)
                    {
                        for (int i = x; i < task.Count; i++)
                        {
                           
                            if (task[i].Complete)
                            {

                                string str;
                                str = $"\n  {i + 1}. {task[i].Details}";
                                str = str.Substring(0, str.Length - 1);
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine(str);
                                Console.ResetColor();
                                x = task.Count + 1;
                            }
                            else
                            {
                                Console.WriteLine($"\n  {i + 1}. {task[i].Details}\n");
                                x = task.Count + 1;
                            }                            
                        }
                        
                    }
                    
                }
            }

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
                        PrintList();
                        Console.Write("\n\n  Menu = 0\n  or\n  Enter new task: \n\n  ");
                        string newTask = Console.ReadLine();

                        if (newTask == "0")
                        {
                            menu = true;
                            Console.Clear();
                        }
                        else
                        {
                            task.Add(new Task(newTask));
                        }



                    } while (!menu);

                }
                else if (input == "2")
                {
                    Console.Clear();
                    PrintList();
                    
                    //Console.WriteLine();



                }
                else if (input == "3")
                {
                    Console.Clear();
                    PrintList();

                    Console.Write("  Which one do you want to modify?\n\n  ");
                    var lin = Console.ReadLine();
                    var mod = int.Parse(lin);
                    if (mod <= task.Count)
                    {
                        //Console.Clear();
                        Console.WriteLine($"\n  1) MARK as complete.\n");
                        Console.WriteLine($"  2) DELETE\n");
                        Console.Write($"  3) Return to Main Menu\n\n  ");
                        int del = int.Parse(Console.ReadLine());
                        if (del == 1)
                        {
                            task[mod - 1].Complete = true;
                            task[mod - 1].Details += rs;
                        }
                        else if (del == 2)
                        {
                            Console.Clear();
                            task.RemoveAt(mod - 1);
                        }
                        else if (del == 3)
                        {                           
                            Console.WriteLine("\n  Return to Main Menu:  ");
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("\n  Invalid input! ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n  Invalid input! ");
                    }

  
                    
                    //string Replace(string oldValue, string newValue);
                    //task.
                    //for (int i = 1; i < mod; i++)
                    //{
                    //    Console.WriteLine(task[mod].Details);
                    //}



                    //using (StreamReader reader = new StreamReader(path))
                    //{
                    //    for (int i = 1; i <= mod; ++i)
                    //        lin = reader.ReadLine();
                    //}
                    //int line_number = 1;
                    //string line = null;

                    ////string linetoWrite = null;
                    //using (StreamReader reader = new StreamReader(path))
                    //using (StreamWriter writer = new StreamWriter(tempFile))
                    //    while ((line = reader.ReadLine()) != null)
                    //    {
                    //        if (line_number == mod)
                    //        {
                    //            writer.WriteLine(lin);
                    //        }
                    //        else
                    //        {
                    //            writer.WriteLine(line);
                    //        }
                    //        line_number++;
                    //    }

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
