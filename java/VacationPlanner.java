import java.util.Scanner;

public class VacationPlanner {

    public static void main(String[] args) {
        introMethod();
        budgetMethod();
        timeMethod();
        distanceMethod();
    }

    public static void introMethod() {
        Scanner input = new Scanner(System.in);
        System.out.println("Welcome to Vacation Planner!");
        System.out.print("What is your name? ");
        String name = input.nextLine();
        System.out.print("Nice to meet you, " + name + ", where are you travelling to? ");
        String destination = input.nextLine();
        System.out.println("Great! " + destination + " sounds like a great trip!");
        System.out.println("**********");
    }

    public static void budgetMethod() {
        Scanner input = new Scanner(System.in);
        System.out.print("How many days are you going to spend on your trip? "); // 10.5

        // Create variable with precision of two decimal places for travel time
        double travelTime = input.nextDouble();
        int travelTimeRound = (int) (travelTime * 100);
        double travelTimeCleaned = (double) travelTimeRound / 100.0;
        // System.out.println("Print test: " + travelTimeCleaned); // Test print to check type

        System.out.print("What is your total budget for the trip in USD? "); //2500.2517

        // Create variable with precision of two decimal places for total trip budget in USD
        double tripBudget = input.nextDouble();
        int tripBudgetRound = (int) (tripBudget * 100);
        double tripBudgetCleaned = (double) tripBudgetRound / 100.0;
        // System.out.println("Print test: " + tripBudgetCleaned); // Test print to check type

        System.out.print("What is the currency symbol for your destination? "); // JPY
        String currencySymbol = input.next();
        System.out.print("How many " + currencySymbol + " are in 1 USD? "); //110.0137

        // Create variable with precision of two decimal places for conversion from USD to destination currency
        double currencyConversion = input.nextDouble();
        int currencyConversionRound = (int) (currencyConversion * 100);
        double currencyConversionCleaned = (double) currencyConversionRound / 100.0;
        // System.out.println("Print test: " + currencyConversionCleaned); // Test print to check type

        // Create variable with precision of two decimal places for daily allowance in USD
        double dailyAllowance = (tripBudgetCleaned / travelTimeCleaned);
        int dailyAllowanceRound = (int) (dailyAllowance * 100);
        double dailyAllowanceCleaned = (double) dailyAllowanceRound / 100.0;

        // Create variable with precision of two decimal places for total trip budget in destination currency
        double totalBudgetInCurrency = (currencyConversionCleaned * tripBudgetCleaned);
        int totalBudgetInCurrencyRound = (int) (totalBudgetInCurrency * 100);
        double totalBudgetInCurrencyCleaned = (double) totalBudgetInCurrencyRound / 100.0;

        // Create variable with precision of two decimal places for daily allowance in destination currency
        double dailyAllowanceInCurrency = (currencyConversionCleaned * tripBudgetCleaned / travelTimeCleaned);
        int dailyAllowanceInCurrencyRound = (int) (dailyAllowanceInCurrency * 100);
        double dailyAllowanceInCurrencyCleaned = (double) dailyAllowanceInCurrencyRound / 100.0;

        System.out.println();
        System.out.println("If you are traveling for " + travelTimeCleaned +
                " days, that is the same as " + (travelTimeCleaned * 24) +
                " hours or " + (travelTimeCleaned * 3600) + " minutes.");
        System.out.println("If you are going to spend $" + tripBudgetCleaned +
                " USD, that means you can spend per day up to $" + dailyAllowanceCleaned + " USD.");
        System.out.println("Your total budget in " + currencySymbol + " is " +
                totalBudgetInCurrencyCleaned + " " + currencySymbol + ", which per day is " +
                dailyAllowanceInCurrencyCleaned + " " + currencySymbol + ".");
        System.out.println("**********");
        System.out.println();
    }

    public static void timeMethod() {
        Scanner input = new Scanner(System.in);
        System.out.print("What is the time difference in hours between your home and your destination? ");
        int timeDifference = input.nextInt(); // 16 (Idea: account for 0.5 and 0.25 hour increments)
        System.out.println("That means when it is midnight at home it is " + timeDifference +
                ":00 in your travel destination,\nand when it is noon at home it is " +
                (int)((timeDifference + 12) % 24) + ":00 in your travel destination.");
        System.out.println("**********");
        System.out.println();
    }

    public static void distanceMethod() {
        Scanner input = new Scanner(System.in);
        System.out.print("What is the square area of your destination country in km^2? "); // Japan: 377972 km^2
        double destAreaInKm2 = input.nextDouble();

        // Convert from km^2 to mi^2
        double destAreaInMi2 = (destAreaInKm2 * 0.62137 * 0.62137);

        // Create variable with precision of two decimal places for destination area in mi^2
        int destAreaInMi2Round = (int) (destAreaInMi2 * 100);
        double destAreaInMi2Cleaned = (double) destAreaInMi2Round / 100.0;
        // System.out.println("Print test: " + destAreaInMi2Cleaned); // Test print to check type

        System.out.println("In miles^2 that is " + destAreaInMi2Cleaned + "."); // 145,935 mi^2
        System.out.println("**********");
        System.out.println();
    }

}

//      Previous way I handled the cleaning of the numbers to two decimal places;
//      this was applied to the original, non-cleaned variables in the *print statements*:
//        ( ( (double)( (int)( (variable) * 100 ) ) ) / 100.0 )
