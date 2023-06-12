namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("The program is completed");
            }
        }

        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Enter a number greater than zero");
                int size = Convert.ToInt32(Console.ReadLine());
                if (size < 1)
                {
                    throw new Exception("Invalid size selected");
                }
                int[] numbers = new int[size];

                numbers = Populate(numbers);
                int sum = GetSum(numbers);
                int product = GetProduct(numbers, sum);
                decimal quotient = GetQuotient(product);
                Console.WriteLine($"Your array is size: {size}");
                Console.WriteLine("The numbers in the array are: " + string.Join(",", numbers));
                Console.WriteLine("The sum of the array is: " + sum);
                Console.WriteLine($"{sum} * {product / sum} = {product}");
                Console.WriteLine($"{product} / {product / quotient} = { quotient}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static int[] Populate(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Please enter number {i + 1} of {numbers.Length}: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            return numbers;
        }

        static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            if (sum <= 20)
            {
                Console.WriteLine($"Value of {sum} is too low");
            }

            return sum;
        }

        static int GetProduct(int[] numbers, int sum)
        {
            Console.WriteLine($"Please select a number between 1 and {numbers.Length}");
            int randomNumber = Int32.Parse(Console.ReadLine());

            if (randomNumber < 1 || randomNumber > numbers.Length)
            {
                throw new IndexOutOfRangeException("Invalid index selected");
            }

            int product = sum * numbers[randomNumber - 1];
            return product;
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Select a random number to divide {product} by:");
            decimal divider = Convert.ToDecimal(Console.ReadLine());

            try
            {
                decimal quotient = decimal.Divide(product, divider);
                return quotient;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("DivideByZeroException is not allowed");
                return 0;
            }
        }
    }
}