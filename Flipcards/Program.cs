// Program.cs
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to C# Flashcards!");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey();

        // TODO: Create a game instance

        while (true)
        {
            // TODO: Implement menu system using ConsoleKeyInfo
            // Hint: Use Console.ReadKey() to capture keyboard input
            // Consider using switch statement for different keys
            // Example: 'A' - Add card, 'P' - Play game, 'Q' - Quit

            // TODO: Handle menu choices
            // Remember to use Console.Clear() for better UI
        }
    }
}

// TODO: Create Flashcard class
// Hints:
// - What properties would a flashcard need?
// - Should the properties be read-only or modifiable?
// - Consider adding a method to check if an answer is correct

// TODO: Create FlashcardGame class
// Hints:
// - How will you store the flashcards? (List, Array, Dictionary?)
// - What methods do you need for game functionality?
// - Consider these methods:
//   * AddCard()
//   * RemoveCard()
//   * ShuffleCards()
//   * PlayRound()
//   * GetScore()

// TODO: (Optional) Create a UI helper class
// Hints:
// - Methods for common console operations
// - Color coding for correct/incorrect answers
// - Clear screen and format text

/* Keyboard Controls to Implement:
 * ============================
 * A: Add new flashcard
 * P: Play game
 * S: Show all cards
 * D: Delete card
 * H: Show high score
 * Q: Quit game
 * ↑/↓: Navigate menu (optional)
 * Space: Confirm answer
 * Esc: Return to main menu
 */

/* Implementation Steps:
 * 1. Start with the Flashcard class - it's the foundation
 * 2. Create basic List<Flashcard> in FlashcardGame
 * 3. Implement simple console menu
 * 4. Add keyboard controls one by one
 * 5. Implement game logic
 * 6. Add extra features (scoring, shuffle, etc.)
 */

/* Suggested Data Structures:
 * ========================
 * - List<Flashcard> for card storage
 * - Dictionary<string, Action> for menu commands
 * - Queue<Flashcard> for play session
 */

/* Bonus Challenges:
 * ===============
 * - Add card categories
 * - Implement difficulty levels
 * - Add timer for answers
 * - Save/Load functionality
 * - Statistics tracking
 */