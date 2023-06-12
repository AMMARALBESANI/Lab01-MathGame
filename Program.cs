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

        // Function to initiate the game sequence
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

                // Display the array size, the numbers in the array, the sum, and the calculated results
                Console.WriteLine($"Your array is size: {size}");
                Console.WriteLine("The numbers in the array are: " + string.Join(",", numbers));
                Console.WriteLine("The sum of the array is: " + sum);
                Console.WriteLine($"{sum} * {product / sum} = {product}");
                Console.WriteLine($"{product} / {product / quotient} = {quotient}");
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

        // Function to populate an array with user-inputted numbers
        static int[] Populate(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Please enter number {i + 1} of {numbers.Length}: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            return numbers;
        }

        // Function to calculate the sum of an array
        static int GetSum(int[] numbers)
        {
            int sum = 0;

            // Iterate through each number in the array and calculate the sum
            foreach (int number in numbers)
            {
                sum += number;
            }

            // Check if the sum is too low (less than or equal to 20) and throw an exception if it is
            if (sum <= 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }

            return sum;
        }

        // Function to calculate the product of a randomly selected number from the array and the sum
        static int GetProduct(int[] numbers, int sum)
        {
            Console.WriteLine($"Please select a number between 1 and {numbers.Length}");
            int randomNumber = Int32.Parse(Console.ReadLine());

            // Check if the selected number is within the valid range and throw an exception if it is not
            if (randomNumber < 1 || randomNumber > numbers.Length)
            {
                throw new IndexOutOfRangeException("Invalid index selected");
            }

            // Calculate the product of the selected number and the sum
            int product = sum * numbers[randomNumber - 1];
            return product;
        }

        // Function to calculate the quotient of the product divided by a user-inputted number
        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Select a random number to divide {product} by:");
            decimal divider = Convert.ToDecimal(Console.ReadLine());

            try
            {
                // Divide the product by the divider and return the quotient
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
