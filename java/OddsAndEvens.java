import java.util.*; // Imports all of java.util thus allowing access to both Scanner and Random

public class OddsAndEvens {

    public static void main(String[] args) {

     // Part 1
        Scanner input = new Scanner(System.in);
        System.out.println("Let's play a game called \"Odds and Evens\" ");
        System.out.print("What is your name? ");
        String name = input.nextLine();
        System.out.print("Hi " + name + ", which do you choose? (O)dds or (E)vens? ");
        String playerChoice = input.next(); // Is .next() correct here?

        // Test for and handle invalid user input; valid input is either "O" for odd or "E" for even
        while (!(playerChoice.equals("O")) || (playerChoice.equals("E"))) {
            System.out.print("  Bad input: please enter \"E\" for even or \"O\" for odd. Please try again. ");
            playerChoice = input.next();
        }

        // Handle valid user input
        if (playerChoice.equals("O")) {
            System.out.println(name + " has picked odds! The computer will be evens.");
        } else if (playerChoice.equals("E")) {
            System.out.println(name + " has picked evens! The computer will be odds.");
        }

        System.out.println("--------------------------");


     // Part 2
        System.out.print("How many \"fingers\" do you put out? (Only one hand, please.) ");
        int playerFingers = input.nextInt();
        Random rand = new Random();
        int computerFingers = rand.nextInt(6);
        System.out.println("Computer plays " + computerFingers + " \"fingers\".");
        System.out.println("--------------------------");
        int sumFingers = (playerFingers + computerFingers);
        System.out.println(playerFingers + " + " + computerFingers + " = " + sumFingers);
        boolean oddOrEven = (sumFingers % 2 == 0); // Boolean is true if sumFingers is even

        if (oddOrEven) {
            System.out.println(sumFingers + " is...even!");
            if (playerChoice.equals("E")) {
                System.out.println("That means " + name + " wins! :)");
            } else {
                System.out.println("That means the computer wins! :(");
            }
        } else {
            System.out.println(sumFingers + " is...odd!");
            if (playerChoice.equals("O")) {
                System.out.println("That means " + name + " wins! :)");
            } else {
                System.out.println("That means the computer wins! :(");
            }
        }

        System.out.println("--------------------------");

    }

}
