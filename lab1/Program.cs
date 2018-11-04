using System;
using System.Data.SqlClient;
using SqlServerEFSample.repository;

namespace SqlServerEFSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Starting...");
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";
                builder.UserID = "sa";
                builder.Password = "yourStrong(!)Password";
                builder.InitialCatalog = "EFSampleDB";
                using (EFSampleContext context = new EFSampleContext(builder.ConnectionString))
                {
                    Console.WriteLine("Clean database schema");
                    context.Database.EnsureDeleted();
                    Console.WriteLine("Create database schema");
                    context.Database.EnsureCreated();
                    var universityRepository = new UniversityRepository(context);
                    var departmentRepository = new DepartmentRepository(context);
                    var teacherRepository = new TeacherRepository(context);
                    printMenu();
                    var input = "";
                    var previousInput = "";
                    var menuStarted = false;
                    while (!(input = Console.ReadLine()).Equals("4"))
                    {
                        var validInput = false;
                        try
                        {
                            if (input.Equals("1") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter University 'name' -> someName");
                            }
                            else if (input.Equals("1.1") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter University 'id' and new 'name' -> 1:newName");
                            }
                            else if (input.Equals("1.2") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter University 'id' -> 1");
                            }
                            else if (input.Equals("1.3") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter University 'name' -> someName");
                            }
                            else if (input.Equals("1.4"))
                            {
                                validInput = true;
                                Console.WriteLine("Found Universities : " +
                                                  ListUtils.listToString(universityRepository.findAll()));
                                printMenu();
                            }
                            else if (input.Equals("1.5") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter University 'id' -> 1");
                            }
                            else if (input.Equals("2") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter Department 'name' and University 'id' -> newName:1");
                            }
                            else if (input.Equals("2.1") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter Department 'id' and new 'name' -> 1:newName");
                            }
                            else if (input.Equals("2.2") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter Department 'id' -> 1");
                            }
                            else if (input.Equals("2.3") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter Department 'name' -> someName");
                            }
                            else if (input.Equals("2.4"))
                            {
                                validInput = true;
                                Console.WriteLine("Found Departments : " +
                                                  ListUtils.listToString(departmentRepository.findAll()));
                                printMenu();
                            }
                            else if (input.Equals("2.5") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter Department 'id' -> 1");
                            }
                            else if (input.Equals("3") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter Teacher 'name' and Department 'id' -> newName:1");
                            }
                            else if (input.Equals("3.1") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter Teacher 'id' and new 'name' -> 1:newName");
                            }
                            else if (input.Equals("3.2") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter Teacher 'id' -> 1");
                            }
                            else if (input.Equals("3.3") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter Teacher 'name' -> someName");
                            }
                            else if (input.Equals("3.4"))
                            {
                                validInput = true;
                                Console.WriteLine("Found Teachers : " +
                                                  ListUtils.listToString(teacherRepository.findAll()));
                                printMenu();
                            }
                            else if (input.Equals("3.5") && !menuStarted)
                            {
                                validInput = true;
                                menuStarted = true;
                                Console.WriteLine("Enter Teacher 'id' -> 1");
                            }

                            if (menuStarted)
                            {
                                previousInput = input;
                                input = Console.ReadLine();
                            }

                            if (previousInput.Equals("1") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                universityRepository.save(new University(input));
                                Console.WriteLine("University saved");
                                printMenu();
                            }
                            else if (previousInput.Equals("1.1") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                var idByName = input.Split(":");
                                universityRepository.update(int.Parse(idByName[0]), new University(idByName[1]));
                                Console.WriteLine("University updated");
                                printMenu();
                            }
                            else if (previousInput.Equals("1.2") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                Console.WriteLine(
                                    "Found University: " + universityRepository.findById(int.Parse(input)));
                                printMenu();
                            }
                            else if (previousInput.Equals("1.3") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                Console.WriteLine("Found University: " +
                                                  universityRepository.findByName(input));
                                printMenu();
                            }
                            else if (previousInput.Equals("1.5") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                universityRepository.delete(int.Parse(input));
                                Console.WriteLine("University deleted");
                                printMenu();
                            }
                            else if (previousInput.Equals("2") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                var idByName = input.Split(":");
                                var university = universityRepository.findById(int.Parse(idByName[1]));
                                departmentRepository.save(new Department(idByName[0], university));
                                Console.WriteLine("University saved");
                                printMenu();
                            }
                            else if (previousInput.Equals("2.1") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                var idByName = input.Split(":");
                                departmentRepository.update(int.Parse(idByName[0]), new Department(idByName[1], null));
                                Console.WriteLine("Department updated");
                                printMenu();
                            }
                            else if (previousInput.Equals("2.2") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                Console.WriteLine(
                                    "Found Department: " + departmentRepository.findById(int.Parse(input)));
                                printMenu();
                            }
                            else if (previousInput.Equals("2.3") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                Console.WriteLine("Found Department: " +
                                                  departmentRepository.findbyName(input));
                                printMenu();
                            }
                            else if (previousInput.Equals("2.5") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                departmentRepository.delete(int.Parse(input));
                                Console.WriteLine("Department deleted");
                                printMenu();
                            }
                            else if (previousInput.Equals("3") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                var idByName = input.Split(":");
                                var department = departmentRepository.findById(int.Parse(idByName[1]));
                                teacherRepository.save(new Teacher(idByName[0], department));
                                Console.WriteLine("Teacher saved");
                                printMenu();
                            }
                            else if (previousInput.Equals("3.1") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                var idByName = input.Split(":");
                                teacherRepository.update(int.Parse(idByName[0]), new Teacher(idByName[1], null));
                                Console.WriteLine("Teacher updated");
                                printMenu();
                            }
                            else if (previousInput.Equals("3.2") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                Console.WriteLine("Found Teacher: " + teacherRepository.finById(int.Parse(input)));
                                printMenu();
                            }
                            else if (previousInput.Equals("3.3") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                Console.WriteLine("Found Teacher: " + teacherRepository.findByName(input));
                                printMenu();
                            }
                            else if (previousInput.Equals("3.5") && menuStarted)
                            {
                                validInput = true;
                                menuStarted = false;
                                teacherRepository.delete(int.Parse(input));
                                Console.WriteLine("Teacher deleted");
                                printMenu();
                            }

                            if (!validInput)
                            {
                                menuStarted = false;
                                Console.WriteLine("Unsupported operation: " + input);
                                printMenu();
                            }
                        }
                        catch (Exception e)
                        {
                            menuStarted = false;
                            Console.WriteLine("Something wrong : \n" + e);
                            printMenu();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void printMenu()
        {
            Console.WriteLine("\n1 Create University\n" +
                              "1.1 Update University\n" +
                              "1.2 Find University by id\n" +
                              "1.3 Find University by name\n" +
                              "1.4 Find All Universities\n" +
                              "1.5 Delete University by id\n" +
                              "2 Create Department in University\n" +
                              "2.1 Update Department\n" +
                              "2.2 Find Department by id\n" +
                              "2.3 Find Department by name\n" +
                              "2.4 Find All Departments\n" +
                              "2.5 Delete Department by id\n" +
                              "3 Create Teacher in Department\n" +
                              "3.1 Update Teacher\n" +
                              "3.2 Find Teacher by id\n" +
                              "3.3 Find Teacher by name\n" +
                              "3.4 Find All Teachers\n" +
                              "3.5 Delete Teacher by id\n" +
                              "4 Exit\n");
        }
    }
}
