# SimpleMineSweeper
This is a basic mine sweeper implementation in C#

# Disclaimer 
This is a simple minesweeper game written for practice only. It has several limitations and is different from official minesweeper games. 
If you are looking for a perfect implementation of minesweeper that follows all official rules, then this is NOT the project.

# Background
I created a minesweeper game in Java for a school assignment almost ten years ago. The original game did not have a dynamic square generation logic.
Fast forward today, I decided I want to learn C# as a new year resolution and I can only think about the minesweeper game as a pet project.

# Programming Features Used
I tried to incorporate as many programming features as I can practically use from my new knowledge in C#. Below is a list of programming features that I included in this project.

- Dynamic List<> with custom class
- Enum
- Some exception handling (lol...you should always put a lot of exception handling)
- Use of IEnumerable with yielding for better memory management
- Dynamic form resize based on game size
- Linking custom objects to control tags
- Use of menu strip
- Form dialogue
- Linking event handlers to controls

# Inconsistencies
There are some features that I did not add due to time and also because I am too lazy to research all the rules:

- The game will generate mines that is around 18% of the total squares. I don't know what is the official formula for the number of mines to generate.
- The game does not have a score board.
- Some people say that the question mark feature is not part of the official mine sweeper game. This is where you can mark the square with a second right click to place a question mark. I just included it anyways.
- This game can run indefinitely on the timer. I did not put a rule to stop the game after a certain lenght of time.
- I don't generate the same amount of squares as the official MS minesweeper. I am not even sure if there are official grid sizes.
