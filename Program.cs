using System;
using System.IO;
using System.Reflection.Metadata;
using System.Collections;

public class TestProgram

{
    //Input from user for low number
    static int LowNumber()
    {
        Console.WriteLine("Enter low number");
        string input = Console.ReadLine();

        int lowNumber = Convert.ToInt32(input);
        return lowNumber;
    }
    //Validation loop for low number to be greater than 0
    static bool ValidateLowNumber(int lowNumber)
    {
        while (lowNumber < 0)
        {
            Console.WriteLine("Please enter a value greater than 0\n" +
                "Enter low number: ");
            string input = Console.ReadLine();

            lowNumber = Convert.ToInt32(input);
        }
        return true;
    }


    //User input, converting input to var
    static int HighNumber()
    {
        Console.WriteLine("Enter high number");
        string input = Console.ReadLine();

        int highNumber = Convert.ToInt32(input);
        return highNumber;
    }
    //validation loop for high number to be greater than low number

    static bool ValidateHighNumber(int highNumber, int lowNumber)
    {
        while (highNumber < lowNumber)
        {
            Console.WriteLine("Please enter a value greater than " + lowNumber +
                "\nEnter high number: ");
            string input = Console.ReadLine();

            highNumber = Convert.ToInt32(input);
        }
        return true;
    }
    //Method to check for prime number
    static bool PrimeNumberCheck(double number)
    {
        double a = 0;


        for (int i = 1; i < number; i++) 
        {
            //if number is prime modulus operator will return 0 and increase counter
            if (number % i == 0)
            {
                a++;
            }
        }

        //if counter is 1 then number is prime
        if (a == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void Main()
    {
        //asking for input and validation
        int lowNumber = LowNumber();
        ValidateLowNumber(lowNumber);

        //assking for input and validation
        int highNumber = HighNumber();
        ValidateHighNumber(highNumber, lowNumber);

        //variable for display
        int sumOfLowAndHigh = lowNumber + highNumber;   

        Console.WriteLine(lowNumber + " + " + highNumber + " = " + (sumOfLowAndHigh));

        //Create array for numbers between inputted values
        int[] numberBetween = new int[highNumber - lowNumber - 1];

        //For loop to add values to array
        for (int i = 0; i < numberBetween.Length; i++)
        { 
            numberBetween[i] = lowNumber++ + 1; 
        }

        //variable created for file location
        string path = "C:\\Users\\Jedi4\\source\\repos\\Program\\Program\\numbers.txt";

        //Create file and add all numbers between low and high
        File.Create(path).Close();
        for (int i = 0; i < numberBetween.Length; i++)
        {
            string x = numberBetween[^(i + 1)].ToString() + ",";
            File.AppendAllText(path, x);
        }

        //reads and stores numbers in file as string variable
        string data = File.ReadAllText(path);
        string[] dataSplit = data.Split(',');

        //list to store numbers from file
        List<double> dataNumbers = new List<double>();

        //adds numbers from file to double list
        for (int i = 0; i < dataSplit.Length - 1; i++)
        {
            //Console.Write(i + "=" +dataSplit[i] + "\n");
            dataNumbers.Add(double.Parse(dataSplit[i]));
            
        }

       
        Console.WriteLine("The Sum of the numbers.txt file is " + dataNumbers.Sum());

        //iterates through numbers to check if prime number
        for (int i = 0; i < dataNumbers.Count; i++) 
        {
            if (PrimeNumberCheck(dataNumbers[i]) == true)
            {
                Console.WriteLine(dataNumbers[i] + " is a prime number");
            
            }
        }

    }


}