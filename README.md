# Monopoly Esilv version
## Introduction
For this project I have to create a kind of Monopoly game where I must use some Design Pattern. In my version, I use a majority of the real Monopolys's rules.

## Game board

<img src='Monopoly/monopolyfinal.jpg' width=300 height=300 >

For my version I use this game board. As you can see there is some empty case which are nothing case in this version. More over, there isn't the system of Chance and Community Chest cards. But I keep the begin case, the jail case, the tax cases, the go to jail case, the fields, the companies and the railroads.

## The game
In my version, there is only 2 or 3 players, the name of each one is asked. At the begining, they start at the begin case with 1500 for the capital, the status jail to false and the status bankruptcy to false.
It's a turn by turn, where the first player who start is the player who input his name at first.
During a turn, the player rolls 2 dices of 6 faces and sum them to move. If he gets a double, he rolls again. If he gets double three time he goes to jail. After the move, he is on a case. There is the activation of the effect of this case, which depend of the type of it. Indeed, if it's a field or special field type, he can purchase the case if the owner is still the bank. Otherwise, he has to pay rent to the owner. For the case type it's different. Because for some of them there is nothing like the nothing case, and for other the effect are good or bad for the player. If he arrives on a tax case, he has to pay. If he arrives on the case jail, there is nothing. If he arrives on the case go to jail case, he has to go to the case jail and his jail mode changes to true. If the player makes a loop he receives 200.
After the effect of the case, the player gets a menu where he can choose some effect like sell the property where he is, show his status, his properties, the board, end his turn or abondonned the game. The players cannot exchange with the others the purchased cards.
A player who has a capital < 0 goes to bankruptcy. That means that he loses the game. The game finishs when there is only one player with the status bankruptcy equals to false.
On the contrary to the real Monopoly, a player can't build. But the rules for the fields, the companies and the railroads are keeped.


