# CardGame
Memory Game playable on the console
# Intructions for running
Download the runtime file in the CardGame/CardGame/bin/Release/netcoreapp2.1, choosing between Windows or Ubuntu, and find the correct runtime file (example: .exe for Windows). 
# Design Choices
For this card game, I made a a Card class, a Board class, and a Card Types enumerator. 
## Card Class 
The Card class consists of a card object with a card type and whether or not it is enabled. 
### Methods
The Card class has a method that prints the card with the type if enabled and an X if not enabled. 
## Board Class
The Board class consists of a board object with a Card array that holds all of the cards in the board. A Board object is initialized with 16 random cards, each card having a duplicate.  
### Methods
The Board class has a method to print the board using the string represenations of the card. It then has a show card method that flips over the card if the card has not been flipped over. The user will input a row and a column to reveal the card, so there is a calculate card method to take the row and column in and use it to calculate the index in the card array. There is a find duplicate array, which is the main functionality of the game. It prompts the player to input a row and column to reveal the card, and then prompts the user to guess the location of a duplicate. If a duplicate is found, both cards stay revealed. Otherwise, they are turned over. The method makes sure that the user inputs a valid row and column. There is an endgame method that checks if every card is enabled, and returns true if so, and false if not.
## Card Types Enumerator
The Card Types enumerator allows for a standardization of the card types, which is every letter from A to H. 
