# Relatório do 2º Projeto de LP1

 Realizado por:
- Vitor Daniel, 22204782
- João Carvalho, 22204909
- João Sá Marques, 22209640

------------

# Tragic: The Reckoning

## Summary:
In the style magic: the gathering, game consists of 1v1 duel where each player 
has a deck of cards to reduce the oponent's life


1. Health points(HP) - Represents the player's life
2. Mana ponts(MP) - Resource utilized to play cards
3. Deck of cards - each player starts with a deck of 20 cards, each one has the 
4. following characteristics:
   - Name: the name of the card
   - Cost(C): Necessary MP to play the card
   - Attack Points(AP): attack value that deals damage to the enemy card's DP
   -  Value or Player's HP if used on them.
   - Defense Points(DP): Defense value that corresponds to the card's "health" 
   - before it's destroyed

Each player starts the start with 20 cards with the following characteristics:
Name / C / AP / DP / Quantity

    Flying Wand / 1 / 1 / 1 / 4

    Severed Monkey Head / 1 / 2 / 1 / 4

    Mystical Rock Head / 2 / 0 / 5 / 2

    Lobster MCCrabs / 2 / 1 / 3 / 2

    Goblin Troll / 3 / 3 / 2 / 2

    Scorching Heatwave / 4 / 5 / 3 / 1

    Blind Minotaurs / 3 / 1 / 3 / 1

    Tim, The Wizard / 5 / 6 / 4 / 1

    Sharply Dressed / 4 / 3 / 3 / 1

    Blue Steel / 2 / 2 / 2 / 2

## Start:
Each player starts with:
- 10 hp, 0 MP, deck of 20 cards as indicated before, each card is randomly 
- given, takes 6 cards each turn and at turn 0

Each turn:
- on the turns 1 to 4, MP is equal to 1 to 4 respectively, (on turn 1 the 
- players have 1 MP and turn 2, 2 MP.)
on turn 5 and beyond the players have 5 MP and no more than 5.
If the player has less than 6 cards on their hand they can take a card from 
the deck.

## Game Phases:

### Placement Phase:
- In this phase the player plays one or more cards in their hand, depending 
- on the MP value.
Each card has an MP value that reduces the current total of the turn you are in.

- The UI must be clear and let the player decide which card to choose and not 
- let them pass the MP value assigned each turn.

- I.e: 1. Pick a card / 1. Wand, 2. Monkey, 3. Rock, etc.
    1. ("You put down flying wand")
   <br>("End turn? 1, Continue 2")

### Attack Pase:
- Consists of utilizing the cards in the placement phase, this phase is 
- ENTIRELY AUTONOMOUS and doesn't require player input.

- I.e: Player chooses 1 to end turn, and then after the enemy finishes their 
- turn as well, the cards will begin a process of combat.

1. While cards exist for each player they will fight one by one.
    <br>i. The next card of player 1 fights the next card of player 2.
    <br>ii. The DP of each card suffers damage equal to AP of enemy card. if 
    any of the two cards' DP reaches 0 they are destroyed.
    <br>iii. The leftover AP from the fight (i.e if player 1 card wins) then 
    player 1's card will use leftover AP to hurt the next card that enters, or 
    player 2 if there is none left.(more on iV.)
    <br>iV. If any of the cards is destroyed, the card that was in queue to 
    enter, enters the field
    <br>(i.e: Flying wand is destroyed, I had played goblin troll after flying 
    wand, so it was queued up, afterwards goblin troll enters the field and 
    fights player 2's card.)
    <br>(i.e2: 2 cards with 5 AP and 4 DP, they both are destroyed but have 1 
    AP left, this AP will be used on the next card or the player if no card is
     queued up.)

2. While cards exist in game of one player.
    <br>i. To further explain: the health of the enemy player will be reduced 
    <br>ii. They will be discarded after the turn is over.

IF THERE ARE NO MORE CARDS IN THE DECK OR HAND FOR BOTH PLAYERS:
- The game will detect which player has the highest HP value and proclaim that
-  player the winner.

### The game will end if:
- One of the player's hp reaches 0
- If any of the players doesn't have any more cards (highest HP player wins)
- If one of the players quits (third option in UI that says: quit the game)

### At the intro: Both players must be informed of these rules.