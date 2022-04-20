using System;


namespace TestGitHome
{
    class Program
    {
        static void Main(string[] args)
        {
            //Main Menu
            MainMenu();


            //Declared for readers to understand
            bool accesstoOrder = true;



            Dictionary<string, int> totalFood = new Dictionary<string, int>(); //Dictionary for food order
            Dictionary<string, int> totalDrink = new Dictionary<string, int>(); //Dictionary for drink order
            Dictionary<string, int> totalSide = new Dictionary<string, int>(); //Dictionary for side order


            //Dictionary for all the things customer has ordered. Like a summary
            Dictionary<string, int> summaryOfItems = new Dictionary<string, int>();



            int totalPrice = 0;
            int totalCredit = 1000;




            while (accesstoOrder)
            {

                ColorMessage(ConsoleColor.Yellow, @"
                      ____         __          ____         __          
                     / __ \_______/ /__ ____  / __/_ _____ / /____ __ _ 
                    / /_/ / __/ _  / -_) __/ _\ \/ // (_-</ __/ -_)  ' \
                    \____/_/  \_,_/\__/_/   /___/\_, /___/\__/\__/_/_/_/
                                                /___/                   
                ");


                Console.WriteLine("\nHvad vil du gerne bestille?");

                Console.WriteLine(); //Line break

                Console.WriteLine("1) Mad | 2) Drikkevarer | 3) Tilbehør | 4) Checkout"); //options
                Console.Write(">> ");

                string menuChoice = Console.ReadLine();



                //run if user wants food
                if (menuChoice == "1")
                {
                    Console.Clear();
                    totalFood = FoodMenu();



                    /*  If customer orders food, he will have food total ellers "Food Total" key will not be declared!!!!
                    /*  ["Chicken Burger", int]
                    /*  ["Big Tasty Bacon Burger", int]
                    /*  ["Cheese Burger", int]
                    /*  ["Food Total", int] --> this is the total price of food                                                                                                                      
                     */
                }



                //run if user wants drink
                else if (menuChoice == "2")
                {
                    Console.Clear();
                    totalDrink = DrinkMenu();



                }


                //run if user wants side order
                else if (menuChoice == "3")
                {
                    Console.Clear();
                    totalSide = SideMenu();


                }



                //run if user wants to checkout
                else if (menuChoice == "4")
                {
                    Console.Clear();

                    int foodPrice = 0;
                    int drinkPrice = 0;
                    int sidePrice = 0;


                    //always run
                    if (true)
                    {


                        if (totalFood.ContainsKey("Food Total"))
                            foodPrice = totalFood["Food Total"];


                        else
                            foodPrice = 0;

                        totalFood.Remove("Food Total"); //Removing this key so that the summary dictionary only contain a summary of items

                    }


                    if (true)
                    {

                        if (totalDrink.ContainsKey("Drink Total"))
                            drinkPrice = totalDrink["Drink Total"];

                        else
                            drinkPrice = 0;

                        totalDrink.Remove("Drink Total");  //Removing this key so that the summary dictionary only contain a summary of items
                    }


                    if (true)
                    {

                        if (totalFood.ContainsKey("Side Total"))
                            sidePrice = totalSide["Side Total"];

                        else
                            sidePrice = 0;

                        totalSide.Remove("Side Total");  //Removing this key so that the summary dictionary only contain a summary of items
                    }





                    totalPrice = foodPrice + drinkPrice + sidePrice;





                    ColorMessage(ConsoleColor.Yellow, "Oversigt af din bestilling.");
                    Console.WriteLine();

                    //Adding all the food items that customer has ordered to summary dictionary
                    foreach (var items in totalFood)
                    {

                        summaryOfItems.Add(items.Key, items.Value);


                    }

                    //Adding all the drink items that customer has ordered to summary dictionary
                    foreach (var item in totalDrink)
                    {


                        summaryOfItems.Add(item.Key, item.Value);

                    }

                    //Adding all the side items that customer has ordered to summary dictionary
                    foreach (var item in totalSide)
                    {
                        summaryOfItems.Add(item.Key, item.Value); ;

                    }


                    //Print the summary of the order
                    foreach (var item in summaryOfItems)
                    {


                        ColorMessage(ConsoleColor.Green, $"{item.Value}x {item.Key}");
                    }


                    ColorMessage(ConsoleColor.Yellow, $"\nDen samlede pris er {totalPrice} kr.");





                    if (totalCredit - totalPrice > 0)
                    {
                        ColorMessage(ConsoleColor.Green, $"\nDu har {totalCredit - totalPrice} kr tilbage i din credit.");

                        CheckOut(true);
                    }


                    else
                        ColorMessage(ConsoleColor.Red, $"\nDu har ikke nok penge at købe det hele. Prøv at købe mindre. Brokeass Kid!!!");



                    break;

                }

            }


            ColorMessage(ConsoleColor.Red, @"
            
    >=======> >==>    >=> >====>     
    >=>       >> >=>  >=> >=>   >=>  
    >=>       >=> >=> >=> >=>    >=> 
    >=====>   >=>  >=>>=> >=>    >=> 
    >=>       >=>   > >=> >=>    >=> 
    >=>       >=>    >>=> >=>   >=>  
    >=======> >=>     >=> >====>     
                                 
            ");



            Console.ReadLine();

        }



        static Dictionary<string, int> FoodMenu()
        {

            Dictionary<string, int> foods = new Dictionary<string, int>();

            int foodTotal = 0;
            int chickenBurgerCount = 0;
            int bigTastyBaconCount = 0;
            int cheeseBurgerCount = 0;

            Console.WriteLine(@"
#######                         #     #                      
#        ####   ####  #####     ##   ## ###### #    # #    # 
#       #    # #    # #    #    # # # # #      ##   # #    # 
#####   #    # #    # #    #    #  #  # #####  # #  # #    # 
#       #    # #    # #    #    #     # #      #  # # #    # 
#       #    # #    # #    #    #     # #      #   ## #    # 
#        ####   ####  #####     #     # ###### #    #  ####  
");
            do
            {
                Console.WriteLine("\n*****");
                Console.WriteLine("1) Chicken Burger --> 40 kr");
                Console.WriteLine("2) Big Tasty Bacon --> 80 kr");
                Console.WriteLine("3) Cheese Burger --> 20 kr");
                Console.WriteLine("4) Færdig");
                Console.Write(">> ");

                string foodInput = Console.ReadLine();




                if (foodInput == "1")
                {
                    Console.Clear();
                    foodTotal += 40;
                    chickenBurgerCount++;
                    ColorMessage(ConsoleColor.Green, "\nDu har bestilt en Chicken Burger.");

                }


                else if (foodInput == "2")
                {
                    Console.Clear();
                    foodTotal += 80;
                    bigTastyBaconCount++;
                    ColorMessage(ConsoleColor.Green, "\nDu har bestilt en Big Tasty bacon burger.");
                }


                else if (foodInput == "3")
                {
                    Console.Clear();
                    foodTotal += 20;
                    cheeseBurgerCount++;
                    ColorMessage(ConsoleColor.Green, "\nDu har bestilt en cheese burger.");

                }



                else if (foodInput == "4")
                {
                    Console.Clear();

                    if (chickenBurgerCount > 0 && bigTastyBaconCount > 0 && cheeseBurgerCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du har bestilt {chickenBurgerCount} Chicken burger, {bigTastyBaconCount} Big Tasty bacon og {cheeseBurgerCount} cheese burger.");



                    else if (chickenBurgerCount > 0 && bigTastyBaconCount == 0 && cheeseBurgerCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du har bestilt {chickenBurgerCount} chicken burger.");

                    else if (chickenBurgerCount == 0 && bigTastyBaconCount > 0 && cheeseBurgerCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du har bestilt {bigTastyBaconCount} big Tasty bacon burger.");

                    else if (chickenBurgerCount == 0 && bigTastyBaconCount == 0 && cheeseBurgerCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du har bestilt {cheeseBurgerCount} cheese burger.");

                    else if (chickenBurgerCount > 0 && bigTastyBaconCount > 0 && cheeseBurgerCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du har bestilt {chickenBurgerCount} chicken burger og {bigTastyBaconCount} big Tasty bacon burger.");

                    else if (chickenBurgerCount > 0 && bigTastyBaconCount > 0 && cheeseBurgerCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du har bestilt {chickenBurgerCount} chicken burger og {bigTastyBaconCount} big Tasty bacon burger.");

                    else if (chickenBurgerCount == 0 && bigTastyBaconCount > 0 && cheeseBurgerCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du har bestilt {bigTastyBaconCount} Big Tasty bacon burger og {cheeseBurgerCount} cheese burger.");

                    else if (chickenBurgerCount > 0 && bigTastyBaconCount == 0 && cheeseBurgerCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du har bestilt {chickenBurgerCount} chicken burger og {cheeseBurgerCount} cheese burger.");

                    if (chickenBurgerCount > 0)
                        foods.Add("Chicken Burger", chickenBurgerCount);
                    if (bigTastyBaconCount > 0)
                        foods.Add("Big Tasty Bacon Burger", bigTastyBaconCount);
                    if (cheeseBurgerCount > 0)
                        foods.Add("Cheese Burger", cheeseBurgerCount);


                    foods.Add("Food Total", foodTotal);

                    ColorMessage(ConsoleColor.Yellow, "\nSamlede omkostninger til mad er " + foods["Food Total"] + " kr.");

                    for (int i = 0; i < 120; i++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                    return foods;

                }

            } while (true);

        }





        static Dictionary<string, int> DrinkMenu()
        {

            Dictionary<string, int> drinks = new Dictionary<string, int>();

            int colaCount = 0;
            int fantaCount = 0;
            int spriteCount = 0;
            int pepsiCount = 0;

            int totalDrinkPrice = 0;

            Console.WriteLine(@"
######                            #     #                      
#     # #####  # #    # #    #    ##   ## ###### #    # #    # 
#     # #    # # ##   # #   #     # # # # #      ##   # #    # 
#     # #    # # # #  # ####      #  #  # #####  # #  # #    # 
#     # #####  # #  # # #  #      #     # #      #  # # #    # 
#     # #   #  # #   ## #   #     #     # #      #   ## #    # 
######  #    # # #    # #    #    #     # ###### #    #  #### 
");

            do
            {
                Console.WriteLine("\n*****");
                Console.WriteLine("1) Coca cola --> 25kr for Medium | 40kr for Stor");
                Console.WriteLine("2) Fanta --> 25kr for Medium | 40kr for Stor");
                Console.WriteLine("3) Sprite --> 25kr for Medium | 40kr for Stor");
                Console.WriteLine("4) Pepsi --> 25kr for Medium | 40kr for Stor");
                Console.WriteLine("5) Færdig");
                Console.Write("--> ");

                string userDrinkInput = Console.ReadLine();


                if (userDrinkInput == "1")
                {
                    bool colaCheck = true;
                    do
                    {
                        Console.Write("Vælg Cola størrelse ('m' or 's'): --> ");
                        string checkSizeCola = Console.ReadLine().ToUpper();

                        if (checkSizeCola == "M")
                        {
                            totalDrinkPrice += 25;
                            colaCheck = false;

                        }

                        else if (checkSizeCola == "S")
                        {
                            totalDrinkPrice += 40;
                            colaCheck = false;
                        }

                        else
                        {
                            ColorMessage(ConsoleColor.Red, "Forkert input. Indtast kun 'm' eller 's'.");
                        }
                    } while (colaCheck);


                    Console.Clear();
                    colaCount++;
                    ColorMessage(ConsoleColor.Green, $"Du købte {colaCount} cola.");


                }

                else if (userDrinkInput == "2")
                {

                    bool fantaCheck = true;
                    do
                    {
                        Console.Write("Vælg Fanta størrelse ('m' or 's'): --> ");
                        string checkSizeFanta = Console.ReadLine().ToUpper();

                        if (checkSizeFanta == "M")
                        {
                            totalDrinkPrice += 25;
                            fantaCheck = false;

                        }

                        else if (checkSizeFanta == "S")
                        {
                            totalDrinkPrice += 40;
                            fantaCheck = false;
                        }

                        else
                        {
                            ColorMessage(ConsoleColor.Red, "Forkert input.Indtast kun 'm' eller 's'.");

                        }

                    } while (fantaCheck);




                    Console.Clear();
                    fantaCount++;
                    ColorMessage(ConsoleColor.Green, $"Du købte {fantaCount} fanta.");


                }

                else if (userDrinkInput == "3")
                {

                    bool spriteCheck = true;

                    do
                    {
                        Console.Write("Vælg Sprite størrelse ('m' or 's'): --> ");
                        string checkSizeSprite = Console.ReadLine().ToUpper();

                        if (checkSizeSprite == "M")
                        {
                            totalDrinkPrice += 25;
                            spriteCheck = false;

                        }

                        else if (checkSizeSprite == "S")
                        {
                            totalDrinkPrice += 40;
                            spriteCheck = false;
                        }

                        else
                        {
                            ColorMessage(ConsoleColor.Red, "Forkert input.Indtast kun 'm' eller 's'.");

                        }

                    } while (spriteCheck);



                    Console.Clear();
                    spriteCount++;
                    ColorMessage(ConsoleColor.Green, $"Du købte {spriteCount} sprite.");


                }

                else if (userDrinkInput == "4")
                {

                    bool pepsiCheck = true;

                    do
                    {
                        Console.Write("Vælg Pepsi størrelse ('m' or 's'): --> ");
                        string checkSizePepsi = Console.ReadLine().ToUpper();

                        if (checkSizePepsi == "M")
                        {
                            totalDrinkPrice += 25;
                            pepsiCheck = false;

                        }

                        else if (checkSizePepsi == "S")
                        {
                            totalDrinkPrice += 40;
                            pepsiCheck = false;
                        }

                        else
                        {
                            ColorMessage(ConsoleColor.Red, "Forkert input.Indtast kun 'm' eller 's'.");
                            continue;
                        }

                    } while (pepsiCheck);



                    Console.Clear();
                    pepsiCount++;
                    ColorMessage(ConsoleColor.Green, $"Du købte {pepsiCount} pepsi.");


                }

                else if (userDrinkInput == "5")
                {
                    //1234
                    if (colaCount > 0 && fantaCount > 0 && spriteCount > 0 && pepsiCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {colaCount} cola, {fantaCount} fanta, {spriteCount} sprite og {pepsiCount} pepsi.");
                    //1
                    else if (colaCount > 0 && fantaCount == 0 && spriteCount == 0 && pepsiCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {colaCount} cola.");
                    //2
                    else if (colaCount == 0 && fantaCount > 0 && spriteCount == 0 && pepsiCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {fantaCount} fanta.");
                    //3
                    else if (colaCount == 0 && fantaCount == 0 && spriteCount > 0 && pepsiCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {spriteCount} sprite.");
                    //4
                    else if (colaCount == 0 && fantaCount == 0 && spriteCount == 0 && pepsiCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {pepsiCount} pepsi.");
                    //12
                    else if (colaCount > 0 && fantaCount > 0 && spriteCount == 0 && pepsiCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {colaCount} cola og {fantaCount} fanta.");
                    //23
                    else if (colaCount == 0 && fantaCount > 0 && spriteCount > 0 && pepsiCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {fantaCount} fanta og {spriteCount} sprite.");
                    //13
                    else if (colaCount > 0 && fantaCount == 0 && spriteCount > 0 && pepsiCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {colaCount} cola og {spriteCount} sprite.");
                    //34
                    else if (colaCount == 0 && fantaCount == 0 && spriteCount > 0 && pepsiCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {spriteCount} sprite og {pepsiCount} pepsi.");
                    //14
                    else if (colaCount > 0 && fantaCount == 0 && spriteCount == 0 && pepsiCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {colaCount} cola og {pepsiCount} pepsi.");
                    //24
                    else if (colaCount == 0 && fantaCount > 0 && spriteCount == 0 && pepsiCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {fantaCount} fanta og {pepsiCount} pepsi.");
                    //123
                    else if (colaCount > 0 && fantaCount > 0 && spriteCount > 0 && pepsiCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {colaCount} cola, {fantaCount} fanta og {spriteCount} sprite.");
                    //234
                    else if (colaCount == 0 && fantaCount > 0 && spriteCount > 0 && pepsiCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {fantaCount} fanta, {spriteCount} sprite og {pepsiCount} pepsi.");
                    //134
                    else if (colaCount > 0 && fantaCount == 0 && spriteCount > 0 && pepsiCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {colaCount} cola, {spriteCount} sprite og {pepsiCount} pepsi.");
                    //124
                    else if (colaCount > 0 && fantaCount > 0 && spriteCount == 0 && pepsiCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du købte {colaCount} cola og {fantaCount} fanta og {pepsiCount} pepsi.");



                    if (colaCount > 0)
                        drinks.Add("Cola", colaCount);

                    if (fantaCount > 0)
                        drinks.Add("Fanta", fantaCount);

                    if (spriteCount > 0)
                        drinks.Add("Sprite", spriteCount);

                    if (pepsiCount > 0)
                        drinks.Add("Pepsi", pepsiCount);




                    drinks.Add("Drink Total", totalDrinkPrice);




                    ColorMessage(ConsoleColor.Yellow, "Samlede omkostninger til drikke er " + totalDrinkPrice + " kr.");
                    for (int i = 0; i < 120; i++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                    return drinks;

                }


            } while (true);




        }


        static Dictionary<string, int> SideMenu()
        {

            Dictionary<string, int> side = new Dictionary<string, int>();

            int pommesFritesCount = 0;
            int mcNuggetsCount = 0;
            int chilliCheeseCount = 0;
            int hotWingsCount = 0;
            int dipCount = 0;
            int sideTotal = 0;

            Console.WriteLine(@"
 #####                     #######                             
#     # # #####  ######    #     # #####  #####  ###### #####  
#       # #    # #         #     # #    # #    # #      #    # 
 #####  # #    # #####     #     # #    # #    # #####  #    # 
      # # #    # #         #     # #####  #    # #      #####  
#     # # #    # #         #     # #   #  #    # #      #   #  
 #####  # #####  ######    ####### #    # #####  ###### #    #



");

            do
            {
                Console.WriteLine("");
                Console.WriteLine("\nOptions");
                Console.WriteLine("1) Pommes Frites --> 20 kr for medium || 40 kr for Stor");
                Console.WriteLine("2) Mc Nuggets --> 30 kr for 6 stk || 39 kr for 9 stk");
                Console.WriteLine("3) Chilli Cheese Tops --> 20 kr for 7 stk || 50 kr for 18 stk");
                Console.WriteLine("4) Hot Wings --> 20 kr for 3 stk || 35 kr for 6 stk");
                Console.WriteLine("5) Dip --> 7 kr for hver dip");
                Console.WriteLine("6) Færdig");
                Console.Write(">> ");



                string sideInput = Console.ReadLine();
                Console.WriteLine();

                if (sideInput == "1")
                {
                    bool pommesFritesCheck = true;
                    do
                    {
                        Console.Write("Vælg Pommes Frites størrelse ('m' or 's'): --> ");
                        string checkSizePomFrit = Console.ReadLine().ToUpper();

                        if (checkSizePomFrit == "M")
                        {
                            sideTotal += 20;
                            pommesFritesCheck = false;

                        }

                        else if (checkSizePomFrit == "S")
                        {
                            sideTotal += 40;
                            pommesFritesCheck = false;
                        }

                        else
                        {
                            ColorMessage(ConsoleColor.Red, "Forkert input. Indtast kun 'm' eller 's'");
                        }
                    } while (pommesFritesCheck);


                    Console.Clear();
                    pommesFritesCount++;

                    ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites.");
                }


                else if (sideInput == "2")
                {
                    bool mcNuggetsCheck = true;
                    do
                    {
                        Console.Write("Vælg McNuggets størrelse ('6' or '9'): --> ");
                        string checkSizeMcNugs = Console.ReadLine();

                        if (checkSizeMcNugs == "6")
                        {
                            sideTotal += 30;
                            mcNuggetsCheck = false;

                        }

                        else if (checkSizeMcNugs == "9")
                        {
                            sideTotal += 39;
                            mcNuggetsCheck = false;
                        }

                        else
                        {
                            ColorMessage(ConsoleColor.Red, "Forkert input. Indtast kun '6' eller '9'.");
                        }
                    } while (mcNuggetsCheck);


                    Console.Clear();
                    mcNuggetsCount++;

                    ColorMessage(ConsoleColor.Green, $"Du bestilte {mcNuggetsCount} McNuggets.");


                }


                else if (sideInput == "3")
                {
                    bool chilliCheeseTopsCheck = true;
                    do
                    {
                        Console.Write("Vælg Chili Cheese Tops størrelse ('7' eller '18'): --> ");
                        string checkSizeChilliTops = Console.ReadLine();

                        if (checkSizeChilliTops == "7")
                        {
                            sideTotal += 20;
                            chilliCheeseTopsCheck = false;

                        }

                        else if (checkSizeChilliTops == "18")
                        {
                            sideTotal += 50;
                            chilliCheeseTopsCheck = false;
                        }

                        else
                        {
                            ColorMessage(ConsoleColor.Red, "Forkert input. Indtast kun '7' eller '18'.");
                        }
                    } while (chilliCheeseTopsCheck);


                    Console.Clear();
                    chilliCheeseCount++;

                    ColorMessage(ConsoleColor.Green, $"Du bestilte {chilliCheeseCount} Chilli Cheese Tops.");

                }


                else if (sideInput == "4")
                {
                    bool hotWingsCheck = true;
                    do
                    {
                        Console.Write("Vælg Hot Wings størrelse ('3' eller '6'): --> ");
                        string checkSizeHotWings = Console.ReadLine();

                        if (checkSizeHotWings == "3")
                        {
                            sideTotal += 20;
                            hotWingsCheck = false;

                        }

                        else if (checkSizeHotWings == "6")
                        {
                            sideTotal += 35;
                            hotWingsCheck = false;
                        }

                        else
                        {
                            ColorMessage(ConsoleColor.Red, "Forkert input.Indtast kun '3' eller '6'");
                        }
                    } while (hotWingsCheck);


                    Console.Clear();
                    hotWingsCount++;

                    ColorMessage(ConsoleColor.Green, $"Du bestilte {hotWingsCount} Hot Wings.");
                }


                else if (sideInput == "5")
                {
                    Console.Clear();
                    sideTotal += 7;
                    dipCount++;
                    ColorMessage(ConsoleColor.Green, $"Du købte {dipCount} dip.");
                }


                else if (sideInput == "6")
                {
                    //12345
                    if (pommesFritesCount > 0 && mcNuggetsCount > 0 && chilliCheeseCount > 0 && hotWingsCount > 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites, {mcNuggetsCount} McNuggets, {chilliCheeseCount} Chilli Cheese Tops og {dipCount} Dip.");
                    //12
                    else if (pommesFritesCount > 0 && mcNuggetsCount > 0 && chilliCheeseCount == 0 && hotWingsCount == 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites og {mcNuggetsCount} McNuggets.");
                    //23
                    else if (pommesFritesCount == 0 && mcNuggetsCount > 0 && chilliCheeseCount > 0 && hotWingsCount == 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {mcNuggetsCount} McNuggets og {chilliCheeseCount} Chilli Cheese Tops.");
                    //34
                    else if (pommesFritesCount == 0 && mcNuggetsCount == 0 && chilliCheeseCount > 0 && hotWingsCount > 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {chilliCheeseCount} Chilli Cheese Tops og {hotWingsCount} Hot Wings.");
                    //45
                    else if (pommesFritesCount == 0 && mcNuggetsCount == 0 && chilliCheeseCount == 0 && hotWingsCount > 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {hotWingsCount} Hot Wings og {dipCount} Dip.");
                    //15
                    else if (pommesFritesCount > 0 && mcNuggetsCount == 0 && chilliCheeseCount == 0 && hotWingsCount == 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites og {dipCount} Dip.");
                    //13
                    else if (pommesFritesCount > 0 && mcNuggetsCount == 0 && chilliCheeseCount > 0 && hotWingsCount == 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites og {chilliCheeseCount} Chilli Cheese Tops.");
                    //14
                    else if (pommesFritesCount > 0 && mcNuggetsCount == 0 && chilliCheeseCount == 0 && hotWingsCount > 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites og {hotWingsCount} Hot Wings.");
                    //24
                    else if (pommesFritesCount == 0 && mcNuggetsCount > 0 && chilliCheeseCount == 0 && hotWingsCount > 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {mcNuggetsCount} McNuggets og {hotWingsCount} Hot Wings.");
                    //25
                    else if (pommesFritesCount == 0 && mcNuggetsCount > 0 && chilliCheeseCount == 0 && hotWingsCount == 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {chilliCheeseCount} Chilli Cheese Tops og {hotWingsCount} Hot Wings.");
                    //35
                    else if (pommesFritesCount == 0 && mcNuggetsCount == 0 && chilliCheeseCount > 0 && hotWingsCount == 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {chilliCheeseCount} Chilli Cheese Tops og {dipCount} Dip.");
                    //1
                    else if (pommesFritesCount > 0 && mcNuggetsCount == 0 && chilliCheeseCount == 0 && hotWingsCount == 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites.");
                    //2
                    else if (pommesFritesCount == 0 && mcNuggetsCount > 0 && chilliCheeseCount == 0 && hotWingsCount == 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {mcNuggetsCount} McNuggets.");
                    //3
                    else if (pommesFritesCount == 0 && mcNuggetsCount == 0 && chilliCheeseCount > 0 && hotWingsCount == 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {chilliCheeseCount} Chilli Cheese Tops.");
                    //4
                    else if (pommesFritesCount == 0 && mcNuggetsCount == 0 && chilliCheeseCount == 0 && hotWingsCount > 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {hotWingsCount} Hot Wings.");
                    //5
                    else if (pommesFritesCount == 0 && mcNuggetsCount == 0 && chilliCheeseCount == 0 && hotWingsCount == 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {dipCount} Dip.");
                    //123
                    else if (pommesFritesCount > 0 && mcNuggetsCount > 0 && chilliCheeseCount > 0 && hotWingsCount == 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites, {mcNuggetsCount} McNuggets og {chilliCheeseCount} Chilli Cheese Tops.");
                    //234
                    else if (pommesFritesCount == 0 && mcNuggetsCount > 0 && chilliCheeseCount > 0 && hotWingsCount > 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {mcNuggetsCount} McNuggets, {chilliCheeseCount} Chilli Cheese Tops og {hotWingsCount} Hot Wings.");
                    //345
                    else if (pommesFritesCount == 0 && mcNuggetsCount == 0 && chilliCheeseCount > 0 && hotWingsCount > 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {chilliCheeseCount} Chilli Cheese Tops, {hotWingsCount} Hot Wings og {dipCount} Dip.");
                    //134
                    else if (pommesFritesCount > 0 && mcNuggetsCount == 0 && chilliCheeseCount > 0 && hotWingsCount > 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites, {chilliCheeseCount} Chilli Cheese Tops og {hotWingsCount} Hot Wings.");
                    //245
                    else if (pommesFritesCount == 0 && mcNuggetsCount > 0 && chilliCheeseCount == 0 && hotWingsCount > 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {mcNuggetsCount} McNuggets, {hotWingsCount} Hot Wings og {dipCount} Dip.");
                    //145
                    else if (pommesFritesCount > 0 && mcNuggetsCount == 0 && chilliCheeseCount == 0 && hotWingsCount > 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites, {hotWingsCount} Hot Wings og {dipCount} Dip.");
                    //235
                    else if (pommesFritesCount == 0 && mcNuggetsCount > 0 && chilliCheeseCount > 0 && hotWingsCount == 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {mcNuggetsCount} McNuggets, {chilliCheeseCount} Chilli Cheese Tops og {dipCount} Dip.");
                    //135
                    else if (pommesFritesCount > 0 && mcNuggetsCount == 0 && chilliCheeseCount > 0 && hotWingsCount == 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites, {chilliCheeseCount} Chilli Cheese Tops og {dipCount} Dip.");
                    //124
                    else if (pommesFritesCount > 0 && mcNuggetsCount > 0 && chilliCheeseCount == 0 && hotWingsCount > 0 && dipCount == 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites, {mcNuggetsCount} McNuggets og {hotWingsCount} Hot Wings.");
                    //125
                    else if (pommesFritesCount > 0 && mcNuggetsCount > 0 && chilliCheeseCount == 0 && hotWingsCount == 0 && dipCount > 0)
                        ColorMessage(ConsoleColor.Green, $"Du bestilte {pommesFritesCount} Pommes Frites, {mcNuggetsCount} McNuggets og {dipCount} Dip.");


                    if (pommesFritesCount > 0)
                        side.Add("Pommes Frites", pommesFritesCount);


                    if (mcNuggetsCount > 0)
                        side.Add("McNuggets", mcNuggetsCount);

                    if (chilliCheeseCount > 0)
                        side.Add("Chilli Cheese", chilliCheeseCount);

                    if (hotWingsCount > 0)
                        side.Add("Hot Wings", hotWingsCount);

                    if (dipCount > 0)
                        side.Add("Dip", dipCount);

                    side.Add("Side Total", sideTotal);



                    ColorMessage(ConsoleColor.Yellow, "Samlede omkostninger til tilbehør er " + sideTotal + " kr.");
                    for (int i = 0; i < 120; i++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                    return side;



                }

            } while (true);

        }


        static void CheckOut(bool checkBalance)
        {

            if (checkBalance == true)
            {
                Console.WriteLine();
                Console.WriteLine(@"
 #####                                                  
#     # #    # ######  ####  #    #  ####  #    # ##### 
#       #    # #      #    # #   #  #    # #    #   #   
#       ###### #####  #      ####   #    # #    #   #   
#       #    # #      #      #  #   #    # #    #   #   
#     # #    # #      #    # #   #  #    # #    #   #   
 #####  #    # ######  ####  #    #  ####   ####    #   
");

                Random orderNumber = new Random();
                int num = orderNumber.Next(1, 100);
                Console.WriteLine($"Din bestilling nummer er {num}.");
                Console.WriteLine("Vent venligst for din bestilling for at blive klar....");

                Console.WriteLine();
                if (num < 50)
                {
                    Thread.Sleep(5000);
                    ColorMessage(ConsoleColor.Green, $"Bestiling nummer {num} er klar.");
                }
                else if (num > 50)
                {
                    Thread.Sleep(10000);
                    ColorMessage(ConsoleColor.Green, $"Bestilling nummer {num} er klar.");
                }

                Console.WriteLine("");
                Console.WriteLine("");

            }




        }

        static void ColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);
            Console.ResetColor();


        }

        static void MainMenu()
        {
            ColorMessage(ConsoleColor.Green, @"
                
                
                          _______  _        _______  _______  _______  _______   _________ _______   
                |\     /|(  ____ \( \      (  ____ \(  ___  )(       )(  ____ \  \__   __/(  ___  )  
                | )   ( || (    \/| (      | (    \/| (   ) || () () || (    \/     ) (   | (   ) |  
                | | _ | || (__    | |      | |      | |   | || || || || (__         | |   | |   | |  
                | |( )| ||  __)   | |      | |      | |   | || |(_)| ||  __)        | |   | |   | |  
                | || || || (      | |      | |      | |   | || |   | || (           | |   | |   | |  
                | () () || (____/\| (____/\| (____/\| (___) || )   ( || (____/\     | |   | (___) |  
                (_______)(_______/(_______/(_______/(_______)|/     \|(_______/     )_(   (_______)  
                                                                                     
                 _______  _______    ______   _______  _        _______  _        ______   _______   
                (       )(  ____ \  (  __  \ (  ___  )( (    /|(  ___  )( \      (  __  \ (  ____ \  
                | () () || (    \/  | (  \  )| (   ) ||  \  ( || (   ) || (      | (  \  )| (    \/  
                | || || || |        | |   ) || |   | ||   \ | || (___) || |      | |   ) || (_____   
                | |(_)| || |        | |   | || |   | || (\ \) ||  ___  || |      | |   | |(_____  )  
                | |   | || |        | |   ) || |   | || | \   || (   ) || |      | |   ) |      ) |  
                | )   ( || (____/\  | (__/  )| (___) || )  \  || )   ( || (____/\| (__/  )/\____) |  
                |/     \|(_______/  (______/ (_______)|/    )_)|/     \|(_______/(______/ \_______)  
                                                                                    
                
                ");

            Console.WriteLine("Indtast dit navn for at gå til ordresystemet.");
            Console.Write(">> ");


            string customerName = Console.ReadLine();



            if (customerName == String.Empty)
                ColorMessage(ConsoleColor.Green, $"\nHej Ukendt person, du har 1000 kr i din kredit.");

            else
                ColorMessage(ConsoleColor.Green, $"\nHej {customerName}, du har 1000 kr i din kredit.");




            Console.WriteLine("\nTryk på en vilkårlig tast for at gå ind i ordresystemet.");

            Console.ReadKey();

            Console.Clear();

        }

    }


}