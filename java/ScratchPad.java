// import java.util.Scanner

// SCRATCHPAD FOR CODE SNIPPETS FROM edX "LEARN TO PROGRAM IN JAVA" COURSE

public class ScratchPad {

    /*
    ===================================
    Keyboard Shortcuts in IntelliJ IDEA
    ===================================
    sout + Tab
    Ctrl + /
    Ctrl + Shift + /
    Ctrl + D
    Ctrl + Shift + Backspace (navigate to last place(s) where you made changes in code)
    ===================================
     */

    public static void main(String[] args) {




/*
// From Module 3's lesson "Meet Parameters": illustration of use of parameters
// GREAT EXAMPLE of how to calc the nth power of a given number (in this case 2^6)

    // Declare parameters in method (order of parameters is obviously v. important)
    public static void power(int base, int exp) {
        result = 1;
        for (int i = 1; i <= exp; i++) {
            result *= base;
        }
        System.out.println("base to the " + exp + " = " + result);
    }

    // Call method with parameters in main method
    power(2,6);
*/

/*
// Two examples of bad nested for loops with wrong variables updated
// from Module 2's video "Nested Loops"

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 10; j++) {
                System.out.print("*");
            }
            System.out.println();
        }
*/

/*
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 10; j++) {
                System.out.print("*");
            }
            System.out.println();
        }
*/

// Corrected code examples for Module 2's lesson "Nested Loops"
/*
        for (int row = 1; row <= 5; row++) {
            for (int col = 1; col <= 5; col++) {
                System.out.print("0 ");
            }
            System.out.println();
        }

        System.out.println();
*/

/*
        for (int row = 1; row <= 5; row++) {
            for (int col = 1; col <= 5; col++) {
                if (row == col) {
                    System.out.print("1 ");
                } else {
                    System.out.print("0 ");
                }
            }
            System.out.println();
            System.out.println();
            System.out.println();


        }
*/

/*
    if (straight) {
        if (flush) {
            System.out.println("straight flush");
        } else {
            System.out.println("straight");
        }
    } else if (flush) {
        System.out.println("flush");
    }

    if (straight && flush) {
        System.out.println("straight flush");
    } else if (straight) {
        System.out.println("straight");
    } else if (flush) {
        System.out.println("flush");
    }
*/

/*
    // https://practiceit.cs.washington.edu/problem/view/bjp4/chapter5/s2-forToWhile
    // a.
        System.out.println("a.");
        int max = 5;
        for (int n = 1; n <= max; n++) {
            System.out.println(n);
        }
        System.out.println();

    // a.
        System.out.println("a.");
        max = 5;
        int n = 1;
        while (n <= max) {
            System.out.println(n);
            n++;
        }
        System.out.println();

    // b.
        System.out.println("b.");
        int total = 25;
        int number = 1;
        while (number <= (total / 2)) {
            total = total - number;
            System.out.println(total + " " + number);
            number++;
        }
        System.out.println();

    // b.
        System.out.println("b.");
        total = 25;
        for (int number1 = 1; number1 <= (total / 2); number1++) {
            total = total - number1;
            System.out.println(total + " " + number1);
        }
        System.out.println();

    // c.
        System.out.println("c.");
        int i = 1;
        while (i <= 2) {
            int j = 1;
            while (j <= 3) {
                int k = 1;
                while (k <= 4) {
                    System.out.print("*");
                    k++;
                }
                System.out.print("!");
                j++;
            }
            System.out.println();
            i++;
        }
        System.out.println();

    // c.
        System.out.println("c.");
        for (i = 1; i <= 2; i++) {
            for (int j = 1; j <= 3; j++) {
                for (int k = 1; k <= 4; k++) {
                    System.out.print("*");
                }
                System.out.print("!");
            }
            System.out.println();
        }
        System.out.println();

    // d.
        System.out.println("d.");
        int number2 = 4;
        int count = 1;
        while (count <= number2) {
            System.out.println(number2);
            number2 = number2 / 2;
            count++;
        }

    // d.
        System.out.println("d.");
        int number1 = 4;
        for (int count1 = 1; count1 <= number1; count1++) {
            System.out.println(number1);
            number1 = number1 / 2;
        }
*/

    }
}
