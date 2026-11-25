using System;

class Program
{
    static void Main()
    {
        // ===================== Q1 =====================
        // Create a one-dimensional array double[] prices with the values 25.5, 40.0, 33.75.
        // Print the second price (index 1).
        {
            double[] prices = { 25.5, 40.0, 33.75 };
            Console.WriteLine(prices[1]);   // 40
        }

        // ===================== Q2 =====================
        // Create a 2x2 multidimensional array int[,] shelfCopies where shelf 0 has 3, 5 copies
        // and shelf 1 has 1, 4 copies. Print the number of copies on shelf 1, slot 0.
        {
            int[,] shelfCopies = { { 3, 5 }, { 1, 4 } };
            Console.WriteLine(shelfCopies[1, 0]);   // 1
        }

        // ===================== Q3 =====================
        // Write a method called PrintWelcomeMessage that takes no parameters and prints
        // "Welcome to the Library!". Call it from Main.
        PrintWelcomeMessage();

        // ===================== Q4 =====================
        // Write a method PrintBookTitle(string title) that prints "Book title: " + title.
        // Call it with "Clean Code".
        PrintBookTitle("Clean Code");

        // ===================== Q5 =====================
        // Write a method AddBonusPages(int pages) that adds 50 to pages.
        // Call it with a variable int pages = 400; and print pages afterward.
        // What do you expect to see, and why?
        {
            int pages = 400;
            AddBonusPages(pages);
            Console.WriteLine(pages);   // 400
            // Why: int is a value type, so the method receives a COPY of pages.
            // The +50 changes the copy only, the original variable stays 400.
        }

        // ===================== Q6 =====================
        // Write a method ApplyDiscount(double[] prices) that subtracts 5 from prices[0].
        // Call it with double[] prices = { 25.5, 40.0 }; and print prices[0] afterward.
        // What do you expect to see, and why?
        {
            double[] prices = { 25.5, 40.0 };
            ApplyDiscount(prices);
            Console.WriteLine(prices[0]);   // 20.5
            // Why: an array is a reference type. The method receives a copy of the REFERENCE,
            // but it still points to the same array in memory, so changing prices[0]
            // inside the method changes the original array.
        }

        // ===================== Q7 =====================
        // Rewrite the method from question 5 as AddBonusPagesByRef(ref int pages) using ref.
        // Call it and print pages afterward. How is the result different from question 5?
        {
            int pages = 400;
            AddBonusPagesByRef(ref pages);
            Console.WriteLine(pages);   // 450
            // Difference: with ref, the method works on the ORIGINAL variable (not a copy),
            // so the change is visible outside: 450 here vs 400 in Q5.
        }

        // ===================== Q8 =====================
        // Write a method ReplaceArray(ref double[] prices) that replaces prices entirely with
        // a new array { 10.0, 12.5, 15.0 }. Call it with your prices array and print
        // prices.Length afterward.
        {
            double[] prices = { 25.5, 40.0 };      // length 2 before the call
            ReplaceArray(ref prices);
            Console.WriteLine(prices.Length);      // 3 (the variable now points to the new array)
        }

        // ===================== Q9 =====================
        // Write a method bool TryGetPrice(string title, out double price) that returns true and
        // sets price to 25.5 if title is "Clean Code", otherwise returns false and sets price to 0.
        // Call it once and print the price if found.
        {
            if (TryGetPrice("Clean Code", out double price))
            {
                Console.WriteLine(price);   // 25.5
            }
        }

        // ===================== Q10 =====================
        // Write a method PrintBookInfo(string title, int pages = 300) where pages is optional.
        // Call it once with only a title, and once passing both a title and pages.
        PrintBookInfo("Clean Code");          // pages = 300 (default)
        PrintBookInfo("Clean Code", 464);     // pages = 464

        // ===================== Q11 =====================
        // Using the PrintBookInfo method from the question above, call it by naming the
        // parameters, passing pages before title.
        PrintBookInfo(pages: 464, title: "Clean Code");

        // ===================== Q12 =====================
        // Write a method PrintAllTitles(params string[] titles) that prints each title on its
        // own line. Call it with three book titles.
        PrintAllTitles("Clean Code", "The Pragmatic Programmer", "Refactoring");
    }

    // Q3
    static void PrintWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Library!");
    }

    // Q4
    static void PrintBookTitle(string title)
    {
        Console.WriteLine("Book title: " + title);
    }

    // Q5
    static void AddBonusPages(int pages)
    {
        pages += 50;
    }

    // Q6
    static void ApplyDiscount(double[] prices)
    {
        prices[0] -= 5;
    }

    // Q7
    static void AddBonusPagesByRef(ref int pages)
    {
        pages += 50;
    }

    // Q8
    static void ReplaceArray(ref double[] prices)
    {
        prices = new double[] { 10.0, 12.5, 15.0 };
    }

    // Q9
    static bool TryGetPrice(string title, out double price)
    {
        if (title == "Clean Code")
        {
            price = 25.5;
            return true;
        }
        price = 0;
        return false;
    }

    // Q10 and Q11
    static void PrintBookInfo(string title, int pages = 300)
    {
        Console.WriteLine($"Title: {title}, Pages: {pages}");
    }

    // Q12
    static void PrintAllTitles(params string[] titles)
    {
        foreach (string t in titles)
        {
            Console.WriteLine(t);
        }
    }
}
