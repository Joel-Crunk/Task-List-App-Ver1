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
            bool EXIT = false;
            List<Task> task = new List<Task>();
            using (StreamReader sr = new StreamReader(path))
            {
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
            Console.WriteLine($"  { task.Count} tasks in your list");

            void displayPage(int current = 1)
            {
                int lowerLimit = 25 * (current - 1);
                int upperLimit = ((lowerLimit + 25) > task.Count) ? task.Count : lowerLimit + 25;

                for (int i = lowerLimit; i < upperLimit; i++)
                {
                    if (task[i].Complete)
                    {
                        string str = $"\n  {i + 1}. {task[i].Details}";
                        str = str.Substring(0, str.Length - 1);

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(str);
                        Console.ResetColor();
                      
                    }
                    else 
                    {
                        Console.Write($"\n  {i + 1}. {task[i].Details}\n");
                      
                    }
                }
            }

            void PrintList()
            {
                
                int currentPage = 1;
                int numPages = (int) Math.Ceiling(task.Count / 25.0);

                if (numPages <= 1)
                {
                    displayPage();
                }
                else
                {
                    do
                    {
                        displayPage(currentPage);
                        //display page nav menu
                        Console.Write($"\n  0) EXIT\n  1) NEXT PAGE\n  ");
                        int pageMenu = int.Parse(Console.ReadLine());
                        if (pageMenu == 1)
                        {
                            currentPage++;
                            if(currentPage > numPages)
                            {
                                currentPage = 1;
                            }
                        }
                        else if (pageMenu == 0)
                        {
                            break;
                        }
                    } while (true);
                   
                }

                //for (int x = 0; x < task.Count; x++)
                //{
                //    counter++;
                    
                    
                //    if (!task[x].Complete)
                //    {
                //        int co = 0;
                //         co = counter + 24;
                //        for (int i = x; i < co; i++)
                //        {
                //            if (task[i].Complete)
                //            {
                //                string str;
                //                str = $"  {i + 1}. {task[i].Details}";
                //                str = str.Substring(0, str.Length - 1);
                //                Console.ForegroundColor = ConsoleColor.DarkGray;
                //                Console.WriteLine(str);
                //                Console.ResetColor();
                //                x = task.Count;
                //            }
                //            else if (!task[i].Complete)
                //            {
                //                Console.WriteLine($"\n  {i + 1}. {task[i].Details}\n");
                //                x = task.Count;
                //            }                            
                //        }
                //        int z = 0;
                //        z = counter + 49;
                //        Console.Write($"  0) EXIT\n  1) NEXT PAGE\n  ");
                //        int put = int.Parse(Console.ReadLine());
                //        if (put == 1)
                //        {
                           
                //            for (int i = co; i < z; i++)
                //            {
                //                if (task[i].Complete)
                //                {
                //                    string str;
                //                    str = $"\n  {i + 1}. {task[i].Details}";
                //                    str = str.Substring(0, str.Length - 1);
                //                    Console.ForegroundColor = ConsoleColor.DarkGray;
                //                    Console.WriteLine(str);
                //                    Console.ResetColor();  
                //                }
                //                else
                //                {
                //                    Console.WriteLine($"\n  {i + 1}. {task[i].Details}\n");      
                //                }
                //            }
                            
                //        }
                            /*
                            int aa = z + 25;
                            for (int i = z; i < aa; i++)
                            {
                                if (task[z].Complete)
                                {
                                    string str;
                                    str = $"\n  {z + 1}. {task[z].Details}";
                                    str = str.Substring(0, str.Length - 1);
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine(str);
                                    Console.ResetColor();                                  
                                }
                                else
                                {
                                    Console.WriteLine($"\n  {z + 1}. {task[z].Details}\n");                                 
                                }
                            }
                            int bb = aa + 25;
                            for (int i = aa; i < bb; i++)
                            {
                                if (task[aa].Complete)
                                {
                                    string str;
                                    str = $"\n  {aa + 1}. {task[aa].Details}";
                                    str = str.Substring(0, str.Length - 1);
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine(str);
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine($"\n  {aa + 1}. {task[aa].Details}\n");
                                }
                            }
                            */
                        //}
                        //  /  
                    //}
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
                        menu = false;
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
                }               
            } while (!EXIT);

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var newTask in task )
                {
                    sw.WriteLine( newTask.Details);
                }
            }
        }
    }
}
