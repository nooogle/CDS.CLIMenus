namespace ConsoleDemo
{
    /// <summary>
    /// Generates and displays prime numbers.
    /// </summary>
    public class PrimeNumberGenerator
    {
        private const int DefaultCount = 10;

        /// <summary>
        /// Runs the prime number generator and displays the results.
        /// </summary>
        public void Run()
        {
            DisplayHeader();
            GenerateAndDisplayPrimes(DefaultCount);
        }

        /// <summary>
        /// Generates and displays the specified number of prime numbers.
        /// </summary>
        /// <param name="count">The number of prime numbers to generate.</param>
        public void GenerateAndDisplayPrimes(int count)
        {
            Console.WriteLine($"Generating {count} prime numbers...");

            int found = 0;
            int candidate = 2;

            while (found < count)
            {
                if (IsPrime(candidate))
                {
                    Console.WriteLine(candidate);
                    found++;
                }
                candidate++;
            }
        }

        /// <summary>
        /// Determines whether the specified number is prime.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is prime; otherwise, false.</returns>
        private bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Displays the header for the prime number generator.
        /// </summary>
        private void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine("Prime Number Generator");
            Console.WriteLine("=====================");
        }
    }
}
