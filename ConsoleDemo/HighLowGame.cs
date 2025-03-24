namespace ConsoleDemo
{
    /// <summary>
    /// Implements a number guessing game where the player tries to guess a number between 1 and 100.
    /// </summary>
    public class HighLowGame
    {
        private readonly Random _random;
        private int _numberToGuess;
        private int _attemptCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighLowGame"/> class.
        /// </summary>
        public HighLowGame()
        {
            _random = new Random();
        }

        /// <summary>
        /// Runs the High-Low guessing game, prompting the user for input until they guess correctly.
        /// </summary>
        public void Run()
        {
            try
            {
                InitializeGame();
                DisplayWelcomeMessage();
                PlayGameLoop();
            }
            catch (Exception ex)
            {
                HandleGameError(ex);
            }
        }

        /// <summary>
        /// Initializes the game state with a new random number.
        /// </summary>
        private void InitializeGame()
        {
            _numberToGuess = _random.Next(1, 101);
            _attemptCount = 0;
        }

        /// <summary>
        /// Displays the welcome message to the player.
        /// </summary>
        private void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the High-Low Guessing Game!");
            Console.WriteLine("I'm thinking of a number between 1 and 100. Can you guess what it is?");
        }

        /// <summary>
        /// Executes the main game loop until the player guesses correctly.
        /// </summary>
        private void PlayGameLoop()
        {
            int userGuess = 0;

            while (userGuess != _numberToGuess)
            {
                userGuess = GetUserGuess();
                if (userGuess != -1) // -1 indicates invalid input
                {
                    ProcessGuess(userGuess);
                }
            }
        }

        /// <summary>
        /// Gets a valid guess from the user.
        /// </summary>
        /// <returns>The user's guess, or -1 if input was invalid.</returns>
        private int GetUserGuess()
        {
            Console.Write("Enter your guess: ");
            if (int.TryParse(Console.ReadLine(), out int userGuess))
            {
                return userGuess;
            }

            Console.WriteLine("Please enter a valid number.");
            return -1;
        }

        /// <summary>
        /// Processes the user's guess and provides feedback.
        /// </summary>
        /// <param name="userGuess">The user's guess.</param>
        private void ProcessGuess(int userGuess)
        {
            _attemptCount++;

            if (userGuess < _numberToGuess)
            {
                Console.WriteLine("Higher!");
            }
            else if (userGuess > _numberToGuess)
            {
                Console.WriteLine("Lower!");
            }
            else
            {
                Console.WriteLine($"Congratulations! You guessed the number in {_attemptCount} attempts!");
            }
        }

        /// <summary>
        /// Handles any errors that occur during the game.
        /// </summary>
        /// <param name="ex">The exception that was thrown.</param>
        private void HandleGameError(Exception ex)
        {
            Console.WriteLine($"An error occurred while running the game: {ex.Message}");
        }
    }
}
