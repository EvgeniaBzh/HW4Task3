using System;
using System.Xml.Linq;

public class Converter
{
    private decimal usdToUah;
    private decimal eurToUah;

    public Converter(decimal usdToUah, decimal eurToUah)
    {
        this.usdToUah = usdToUah;
        this.eurToUah = eurToUah;
    }

    public decimal ConvertToUSD(decimal amountInUAH)
    {
        return amountInUAH / usdToUah;
    }

    public decimal ConvertToEuro(decimal amountInUAH)
    {
        return amountInUAH / eurToUah;
    }

    public decimal ConvertFromUSD(decimal amountInUSD)
    {
        return amountInUSD * usdToUah;
    }

    public decimal ConvertFromEuro(decimal amountInEuro)
    {
        return amountInEuro * eurToUah;
    }
}

class Program
{
    static void Main()
    {
        decimal usdToUah = 36.75m;
        decimal eurToUah = 38.56m;

        Converter converter = new Converter(usdToUah, eurToUah);

        while (true)
        {
            Console.WriteLine("Choose the operation :");
            Console.WriteLine("1. Convert from UAH to USD");
            Console.WriteLine("2. Convert from UAH to EUR");
            Console.WriteLine("3. Convert from USD to UAH");
            Console.WriteLine("4. Convert from EUR to UAH");
            Console.WriteLine("5. Exit");
            Console.Write("Your choise: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    decimal amountInUAH1;
                    do
                    {
                        Console.Write("Enter the amount in UAH: ");
                    } while (!decimal.TryParse(Console.ReadLine(), out amountInUAH1) || amountInUAH1 < 0);

                    decimal amountInUSD = converter.ConvertToUSD(amountInUAH1);
                    Console.WriteLine($"Conversion result: {amountInUAH1} UAH = {amountInUSD:F2} USD");
                    break;
                case "2":
                    decimal amountInUAH2;
                    do
                    {
                        Console.Write("Enter the amount in UAH: ");
                    } while (!decimal.TryParse(Console.ReadLine(), out amountInUAH2) || amountInUAH2 < 0);

                    decimal amountInEUR = converter.ConvertToEuro(amountInUAH2);
                    Console.WriteLine($"Conversion result: {amountInUAH2} UAH = {amountInEUR:F2} EUR");
                    break;
                case "3":
                    decimal amountInUSD2;
                    do
                    {
                        Console.Write("Enter the amount in USD: ");
                    } while (!decimal.TryParse(Console.ReadLine(), out amountInUSD2) || amountInUSD2 < 0);

                    decimal amountInUAH3 = converter.ConvertFromUSD(amountInUSD2);
                    Console.WriteLine($"Conversion result: {amountInUSD2} USD = {amountInUAH3:F2} UAH");
                    break;
                case "4":
                    decimal amountInEUR2;
                    do
                    {
                        Console.Write("Enter the amount in EUR: ");
                    } while (!decimal.TryParse(Console.ReadLine(), out amountInEUR2) || amountInEUR2 < 0);

                    decimal amountInUAH4 = converter.ConvertFromEuro(amountInEUR2);
                    Console.WriteLine($"Conversion result: {amountInEUR2} EUR = {amountInUAH4:F2} UAH");
                    break;
                case "5":
                    Environment.Exit(0); 
                    break;
                default:
                    Console.WriteLine("Read the instruction correctly and choose again.");
                    break;
            }
        }
    }
}