using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocean_Nevigation.BL;

namespace Ocean_Nevigation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ship> shipList = new List<ship>();
            string op = " ";
            while (true)
            {
                op = mainMenu();
                Console.Clear();
                if (op == "1")
                {
                    menu();
                    Console.Write("Enter the ship serial number: ");
                    string serialNumber = Console.ReadLine();
                    shipList.Add(takeInput(serialNumber));
                }
                else if(op == "2")
                {
                    Console.Write("Enter Ship Serial Number to find its position : ");
                    string serial = Console.ReadLine();
                    shipPosition(serial , shipList);
                    menu();
                }
                else if(op == "3")
                {
                    menu();
                    ship temp = takeInput(" ");
                    Console.WriteLine("Ship serial number : " + shipSerialNumber(shipList , temp));
                }
                else if(op == "4")
                {
                    menu();
                    Console.Write("Enter the ship serial number: ");
                    string serialNumber = Console.ReadLine();
                    ship temp = takeInput(serialNumber);
                    if (changePosition(temp, shipList))
                    {
                        Console.WriteLine("Ship position changed successfully");
                    }
                    else
                    {
                        Console.WriteLine("Enter valid serial number");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if(op == "5")
                {
                    menu();
                    Console.Write("Enter the ship serial number: ");
                    string serialNumber = Console.ReadLine();
                    int idx = shipSerialNumberIdx(shipList, serialNumber);
                    if(idx != -1)
                    {
                        shipList.RemoveAt(idx);
                        Console.WriteLine("Ship removed successfully");
                    }
                    else
                    {
                        Console.WriteLine("Enter valid serial number");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if(op == "6")
                {
                    Console.WriteLine("Thank you for using our program...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                Console.Clear();
            }   
        }
        static void menu()
        {
            Console.WriteLine("******************************************");
            Console.WriteLine("*        Ocean Navigation System         *");
            Console.WriteLine("******************************************");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
        static string mainMenu()
        {
            string op = " ";
            Console.WriteLine("******************************************");
            Console.WriteLine("*        Ocean Navigation System         *");
            Console.WriteLine("******************************************");
            Console.WriteLine("* 1. Add a new ship to the system        *");
            Console.WriteLine("* 2. View ship position                  *");
            Console.WriteLine("* 3. View Ship Serial Number             *");
            Console.WriteLine("* 4. Change Ship Position                *");
            Console.WriteLine("* 5. Remove Ship                         *");
            Console.WriteLine("* 6. Exit                                *");
            Console.WriteLine("******************************************");
            Console.Write("Enter your choice: ");
            op = Console.ReadLine();
            return op;
        }
        static ship takeInput(string serialNumber)
        {
            Console.WriteLine("Enter ship Latitude : ");
            Console.Write("Enter Latitude Degree: ");
            int latDegree = takeIntInput(Console.ReadLine());
            Console.WriteLine("Enter Latitude Minute: ");
            float latMinute = getFloatInput();
            Console.WriteLine("Enter Latitude Direction: ");
            char latDirection = inputCorrectDirections();
            Console.WriteLine("Enter ship Longitude : ");
            Console.Write("Enter Longitude Degree: ");
            int longDegree = takeIntInput(Console.ReadLine());
            Console.WriteLine("Enter Longitude Minute: ");
            float longMinute = getFloatInput();
            Console.WriteLine("Enter Longitude Direction: ");
            char longDirection = inputCorrectDirections();
            ship temp = new ship(serialNumber, latDegree, latMinute, latDirection, longDegree, longMinute, longDirection);
            return temp;
        }
        static void shipPosition(string serialNumber , List<ship> shipList)
        {
            for (int i = 0; i < shipList.Count; i++)
            {
                if (shipList[i].shipNumber == serialNumber)
                {
                    Console.WriteLine("Ship is at " + shipList[i].latitudeDegree + "\u00b0" + shipList[i].latitudeMinute + "'" + shipList[i].latitudeDirection + " and " + shipList[i].longitudeDegree + "\u00b0" + shipList[i].longitudeMinute + "'" + shipList[i].longitudeDirection);
                    //"°"
                }
            }
        }
        static bool changePosition(ship temp , List<ship> shipsList)
        {
            for (int i = 0; i < shipsList.Count; i++)
            {
                if (shipsList[i].shipNumber == temp.shipNumber)
                {
                    shipsList[i].copy(temp);
                    return true;
                }
            }
            return false;
        }
        static string shipSerialNumber(List<ship> shipList , ship temp)
        {
            string serialNumber = " ";
            for (int i = 0; i < shipList.Count; i++)
            {
                if (shipList[i].compare(temp) == true)
                {
                    serialNumber = shipList[i].shipNumber;
                    break;
                }
            }
            return serialNumber;
        }
        static int shipSerialNumberIdx(List<ship> shipList, string serialNumber)
        {
            int idx = -1;
            for (int i = 0; i < shipList.Count; i++)
            {
                if (shipList[i].shipNumber == serialNumber)
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }
        static float getFloatInput()
        {
            float input = 0;
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Enter a number: ");
                string inputString = Console.ReadLine();
                if (float.TryParse(inputString, out input))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return input;
        }
        static bool isNumber(string line)
        {
            bool flag = true;

            for (int i = 0; i < line.Length; i++)
            {
                if (!(line[i] >= 48 && line[i] <= 57))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        static int takeIntInput(string line)
        {
            int num = 0;
            while (true)
            {
                if (isNumber(line))
                {
                    num = int.Parse(line);
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid number");
                    line = Console.ReadLine();
                }
            }
            return num;
        }
        static char inputCorrectDirections()
        {
            char temp = ' ';
            while (true)
            {
                Console.Write("Enter a direction: ");
                temp = char.Parse(Console.ReadLine());
                if (temp == 'N' || temp == 'S' || temp == 'E' || temp == 'W')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            return temp;
        }
    }
}
