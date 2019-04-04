using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Family_Guy_Project
{
    public partial class Game_board : Form
    {
        public Game_board()
        {
            InitializeComponent();
        }

        //All the methods for the turns


        //The PeterTurn method accepts text as
        //an argument.  It assigns the text entered
        //by the user to the object's properties.
        private void PeterTurn(Peter peter)
        {
            //Temporary variables to hold health and 
            //points

            //NOTE: The health scale works where 0 = full health 
            //and 20 = dead

            //Drinking adds to health amount; water, medicine, &
            //transfusion subtract from health amount

            //Peter
            int healthPeter = 0;
            int pointsPeter = 0;
            int healthBeerPeter = 0;
            int healthWinePeter = 0;
            int healthTequilaPeter = 0;
            int pointsBeerPeter = 0;
            int pointsWinePeter = 0;
            int pointsTequilaPeter = 0;
            int totalHealthPeter = 0;
            int totalPointsPeter = 0;

            //Integer variables for each type of drink
            int beer;
            int wine;
            int tequila;
            int water = 0;


            //Get the player name.
            if (characterEntryTextBox.Text == "Peter")
            {
                peterPictureBox.Visible = true;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = false;

                //Get the beer count.
                if (int.TryParse(beerTextBox.Text, out beer))
                {
                    healthBeerPeter = healthPeter + (1 * beer);                    //cost of 1 unit of health per beer
                    pointsBeerPeter = pointsPeter + (10 * beer);               //10 points awarded per beer

                    //Get the wine count.
                    if (int.TryParse(wineTextBox.Text, out wine))
                    {
                        healthWinePeter = healthPeter + (2 * wine);            //cost of 2 units of health per wine
                        pointsWinePeter = pointsPeter + (15 * wine);           //15 points awarded per wine

                        //Get the tequila count.
                        if (int.TryParse(tequilaTextBox.Text, out tequila))
                        {
                            healthTequilaPeter = healthPeter + (4 * tequila);         //cost of 4 units of health per tequila
                            pointsTequilaPeter = pointsPeter + (35 * tequila);        //35 points awarded per tequila

                            //Restrictions on amount of drinks per turn.

                            if ((beer + wine + tequila <= 5) && water < 1 && beer >= 0 && wine >= 0 && tequila >= 0)
                            {
                                //Sum all the drinks (variables).
                                totalHealthPeter = healthBeerPeter + healthWinePeter + healthTequilaPeter;

                                totalPointsPeter = pointsBeerPeter + pointsWinePeter + pointsTequilaPeter;

                                //Gets the health and points 
                                peter.HealthPeter = totalHealthPeter;
                                peter.PointsPeter = totalPointsPeter;

                                //Consider water for regeneration.
                                if (int.TryParse(waterTextBox.Text, out water))
                                {
                                    //Restriction of 5 drinks of water per turn.
                                    if (water >= 1 && water <= 5)
                                    {
                                        //Set all alcoholic fields and variables to 0.  Water cannot be consumed with alcohol.
                                        beer = 0;
                                        beerTextBox.Text = "0";
                                        wine = 0;
                                        wineTextBox.Text = "0";
                                        tequila = 0;
                                        tequilaTextBox.Text = "0";

                                        //Health regeneration of water. 
                                        totalHealthPeter = -(water);    //-1 per unit to general health.
                                        totalPointsPeter = water;

                                        //Gets the health and points 
                                        peter.HealthPeter = totalHealthPeter;
                                        peter.PointsPeter = totalPointsPeter;


                                    }
                                    else if (water == 0 || waterTextBox.Text == "")
                                    {
                                        //Sum all the drinks (variables).
                                        totalHealthPeter = healthBeerPeter + healthWinePeter + healthTequilaPeter;
                                        totalPointsPeter = pointsBeerPeter + pointsWinePeter + pointsTequilaPeter;

                                        //Gets the health and points 
                                        peter.HealthPeter = totalHealthPeter;
                                        peter.PointsPeter = totalPointsPeter;
                                    }
                                    else if (water > 5)
                                    {
                                        MessageBox.Show("Cannot consumer more than 5 drinks of water per turn.");
                                        MessageBox.Show("You lose your turn.");
                                        //Set alcohol and water fields to 0.
                                        beerTextBox.Text = "0";
                                        beer = 0;
                                        wineTextBox.Text = "0";
                                        wine = 0;
                                        tequilaTextBox.Text = "0";
                                        tequila = 0;
                                        waterTextBox.Text = "0";
                                        water = 0;


                                        //Health regeneration of water. 
                                        totalHealthPeter = -(water);    //-1 per unit to general health.
                                        totalPointsPeter = water;

                                        //Gets the health and points 
                                        peter.HealthPeter = totalHealthPeter;
                                        peter.PointsPeter = totalPointsPeter;
                                    }
                                    else if (water < 0)
                                    {
                                        MessageBox.Show("Water must be a non negative whole number.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Enter non negative whole number for water.");
                                    MessageBox.Show("You lose your turn.");
                                    //Set alcohol and water fields to 0.
                                    beerTextBox.Text = "0";
                                    beer = 0;
                                    wineTextBox.Text = "0";
                                    wine = 0;
                                    tequilaTextBox.Text = "0";
                                    tequila = 0;
                                    waterTextBox.Text = "0";
                                    water = 0;

                                    //Health regeneration of water. 
                                    totalHealthPeter = -(water);    //-1 per unit to general health.
                                    totalPointsPeter = water;

                                    //Gets the health and points 
                                    peter.HealthPeter = totalHealthPeter;
                                    peter.PointsPeter = totalPointsPeter;
                                }
                                
                            }
                            else if (beer + wine + tequila > 5)
                            {
                                MessageBox.Show("you did not do well...cannot drink more than 5 drinks per turn.");
                                MessageBox.Show("You lose your turn.");
                            }
                            else if (beer + wine + tequila < 0)
                            {
                                MessageBox.Show("Amount must be non negative whole number.");
                                MessageBox.Show("You lose your turn.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a whole number from 0 to 5.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a whole number from 0 to 5.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a whole number from 0 to 5.");
                }
            }
        }

        //The QuagmireTurn method accepts text as
        //an argument.  It assigns the text entered
        //by the user to the object's properties.
        private void QuagmireTurn(Quagmire quagmire)
        {
            //Temporary variables to hold health and 
            //points

            //NOTE: The health scale works where 0 = full health 
            //and 20 = dead

            //Drinking adds to health amount; water, medicine, &
            //transfusion subtract from health amount

            //Quagmire
            int healthQuagmire = 0;
            int pointsQuagmire = 0;
            int healthBeerQuagmire = 0;
            int healthWineQuagmire = 0;
            int healthTequilaQuagmire = 0;
            int pointsBeerQuagmire = 0;
            int pointsWineQuagmire = 0;
            int pointsTequilaQuagmire = 0;
            int totalHealthQuagmire = 0;
            int totalPointsQuagmire = 0;

            //Integer variables for each type of drink
            int beer;
            int wine;
            int tequila;
            int water = 0;


            //Get the player name.
            if (characterEntryTextBox.Text == "Quagmire")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = true;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = false;

                //Get the beer count.
                if (int.TryParse(beerTextBox.Text, out beer))
                {
                    healthBeerQuagmire = healthQuagmire + (1 * beer);                    //cost of 1 unit of health per beer
                    pointsBeerQuagmire = pointsQuagmire + (10 * beer);               //10 points awarded per beer

                    //Get the wine count.
                    if (int.TryParse(wineTextBox.Text, out wine))
                    {
                        healthWineQuagmire = healthQuagmire + (2 * wine);            //cost of 2 units of health per wine
                        pointsWineQuagmire = pointsQuagmire + (15 * wine);           //15 points awarded per wine

                        //Get the tequila count.
                        if (int.TryParse(tequilaTextBox.Text, out tequila))
                        {
                            healthTequilaQuagmire = healthQuagmire + (4 * tequila);         //cost of 4 units of health per tequila
                            pointsTequilaQuagmire = pointsQuagmire + (35 * tequila);        //35 points awarded per tequila

                            //Restrictions on amount of drinks per turn.

                            if ((beer + wine + tequila <= 5) && water < 1 && beer >= 0 && wine >= 0 && tequila >= 0)
                            {
                                //Sum all the drinks (variables).
                                totalHealthQuagmire = healthBeerQuagmire + healthWineQuagmire + healthTequilaQuagmire;

                                totalPointsQuagmire = pointsBeerQuagmire + pointsWineQuagmire + pointsTequilaQuagmire;

                                //Gets the health and points 
                                quagmire.HealthQuagmire = totalHealthQuagmire;
                                quagmire.PointsQuagmire = totalPointsQuagmire;

                                //Consider water for regeneration.
                                if (int.TryParse(waterTextBox.Text, out water))
                                {
                                    //Restriction of 5 drinks of water per turn.
                                    if (water >= 1 && water <= 5)
                                    {
                                        //Set all alcoholic fields and variables to 0.  Water cannot be consumed with alcohol.
                                        beer = 0;
                                        beerTextBox.Text = "0";
                                        wine = 0;
                                        wineTextBox.Text = "0";
                                        tequila = 0;
                                        tequilaTextBox.Text = "0";

                                        //Health regeneration of water. 
                                        totalHealthQuagmire = -(water);    //-1 per unit to general health.
                                        totalPointsQuagmire = water;

                                        //Gets the health and points 
                                        quagmire.HealthQuagmire = totalHealthQuagmire;
                                        quagmire.PointsQuagmire = totalPointsQuagmire;


                                    }
                                    else if (water == 0 || waterTextBox.Text == "")
                                    {
                                        //Sum all the drinks (variables).
                                        totalHealthQuagmire = healthBeerQuagmire + healthWineQuagmire + healthTequilaQuagmire;
                                        totalPointsQuagmire = pointsBeerQuagmire + pointsWineQuagmire + pointsTequilaQuagmire;

                                        //Gets the health and points 
                                        quagmire.HealthQuagmire = totalHealthQuagmire;
                                        quagmire.PointsQuagmire = totalPointsQuagmire;
                                    }
                                    else if (water > 5)
                                    {
                                        MessageBox.Show("Cannot consumer more than 5 drinks of water per turn.");
                                        MessageBox.Show("You lose your turn.");
                                        //Set alcohol fields to 0.
                                        beerTextBox.Text = "0";
                                        beer = 0;
                                        wineTextBox.Text = "0";
                                        wine = 0;
                                        tequilaTextBox.Text = "0";
                                        tequila = 0;
                                        waterTextBox.Text = "0";
                                        water = 0;

                                        //Health regeneration of water. 
                                        totalHealthQuagmire = -(water);    //-1 per unit to general health.
                                        totalPointsQuagmire = water;

                                        //Gets the health and points 
                                        quagmire.HealthQuagmire = totalHealthQuagmire;
                                        quagmire.PointsQuagmire = totalPointsQuagmire;
                                    }
                                    else if (water < 0)
                                    {
                                        MessageBox.Show("Water must be a non negative whole number.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Enter non negative whole number for water.");
                                    MessageBox.Show("You lose your turn.");
                                    //Set alcohol fields to 0.
                                    beerTextBox.Text = "0";
                                    beer = 0;
                                    wineTextBox.Text = "0";
                                    wine = 0;
                                    tequilaTextBox.Text = "0";
                                    tequila = 0;
                                    waterTextBox.Text = "0";
                                    water = 0;

                                    //Health regeneration of water. 
                                    totalHealthQuagmire = -(water);    //-1 per unit to general health.
                                    totalPointsQuagmire = water;

                                    //Gets the health and points 
                                    quagmire.HealthQuagmire = totalHealthQuagmire;
                                    quagmire.PointsQuagmire = totalPointsQuagmire;
                                }
                            }
                            else if (beer + wine + tequila > 5)
                            {
                                MessageBox.Show("you did not do well...cannot drink more than 5 drinks per turn.");
                                MessageBox.Show("You lose your turn.");
                            }
                            else if (beer + wine + tequila < 0)
                            {
                                MessageBox.Show("Amount must be non negative whole number.");
                                MessageBox.Show("You lose your turn.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a whole number from 0 to 5.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a whole number from 0 to 5.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a whole number from 0 to 5.");
                }
            }
        }

        //The JoeTurn method accepts text as
        //an argument.  It assigns the text entered
        //by the user to the object's properties.

        private void JoeTurn(Joe joe)
        {
            //Temporary variables to hold health and 
            //points

            //NOTE: The health scale works where 0 = full health 
            //and 20 = dead

            //Drinking adds to health amount; water, medicine, &
            //transfusion subtract from health amount

            //Joe
            int healthJoe = 0;
            int pointsJoe = 0;
            int healthBeerJoe = 0;
            int healthWineJoe = 0;
            int healthTequilaJoe = 0;
            int pointsBeerJoe = 0;
            int pointsWineJoe = 0;
            int pointsTequilaJoe = 0;
            int totalHealthJoe = 0;
            int totalPointsJoe = 0;

            //Integer variables for each type of drink
            int beer;
            int wine;
            int tequila;
            int water = 0;


            //Get the player name.
            if (characterEntryTextBox.Text == "Joe")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = true;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = false;
                //Get the beer count.
                if (int.TryParse(beerTextBox.Text, out beer))
                {
                    healthBeerJoe = healthJoe + (1 * beer);                    //cost of 1 unit of health per beer
                    pointsBeerJoe = pointsJoe + (10 * beer);               //10 points awarded per beer

                    //Get the wine count.
                    if (int.TryParse(wineTextBox.Text, out wine))
                    {
                        healthWineJoe = healthJoe + (2 * wine);            //cost of 2 units of health per wine
                        pointsWineJoe = pointsJoe + (15 * wine);           //15 points awarded per wine

                        //Get the tequila count.
                        if (int.TryParse(tequilaTextBox.Text, out tequila))
                        {
                            healthTequilaJoe = healthJoe + (4 * tequila);         //cost of 4 units of health per tequila
                            pointsTequilaJoe = pointsJoe + (35 * tequila);        //35 points awarded per tequila

                            //Restrictions on amount of drinks per turn.

                            if ((beer + wine + tequila <= 5) && water < 1 && beer >= 0 && wine >= 0 && tequila >= 0)
                            {
                                //Sum all the drinks (variables).
                                totalHealthJoe = healthBeerJoe + healthWineJoe + healthTequilaJoe;

                                totalPointsJoe = pointsBeerJoe + pointsWineJoe + pointsTequilaJoe;

                                //Gets the health and points 
                                joe.HealthJoe = totalHealthJoe;
                                joe.PointsJoe = totalPointsJoe;

                                //Consider water for regeneration.
                                if (int.TryParse(waterTextBox.Text, out water))
                                {
                                    //Restriction of 5 drinks of water per turn.
                                    if (water >= 1 && water <= 5)
                                    {
                                        //Set all alcoholic fields and variables to 0.  Water cannot be consumed with alcohol.
                                        beer = 0;
                                        beerTextBox.Text = "0";
                                        wine = 0;
                                        wineTextBox.Text = "0";
                                        tequila = 0;
                                        tequilaTextBox.Text = "0";

                                        //Health regeneration of water. 
                                        totalHealthJoe = -(water);    //-1 per unit to general health.
                                        totalPointsJoe = water;

                                        //Gets the health and points 
                                        joe.HealthJoe = totalHealthJoe;
                                        joe.PointsJoe = totalPointsJoe;


                                    }
                                    else if (water == 0 || waterTextBox.Text == "")
                                    {
                                        //Sum all the drinks (variables).
                                        totalHealthJoe = healthBeerJoe + healthWineJoe + healthTequilaJoe;
                                        totalPointsJoe = pointsBeerJoe + pointsWineJoe + pointsTequilaJoe;

                                        //Gets the health and points 
                                        joe.HealthJoe = totalHealthJoe;
                                        joe.PointsJoe = totalPointsJoe;
                                    }
                                    else if (water > 5)
                                    {
                                        MessageBox.Show("Cannot consumer more than 5 drinks of water per turn.");
                                        MessageBox.Show("You lose your turn.");
                                        //Set alcohol fields to 0.
                                        beerTextBox.Text = "0";
                                        beer = 0;
                                        wineTextBox.Text = "0";
                                        wine = 0;
                                        tequilaTextBox.Text = "0";
                                        tequila = 0;
                                        waterTextBox.Text = "0";
                                        water = 0;

                                        //Health regeneration of water. 
                                        totalHealthJoe = -(water);    //-1 per unit to general health.
                                        totalPointsJoe = water;

                                        //Gets the health and points 
                                        joe.HealthJoe = totalHealthJoe;
                                        joe.PointsJoe = totalPointsJoe;
                                    }
                                    else if (water < 0)
                                    {
                                        MessageBox.Show("Water must be a non negative whole number.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Enter non negative whole number for water.");
                                    MessageBox.Show("You lose your turn.");
                                    //Set alcohol fields to 0.
                                    beerTextBox.Text = "0";
                                    beer = 0;
                                    wineTextBox.Text = "0";
                                    wine = 0;
                                    tequilaTextBox.Text = "0";
                                    tequila = 0;
                                    waterTextBox.Text = "0";
                                    water = 0;

                                    //Health regeneration of water. 
                                    totalHealthJoe = -(water);    //-1 per unit to general health.
                                    totalPointsJoe = water;

                                    //Gets the health and points 
                                    joe.HealthJoe = totalHealthJoe;
                                    joe.PointsJoe = totalPointsJoe;
                                }
                            }
                            else if (beer + wine + tequila > 5)
                            {
                                MessageBox.Show("you did not do well...cannot drink more than 5 drinks per turn.");
                                MessageBox.Show("You lose your turn.");
                            }
                            else if (beer + wine + tequila < 0)
                            {
                                MessageBox.Show("Amount must be non negative whole number.");
                                MessageBox.Show("You lose your turn.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a whole number from 0 to 5.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a whole number from 0 to 5.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a whole number from 0 to 5.");
                }
            }
        }

        //The ClevelandTurn method accepts text as
        //an argument.  It assigns the text entered
        //by the user to the object's properties.

        private void ClevelandTurn(Cleveland cleveland)
        {
            //Temporary variables to hold health and 
            //points

            //NOTE: The health scale works where 0 = full health 
            //and 20 = dead

            //Drinking adds to health amount; water, medicine, &
            //transfusion subtract from health amount

            //Joe
            int healthCleveland = 0;
            int pointsCleveland = 0;
            int healthBeerCleveland = 0;
            int healthWineCleveland = 0;
            int healthTequilaCleveland = 0;
            int pointsBeerCleveland = 0;
            int pointsWineCleveland = 0;
            int pointsTequilaCleveland = 0;
            int totalHealthCleveland = 0;
            int totalPointsCleveland = 0;

            //Integer variables for each type of drink
            int beer;
            int wine;
            int tequila;
            int water = 0;


            //Get the player name.
            if (characterEntryTextBox.Text == "Cleveland")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = true;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = false;
                //Get the beer count.
                if (int.TryParse(beerTextBox.Text, out beer))
                {
                    healthBeerCleveland = healthCleveland + (1 * beer);                    //cost of 1 unit of health per beer
                    pointsBeerCleveland = pointsCleveland + (10 * beer);               //10 points awarded per beer

                    //Get the wine count.
                    if (int.TryParse(wineTextBox.Text, out wine))
                    {
                        healthWineCleveland = healthCleveland + (2 * wine);            //cost of 2 units of health per wine
                        pointsWineCleveland = pointsCleveland + (15 * wine);           //15 points awarded per wine

                        //Get the tequila count.
                        if (int.TryParse(tequilaTextBox.Text, out tequila))
                        {
                            healthTequilaCleveland = healthCleveland + (4 * tequila);         //cost of 4 units of health per tequila
                            pointsTequilaCleveland = pointsCleveland + (35 * tequila);        //35 points awarded per tequila

                            //Restrictions on amount of drinks per turn.

                            if ((beer + wine + tequila <= 5) && water < 1 && beer >= 0 && wine >= 0 && tequila >= 0)
                            {
                                //Sum all the drinks (variables).
                                totalHealthCleveland = healthBeerCleveland + healthWineCleveland + healthTequilaCleveland;

                                totalPointsCleveland = pointsBeerCleveland + pointsWineCleveland + pointsTequilaCleveland;

                                //Gets the health and points 
                                cleveland.HealthCleveland = totalHealthCleveland;
                                cleveland.PointsCleveland = totalPointsCleveland;

                                //Consider water for regeneration.
                                if (int.TryParse(waterTextBox.Text, out water))
                                {
                                    //Restriction of 5 drinks of water per turn.
                                    if (water >= 1 && water <= 5)
                                    {
                                        //Set all alcoholic fields and variables to 0.  Water cannot be consumed with alcohol.
                                        beer = 0;
                                        beerTextBox.Text = "0";
                                        wine = 0;
                                        wineTextBox.Text = "0";
                                        tequila = 0;
                                        tequilaTextBox.Text = "0";

                                        //Health regeneration of water. 
                                        totalHealthCleveland = -(water);    //-1 per unit to general health.
                                        totalPointsCleveland = water;

                                        //Gets the health and points 
                                        cleveland.HealthCleveland = totalHealthCleveland;
                                        cleveland.PointsCleveland = totalPointsCleveland;


                                    }
                                    else if (water == 0 || waterTextBox.Text == "")
                                    {
                                        //Sum all the drinks (variables).
                                        totalHealthCleveland = healthBeerCleveland + healthWineCleveland + healthTequilaCleveland;
                                        totalPointsCleveland = pointsBeerCleveland + pointsWineCleveland + pointsTequilaCleveland;

                                        //Gets the health and points 
                                        cleveland.HealthCleveland = totalHealthCleveland;
                                        cleveland.PointsCleveland = totalPointsCleveland;
                                    }
                                    else if (water > 5)
                                    {
                                        MessageBox.Show("Cannot consumer more than 5 drinks of water per turn.");
                                        MessageBox.Show("You lose your turn.");
                                        //Set alcohol fields to 0.
                                        beerTextBox.Text = "0";
                                        beer = 0;
                                        wineTextBox.Text = "0";
                                        wine = 0;
                                        tequilaTextBox.Text = "0";
                                        tequila = 0;
                                        waterTextBox.Text = "0";
                                        water = 0;

                                        //Health regeneration of water. 
                                        totalHealthCleveland = -(water);    //-1 per unit to general health.
                                        totalPointsCleveland = water;

                                        //Gets the health and points 
                                        cleveland.HealthCleveland = totalHealthCleveland;
                                        cleveland.PointsCleveland = totalPointsCleveland;
                                    }
                                    else if (water < 0)
                                    {
                                        MessageBox.Show("Water must be a non negative whole number.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Enter non negative whole number for water.");
                                    MessageBox.Show("You lose your turn.");
                                    //Set alcohol fields to 0.
                                    beerTextBox.Text = "0";
                                    beer = 0;
                                    wineTextBox.Text = "0";
                                    wine = 0;
                                    tequilaTextBox.Text = "0";
                                    tequila = 0;
                                    waterTextBox.Text = "0";
                                    water = 0;

                                    //Health regeneration of water. 
                                    totalHealthCleveland = -(water);    //-1 per unit to general health.
                                    totalPointsCleveland = water;

                                    //Gets the health and points 
                                    cleveland.HealthCleveland = totalHealthCleveland;
                                    cleveland.PointsCleveland = totalPointsCleveland;
                                }
                            }
                            else if (beer + wine + tequila > 5)
                            {
                                MessageBox.Show("you did not do well...cannot drink more than 5 drinks per turn.");
                                MessageBox.Show("You lose your turn.");
                            }
                            else if (beer + wine + tequila < 0)
                            {
                                MessageBox.Show("Amount must be non negative whole number.");
                                MessageBox.Show("You lose your turn.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a whole number from 0 to 5.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a whole number from 0 to 5.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a whole number from 0 to 5.");
                }
            }



        }

        //The BrianTurn method accepts text as
        //an argument.  It assigns the text entered
        //by the user to the object's properties.

        private void BrianTurn(Brian brian)
        {
            //Temporary variables to hold health and 
            //points

            //NOTE: The health scale works where 0 = full health 
            //and 20 = dead

            //Drinking adds to health amount; water, medicine, &
            //transfusion subtract from health amount

            //Joe
            int healthBrian = 0;
            int pointsBrian = 0;
            int healthBeerBrian = 0;
            int healthWineBrian = 0;
            int healthTequilaBrian = 0;
            int pointsBeerBrian = 0;
            int pointsWineBrian = 0;
            int pointsTequilaBrian = 0;
            int totalHealthBrian = 0;
            int totalPointsBrian = 0;

            //Integer variables for each type of drink
            int beer;
            int wine;
            int tequila;
            int water = 0;


            //Get the player name.
            if (characterEntryTextBox.Text == "Brian")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = true;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = false;
                //Get the beer count.
                if (int.TryParse(beerTextBox.Text, out beer))
                {
                    healthBeerBrian = healthBrian + (1 * beer);                    //cost of 1 unit of health per beer
                    pointsBeerBrian = pointsBrian + (10 * beer);               //10 points awarded per beer

                    //Get the wine count.
                    if (int.TryParse(wineTextBox.Text, out wine))
                    {
                        healthWineBrian = healthBrian + (2 * wine);            //cost of 2 units of health per wine
                        pointsWineBrian = pointsBrian + (15 * wine);           //15 points awarded per wine

                        //Get the tequila count.
                        if (int.TryParse(tequilaTextBox.Text, out tequila))
                        {
                            healthTequilaBrian = healthBrian + (4 * tequila);         //cost of 4 units of health per tequila
                            pointsTequilaBrian = pointsBrian + (35 * tequila);        //35 points awarded per tequila

                            //Restrictions on amount of drinks per turn.

                            if ((beer + wine + tequila <= 5) && water < 1 && beer >= 0 && wine >= 0 && tequila >= 0)
                            {
                                //Sum all the drinks (variables).
                                totalHealthBrian = healthBeerBrian + healthWineBrian + healthTequilaBrian;

                                totalPointsBrian = pointsBeerBrian + pointsWineBrian + pointsTequilaBrian;

                                //Gets the health and points 
                                brian.HealthBrian = totalHealthBrian;
                                brian.PointsBrian = totalPointsBrian;

                                //Consider water for regeneration.
                                if (int.TryParse(waterTextBox.Text, out water))
                                {
                                    //Restriction of 5 drinks of water per turn.
                                    if (water >= 1 && water <= 5)
                                    {
                                        //Set all alcoholic fields and variables to 0.  Water cannot be consumed with alcohol.
                                        beer = 0;
                                        beerTextBox.Text = "0";
                                        wine = 0;
                                        wineTextBox.Text = "0";
                                        tequila = 0;
                                        tequilaTextBox.Text = "0";

                                        //Health regeneration of water. 
                                        totalHealthBrian = -(water);    //-1 per unit to general health.
                                        totalPointsBrian = water;

                                        //Gets the health and points 
                                        brian.HealthBrian = totalHealthBrian;
                                        brian.PointsBrian = totalPointsBrian;


                                    }
                                    else if (water == 0 || waterTextBox.Text == "")
                                    {
                                        //Sum all the drinks (variables).
                                        totalHealthBrian = healthBeerBrian + healthWineBrian + healthTequilaBrian;
                                        totalPointsBrian = pointsBeerBrian + pointsWineBrian + pointsTequilaBrian;

                                        //Gets the health and points 
                                        brian.HealthBrian = totalHealthBrian;
                                        brian.PointsBrian = totalPointsBrian;
                                    }
                                    else if (water > 5)
                                    {
                                        MessageBox.Show("Cannot consumer more than 5 drinks of water per turn.");
                                        MessageBox.Show("You lose your turn.");
                                        //Set alcohol fields to 0.
                                        beerTextBox.Text = "0";
                                        beer = 0;
                                        wineTextBox.Text = "0";
                                        wine = 0;
                                        tequilaTextBox.Text = "0";
                                        tequila = 0;
                                        waterTextBox.Text = "0";
                                        water = 0;

                                        //Health regeneration of water. 
                                        totalHealthBrian = -(water);    //-1 per unit to general health.
                                        totalPointsBrian = water;

                                        //Gets the health and points 
                                        brian.HealthBrian = totalHealthBrian;
                                        brian.PointsBrian = totalPointsBrian;
                                    }
                                    else if (water < 0)
                                    {
                                        MessageBox.Show("Water must be a non negative whole number.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Enter non negative whole number for water.");
                                    MessageBox.Show("You lose your turn.");
                                    //Set alcohol fields to 0.
                                    beerTextBox.Text = "0";
                                    beer = 0;
                                    wineTextBox.Text = "0";
                                    wine = 0;
                                    tequilaTextBox.Text = "0";
                                    tequila = 0;
                                    waterTextBox.Text = "0";
                                    water = 0;

                                    //Health regeneration of water. 
                                    totalHealthBrian = -(water);    //-1 per unit to general health.
                                    totalPointsBrian = water;

                                    //Gets the health and points 
                                    brian.HealthBrian = totalHealthBrian;
                                    brian.PointsBrian = totalPointsBrian;
                                }
                            }
                            else if (beer + wine + tequila > 5)
                            {
                                MessageBox.Show("you did not do well...cannot drink more than 5 drinks per turn.");
                                MessageBox.Show("You lose your turn.");
                            }
                            else if (beer + wine + tequila < 0)
                            {
                                MessageBox.Show("Amount must be non negative whole number.");
                                MessageBox.Show("You lose your turn.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a whole number from 0 to 5.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a whole number from 0 to 5.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a whole number from 0 to 5.");
                }
            }
        }

        //The HoraceTurn method accepts text as
        //an argument.  It assigns the text entered
        //by the user to the object's properties.

        private void HoraceTurn(Horace horace)
        {
            //Temporary variables to hold health and 
            //points

            //NOTE: The health scale works where 0 = full health 
            //and 20 = dead

            //Drinking adds to health amount; water, medicine, &
            //transfusion subtract from health amount

            //Joe
            int healthHorace = 0;
            int pointsHorace = 0;
            int healthBeerHorace = 0;
            int healthWineHorace = 0;
            int healthTequilaHorace = 0;
            int pointsBeerHorace = 0;
            int pointsWineHorace = 0;
            int pointsTequilaHorace = 0;
            int totalHealthHorace = 0;
            int totalPointsHorace = 0;

            //Integer variables for each type of drink
            int beer;
            int wine;
            int tequila;
            int water = 0;


            //Get the player name.
            if (characterEntryTextBox.Text == "Horace")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = true;
                jeromePictureBox.Visible = false;
                //Get the beer count.
                if (int.TryParse(beerTextBox.Text, out beer))
                {
                    healthBeerHorace = healthHorace + (1 * beer);                    //cost of 1 unit of health per beer
                    pointsBeerHorace = pointsHorace + (10 * beer);               //10 points awarded per beer

                    //Get the wine count.
                    if (int.TryParse(wineTextBox.Text, out wine))
                    {
                        healthWineHorace = healthHorace + (2 * wine);            //cost of 2 units of health per wine
                        pointsWineHorace = pointsHorace + (15 * wine);           //15 points awarded per wine

                        //Get the tequila count.
                        if (int.TryParse(tequilaTextBox.Text, out tequila))
                        {
                            healthTequilaHorace = healthHorace + (4 * tequila);         //cost of 4 units of health per tequila
                            pointsTequilaHorace = pointsHorace + (35 * tequila);        //35 points awarded per tequila

                            //Restrictions on amount of drinks per turn.

                            if ((beer + wine + tequila <= 5) && water < 1 && beer >= 0 && wine >= 0 && tequila >= 0)
                            {
                                //Sum all the drinks (variables).
                                totalHealthHorace = healthBeerHorace + healthWineHorace + healthTequilaHorace;

                                totalPointsHorace = pointsBeerHorace + pointsWineHorace + pointsTequilaHorace;

                                //Gets the health and points 
                                horace.HealthHorace = totalHealthHorace;
                                horace.PointsHorace = totalPointsHorace;

                                //Consider water for regeneration.
                                if (int.TryParse(waterTextBox.Text, out water))
                                {
                                    //Restriction of 5 drinks of water per turn.
                                    if (water >= 1 && water <= 5)
                                    {
                                        //Set all alcoholic fields and variables to 0.  Water cannot be consumed with alcohol.
                                        beer = 0;
                                        beerTextBox.Text = "0";
                                        wine = 0;
                                        wineTextBox.Text = "0";
                                        tequila = 0;
                                        tequilaTextBox.Text = "0";

                                        //Health regeneration of water. 
                                        totalHealthHorace = -(water);    //-1 per unit to general health.
                                        totalPointsHorace = water;

                                        //Gets the health and points 
                                        horace.HealthHorace = totalHealthHorace;
                                        horace.PointsHorace = totalPointsHorace;


                                    }
                                    else if (water == 0 || waterTextBox.Text == "")
                                    {
                                        //Sum all the drinks (variables).
                                        totalHealthHorace = healthBeerHorace + healthWineHorace + healthTequilaHorace;
                                        totalPointsHorace = pointsBeerHorace + pointsWineHorace + pointsTequilaHorace;

                                        //Gets the health and points 
                                        horace.HealthHorace = totalHealthHorace;
                                        horace.PointsHorace = totalPointsHorace;
                                    }
                                    else if (water > 5)
                                    {
                                        MessageBox.Show("Cannot consumer more than 5 drinks of water per turn.");
                                        MessageBox.Show("You lose your turn.");
                                        //Set alcohol fields to 0.
                                        beerTextBox.Text = "0";
                                        beer = 0;
                                        wineTextBox.Text = "0";
                                        wine = 0;
                                        tequilaTextBox.Text = "0";
                                        tequila = 0;
                                        waterTextBox.Text = "0";
                                        water = 0;

                                        //Health regeneration of water. 
                                        totalHealthHorace = -(water);    //-1 per unit to general health.
                                        totalPointsHorace = water;

                                        //Gets the health and points 
                                        horace.HealthHorace = totalHealthHorace;
                                        horace.PointsHorace = totalPointsHorace;
                                    }
                                    else if (water < 0)
                                    {
                                        MessageBox.Show("Water must be a non negative whole number.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Enter non negative whole number for water.");
                                    MessageBox.Show("You lose your turn.");
                                    //Set alcohol fields to 0.
                                    beerTextBox.Text = "0";
                                    beer = 0;
                                    wineTextBox.Text = "0";
                                    wine = 0;
                                    tequilaTextBox.Text = "0";
                                    tequila = 0;
                                    waterTextBox.Text = "0";
                                    water = 0;

                                    //Health regeneration of water. 
                                    totalHealthHorace = -(water);    //-1 per unit to general health.
                                    totalPointsHorace = water;

                                    //Gets the health and points 
                                    horace.HealthHorace = totalHealthHorace;
                                    horace.PointsHorace = totalPointsHorace;
                                }
                            }
                            else if (beer + wine + tequila > 5)
                            {
                                MessageBox.Show("you did not do well...cannot drink more than 5 drinks per turn.");
                                MessageBox.Show("You lose your turn.");
                            }
                            else if (beer + wine + tequila < 0)
                            {
                                MessageBox.Show("Amount must be non negative whole number.");
                                MessageBox.Show("You lose your turn.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a whole number from 0 to 5.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a whole number from 0 to 5.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a whole number from 0 to 5.");
                }
            }
        }


        //The JeromeTurn method accepts text as
        //an argument.  It assigns the text entered
        //by the user to the object's properties.

        private void JeromeTurn(Jerome jerome)
        {
            //Temporary variables to hold health and 
            //points

            //NOTE: The health scale works where 0 = full health 
            //and 20 = dead

            //Drinking adds to health amount; water, medicine, &
            //transfusion subtract from health amount

            //Joe
            int healthJerome = 0;
            int pointsJerome = 0;
            int healthBeerJerome = 0;
            int healthWineJerome = 0;
            int healthTequilaJerome = 0;
            int pointsBeerJerome = 0;
            int pointsWineJerome = 0;
            int pointsTequilaJerome = 0;
            int totalHealthJerome = 0;
            int totalPointsJerome = 0;

            //Integer variables for each type of drink
            int beer;
            int wine;
            int tequila;
            int water = 0;


            //Get the player name.
            if (characterEntryTextBox.Text == "Jerome")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = true;
                //Get the beer count.
                if (int.TryParse(beerTextBox.Text, out beer))
                {
                    healthBeerJerome = healthJerome + (1 * beer);                    //cost of 1 unit of health per beer
                    pointsBeerJerome = pointsJerome + (10 * beer);               //10 points awarded per beer

                    //Get the wine count.
                    if (int.TryParse(wineTextBox.Text, out wine))
                    {
                        healthWineJerome = healthJerome + (2 * wine);            //cost of 2 units of health per wine
                        pointsWineJerome = pointsJerome + (15 * wine);           //15 points awarded per wine

                        //Get the tequila count.
                        if (int.TryParse(tequilaTextBox.Text, out tequila))
                        {
                            healthTequilaJerome = healthJerome + (4 * tequila);         //cost of 4 units of health per tequila
                            pointsTequilaJerome = pointsJerome + (35 * tequila);        //35 points awarded per tequila

                            //Restrictions on amount of drinks per turn.

                            if ((beer + wine + tequila <= 5) && water < 1 && beer >= 0 && wine >= 0 && tequila >= 0)
                            {
                                //Sum all the drinks (variables).
                                totalHealthJerome = healthBeerJerome + healthWineJerome + healthTequilaJerome;

                                totalPointsJerome = pointsBeerJerome + pointsWineJerome + pointsTequilaJerome;

                                //Gets the health and points 
                                jerome.HealthJerome = totalHealthJerome;
                                jerome.PointsJerome = totalPointsJerome;

                                //Consider water for regeneration.
                                if (int.TryParse(waterTextBox.Text, out water))
                                {
                                    //Restriction of 5 drinks of water per turn.
                                    if (water >= 1 && water <= 5)
                                    {
                                        //Set all alcoholic fields and variables to 0.  Water cannot be consumed with alcohol.
                                        beer = 0;
                                        beerTextBox.Text = "0";
                                        wine = 0;
                                        wineTextBox.Text = "0";
                                        tequila = 0;
                                        tequilaTextBox.Text = "0";

                                        //Health regeneration of water. 
                                        totalHealthJerome = -(water);    //-1 per unit to general health.
                                        totalPointsJerome = water;

                                        //Gets the health and points 
                                        jerome.HealthJerome = totalHealthJerome;
                                        jerome.PointsJerome = totalPointsJerome;


                                    }
                                    else if (water == 0 || waterTextBox.Text == "")
                                    {
                                        //Sum all the drinks (variables).
                                        totalHealthJerome = healthBeerJerome + healthWineJerome + healthTequilaJerome;
                                        totalPointsJerome = pointsBeerJerome + pointsWineJerome + pointsTequilaJerome;

                                        //Gets the health and points 
                                        jerome.HealthJerome = totalHealthJerome;
                                        jerome.PointsJerome = totalPointsJerome;
                                    }
                                    else if (water > 5)
                                    {
                                        MessageBox.Show("Cannot consumer more than 5 drinks of water per turn.");
                                        MessageBox.Show("You lose your turn.");
                                        //Set alcohol fields to 0.
                                        beerTextBox.Text = "0";
                                        beer = 0;
                                        wineTextBox.Text = "0";
                                        wine = 0;
                                        tequilaTextBox.Text = "0";
                                        tequila = 0;
                                        waterTextBox.Text = "0";
                                        water = 0;

                                        //Health regeneration of water. 
                                        totalHealthJerome = -(water);    //-1 per unit to general health.
                                        totalPointsJerome = water;

                                        //Gets the health and points 
                                        jerome.HealthJerome = totalHealthJerome;
                                        jerome.PointsJerome = totalPointsJerome;
                                    }
                                    else if (water < 0)
                                    {
                                        MessageBox.Show("Water must be a non negative whole number.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Enter non negative whole number for water.");
                                    MessageBox.Show("You lose your turn.");
                                    //Set alcohol fields to 0.
                                    beerTextBox.Text = "0";
                                    beer = 0;
                                    wineTextBox.Text = "0";
                                    wine = 0;
                                    tequilaTextBox.Text = "0";
                                    tequila = 0;
                                    waterTextBox.Text = "0";
                                    water = 0;

                                    //Health regeneration of water. 
                                    totalHealthJerome = -(water);    //-1 per unit to general health.
                                    totalPointsJerome = water;

                                    //Gets the health and points 
                                    jerome.HealthJerome = totalHealthJerome;
                                    jerome.PointsJerome = totalPointsJerome;
                                }
                            }
                            else if (beer + wine + tequila > 5)
                            {
                                MessageBox.Show("you did not do well...cannot drink more than 5 drinks per turn.");
                                MessageBox.Show("You lose your turn.");
                            }
                            else if (beer + wine + tequila < 0)
                            {
                                MessageBox.Show("Amount must be non negative whole number.");
                                MessageBox.Show("You lose your turn.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a whole number from 0 to 5.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a whole number from 0 to 5.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a whole number from 0 to 5.");
                }
            }
        }

 //Arrays for each player

        
        //Peter
        //Array to hold points for each turn for Peter
        const int PETER_SIZE = 15;                  //limit to 15 turns
        int[] peter_points = new int[PETER_SIZE];   //Array of points
        int peter_index = 0;                        //Loop counter
        int peter_total = 0;                        //To hold total of points

        //Array to hold health for each turn for Peter
        const int PETER_SIZEE = 15;                 //limit to 15 turns
        int[] peter_health = new int[PETER_SIZEE];  //Array of health
        int peter_totalHealth = 0;                  //To hold total of initial health


        //Quagmire
        //Array to hold points for each turn for Quagmire
        const int QUAGMIRE_SIZE = 15;                  //limit to 15 turns
        int[] quagmire_points = new int[QUAGMIRE_SIZE];   //Array of points
        int quagmire_index = 0;                        //Loop counter
        int quagmire_total = 0;                        //To hold total of points

        //Array to hold health for each turn for Quagmire
        const int QUAGMIRE_SIZEE = 15;                 //limit to 15 turns
        int[] quagmire_health = new int[QUAGMIRE_SIZEE];  //Array of health
        int quagmire_totalHealth = 0;                  //To hold total of initial health

        //Joe
        //Array to hold points for each turn for Joe
        const int JOE_SIZE = 15;                  //limit to 15 turns
        int[] joe_points = new int[JOE_SIZE];   //Array of points
        int joe_index = 0;                        //Loop counter
        int joe_total = 0;                        //To hold total of points

        //Array to hold health for each turn for Joe
        const int JOE_SIZEE = 15;                 //limit to 15 turns
        int[] joe_health = new int[JOE_SIZEE];  //Array of health
        int joe_totalHealth = 0;                  //To hold total of initial health


        //Cleveland
        //Array to hold points for each turn for Cleveland
        const int CLEVELAND_SIZE = 15;                  //limit to 15 turns
        int[] cleveland_points = new int[CLEVELAND_SIZE];   //Array of points
        int cleveland_index = 0;                        //Loop counter
        int cleveland_total = 0;                        //To hold total of points

        //Array to hold health for each turn for Cleveland
        const int CLEVELAND_SIZEE = 15;                 //limit to 15 turns
        int[] cleveland_health = new int[CLEVELAND_SIZEE];  //Array of health
        int cleveland_totalHealth = 0;                  //To hold total of initial health


        //Brian
        //Array to hold points for each turn for Brian
        const int BRIAN_SIZE = 15;                  //limit to 15 turns
        int[] brian_points = new int[BRIAN_SIZE];   //Array of points
        int brian_index = 0;                        //Loop counter
        int brian_total = 0;                        //To hold total of points

        //Array to hold health for each turn for Brian
        const int BRIAN_SIZEE = 15;                 //limit to 15 turns
        int[] brian_health = new int[BRIAN_SIZEE];  //Array of health
        int brian_totalHealth = 0;                  //To hold total of initial health


        //Horace
        //Array to hold points for each turn for Horace
        const int HORACE_SIZE = 15;                  //limit to 15 turns
        int[] horace_points = new int[HORACE_SIZE];   //Array of points
        int horace_index = 0;                        //Loop counter
        int horace_total = 0;                        //To hold total of points

        //Array to hold health for each turn for Horace
        const int HORACE_SIZEE = 15;                 //limit to 15 turns
        int[] horace_health = new int[HORACE_SIZEE];  //Array of health
        int horace_totalHealth = 0;                  //To hold total of initial health


        //Jerome
        //Array to hold points for each turn for Jerome
        const int JEROME_SIZE = 15;                  //limit to 15 turns
        int[] jerome_points = new int[JEROME_SIZE];   //Array of points
        int jerome_index = 0;                        //Loop counter
        int jerome_total = 0;                        //To hold total of points

        //Array to hold health for each turn for Jerome
        const int JEROME_SIZEE = 15;                 //limit to 15 turns
        int[] jerome_health = new int[JEROME_SIZEE];  //Array of health
        int jerome_totalHealth = 0;                  //To hold total of initial health





        //Player's respective turns.  Consider adding unique qualities 
        //for each character.
        private void completeTurnButton_Click(object sender, EventArgs e)
        {
            //Peter's turn

            if (characterEntryTextBox.Text == "Peter")
            {
                peterPictureBox.Visible = true;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = false;

                
                //Create a Peter object
                Peter myPeter = new Peter();

                //Get the Peter data
                PeterTurn(myPeter);

                //Display the Peter turn points data.
                peterPointsLabel.Text = myPeter.PointsPeter.ToString("d");

                //Display the Peter turn health data. 
                healthPeterLabel.Text = myPeter.HealthPeter.ToString("d");


                //keep track of each turn

                //Input the points into the array
                if (peter_index <= 14)       //index of 0-14(15 turns)
                {
                    //Bring in values to points array.
                    peter_points[peter_index] = int.Parse(peterPointsLabel.Text);

                    //Bring in values to health array.
                    peter_health[peter_index] = int.Parse(healthPeterLabel.Text);
                    peter_index++;


                    //Display the points values.

                    scoreListBox.Items.Clear();         //Prevents duplication of the points list
                    healthListBox.Items.Clear();        //Prevents duplication of the health list
                    peter_total = 0;                    //Resets total to 0
                    peter_totalHealth = 0;              //Resets totalHealth to 0
                    int value = 0;
                    int valuee = 0;

                    for (int row = 0; row < peter_points.Length; row++)
                    {
                        //Putting loop into play for points
                        value = peter_points[row];
                        scoreListBox.Items.Add(value);

                        //Putting loop into play for health
                        valuee = peter_health[row];
                        healthListBox.Items.Add(valuee);

                        //Get the total points.
                        peter_total += value;

                        //Get the total health.
                        peter_totalHealth += valuee;
                    }

                    //Display the Peter turn points data.
                    peterPointsLabel.Text = peter_total.ToString("d");
                    MessageBox.Show("The total is " + peter_total.ToString("d"));

                    //Display the Peter turn health data.
                    healthPeterLabel.Text = peter_totalHealth.ToString("d");


                    //Health warnings for each level.

                    //Ok
                    if (peter_totalHealth < 5)
                    {
                        MessageBox.Show("You are fine.....for NOW.  Ha ha ha!");
                        healthPeterLabel.BackColor = System.Drawing.Color.Green;
                    }

                    //Tipsy
                    else if (peter_totalHealth < 10 && peter_totalHealth >= 5)
                    {
                        MessageBox.Show("You are tipsy.");
                        healthPeterLabel.BackColor = System.Drawing.Color.YellowGreen;
                    }

                    //Drunk
                    else if (peter_totalHealth < 15 && peter_totalHealth >= 10)
                    {
                        MessageBox.Show("You are drunk.  Go easy on the booze.");
                        healthPeterLabel.BackColor = System.Drawing.Color.Yellow; 
                    }

                    //Hospital
                    else if (peter_totalHealth < 20 && peter_totalHealth >= 15)
                    {
                        MessageBox.Show("You are almost dead.");
                        healthPeterLabel.BackColor = System.Drawing.Color.Orange;
                    }

                    //Dead
                    else if (peter_totalHealth >= 20)
                    {
                        MessageBox.Show("Game over, Peter. YOU ARE DEAD!!!!");
                        peterPointsLabel.Text = "DEAD";
                        healthPeterLabel.Text = "DEAD";
                        healthPeterLabel.BackColor = System.Drawing.Color.Red;
                        peterButton.Visible = false;
                    }

                    //Set the winning condition for points
                    if (peter_total >= 300 && peter_totalHealth < 10)
                    {
                        peterPointsLabel.Text = peter_total.ToString("d");
                        MessageBox.Show("Congrats, Peter.  You won the game.");
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Amount of available turns has been used.  Game over.");
                }
            }



            //Quagmire's turn

            else if (characterEntryTextBox.Text == "Quagmire")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = true;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = false;
                //Create a Quagmire object
                Quagmire myQuagmire = new Quagmire();

                //Get the Quagmire data
                QuagmireTurn(myQuagmire);

                //Display the Quagmire turn points data.
                quagmirePointsLabel.Text = myQuagmire.PointsQuagmire.ToString("d");

                //Display the Quagmire turn health data. 
                quagmireHealthLabel.Text = myQuagmire.HealthQuagmire.ToString("d");


                //keep track of each turn

                //Input the points into the array
                if (quagmire_index <= 14)       //index of 0-14(15 turns)
                {
                    //Bring in values to points array.
                    quagmire_points[quagmire_index] = int.Parse(quagmirePointsLabel.Text);

                    //Bring in values to health array.
                    quagmire_health[quagmire_index] = int.Parse(quagmireHealthLabel.Text);
                    quagmire_index++;


                    //Display the points values.

                    scoreListBox.Items.Clear();         //Prevents duplication of the points list
                    healthListBox.Items.Clear();        //Prevents duplication of the health list
                    quagmire_total = 0;                          //Resets total to 0
                    quagmire_totalHealth = 0;                    //Resets totalHealth to 0
                    int value = 0;
                    int valuee = 0;

                    for (int row = 0; row < quagmire_points.Length; row++)
                    {
                        //Putting loop into play for points
                        value = quagmire_points[row];
                        scoreListBox.Items.Add(value);

                        //Putting loop into play for health
                        valuee = quagmire_health[row];
                        healthListBox.Items.Add(valuee);

                        //Get the total points.
                        quagmire_total += value;

                        //Get the total health.
                        quagmire_totalHealth += valuee;
                    }

                    //Display the Quagmire turn points data.
                    quagmirePointsLabel.Text = quagmire_total.ToString("d");
                    MessageBox.Show("The total is " + quagmire_total.ToString("d"));

                    //Display the Quagmire turn health data.
                    quagmireHealthLabel.Text = quagmire_totalHealth.ToString("d");


                    //Health warnings for each level.

                    //Ok
                    if (quagmire_totalHealth < 5)
                    {
                        MessageBox.Show("You are fine.....for NOW.  Ha ha ha!");
                        quagmireHealthLabel.BackColor = System.Drawing.Color.Green;
                    }

                    //Tipsy
                    else if (quagmire_totalHealth < 10 && quagmire_totalHealth >= 5)
                    {
                        MessageBox.Show("You are tipsy.");
                        quagmireHealthLabel.BackColor = System.Drawing.Color.YellowGreen;
                    }

                    //Drunk
                    else if (quagmire_totalHealth < 15 && quagmire_totalHealth >= 10)
                    {
                        MessageBox.Show("You are drunk.  Go easy on the booze.");
                        quagmireHealthLabel.BackColor = System.Drawing.Color.Yellow;
                    }

                    //Hospital
                    else if (quagmire_totalHealth < 20 && quagmire_totalHealth >= 15)
                    {
                        MessageBox.Show("You are almost dead.");
                        quagmireHealthLabel.BackColor = System.Drawing.Color.Orange;
                    }

                    //Dead
                    else if (quagmire_totalHealth >= 20)
                    {
                        MessageBox.Show("Game over, Quagmire.  YOU ARE DEAD!!!!");
                        quagmirePointsLabel.Text = "DEAD";
                        quagmireHealthLabel.Text = "DEAD";
                        quagmireHealthLabel.BackColor = System.Drawing.Color.Red;
                        quagmireButton.Visible = false;
                    }

                    //Set the winning condition for points
                    if (quagmire_total >= 300 && quagmire_totalHealth < 10)
                    {
                        quagmirePointsLabel.Text = quagmire_total.ToString("d");
                        MessageBox.Show("Congrats, Quagmire.  You won the game.");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Amount of available turns has been used.  Game over.");
                }
            }



            //Joe's turn

            else if (characterEntryTextBox.Text == "Joe")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = true;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = false;
                //Create a Joe object
                Joe myJoe = new Joe();

                //Get the Joe data
                JoeTurn(myJoe);

                //Display the Joe turn points data.
                joePointsLabel.Text = myJoe.PointsJoe.ToString("d");

                //Display the Joe turn health data. 
                JoeHealthLabel.Text = myJoe.HealthJoe.ToString("d");


                //keep track of each turn

                //Input the points into the array
                if (joe_index <= 14)       //index of 0-14(15 turns)
                {
                    //Bring in values to points array.
                    joe_points[joe_index] = int.Parse(joePointsLabel.Text);

                    //Bring in values to health array.
                    joe_health[joe_index] = int.Parse(JoeHealthLabel.Text);

                    //Increment the index counter.
                    joe_index++;


                    //Display the points values.

                    scoreListBox.Items.Clear();         //Prevents duplication of the points list
                    healthListBox.Items.Clear();        //Prevents duplication of the health list
                    joe_total = 0;                          //Resets total to 0
                    joe_totalHealth = 0;                    //Resets totalHealth to 0
                    int value = 0;
                    int valuee = 0;

                    for (int row = 0; row < joe_points.Length; row++)
                    {
                        //Putting loop into play for points
                        value = joe_points[row];
                        scoreListBox.Items.Add(value);

                        //Putting loop into play for health
                        valuee = joe_health[row];
                        healthListBox.Items.Add(valuee);

                        //Get the total points.
                        joe_total += value;

                        //Get the total health.
                        joe_totalHealth += valuee;
                    }

                    //Display the Joe turn points data.
                    joePointsLabel.Text = joe_total.ToString("d");
                    MessageBox.Show("The total is " + joe_total.ToString("d"));

                    //Display the Joe turn health data.
                    JoeHealthLabel.Text = joe_totalHealth.ToString("d");


                    //Health warnings for each level.

                    //Ok
                    if (joe_totalHealth < 5)
                    {
                        MessageBox.Show("You are fine.....for NOW.  Ha ha ha!");
                        JoeHealthLabel.BackColor = System.Drawing.Color.Green;
                    }

                    //Tipsy
                    else if (joe_totalHealth < 10 && joe_totalHealth >= 5)
                    {
                        MessageBox.Show("You are tipsy.");
                        JoeHealthLabel.BackColor = System.Drawing.Color.YellowGreen;
                    }

                    //Drunk
                    else if (joe_totalHealth < 15 && joe_totalHealth >= 10)
                    {
                        MessageBox.Show("You are drunk.  Go easy on the booze.");
                        JoeHealthLabel.BackColor = System.Drawing.Color.Yellow;
                    }

                    //Hospital
                    else if (joe_totalHealth < 20 && joe_totalHealth >= 15)
                    {
                        MessageBox.Show("You are almost dead.");
                        JoeHealthLabel.BackColor = System.Drawing.Color.Orange;
                    }

                    //Dead
                    else if (joe_totalHealth >= 20)
                    {
                        MessageBox.Show("Game over, Joe.  YOU ARE DEAD!!!!");
                        joePointsLabel.Text = "DEAD";
                        JoeHealthLabel.Text = "DEAD";
                        JoeHealthLabel.BackColor = System.Drawing.Color.Red;
                        joeButton.Visible = false;
                    }

                    //Set the winning condition for points
                    if (joe_total >= 300 && joe_totalHealth < 10)
                    {
                        joePointsLabel.Text = joe_total.ToString("d");
                        MessageBox.Show("Congrats, Joe.  You won the game.");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Amount of available turns has been used.  Game over.");
                }
            }

            //Cleveland's turn

            else if (characterEntryTextBox.Text == "Cleveland")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = true;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = false;
                //Create a Cleveland object
                Cleveland myCleveland = new Cleveland();

                //Get the Cleveland data
                ClevelandTurn(myCleveland);

                //Display the Cleveland turn points data.
                clevelandPointsLabel.Text = myCleveland.PointsCleveland.ToString("d");

                //Display the Cleveland turn health data. 
                ClevelandHealthLabel.Text = myCleveland.HealthCleveland.ToString("d");


                //keep track of each turn

                //Input the points into the array
                if (cleveland_index <= 14)       //index of 0-14(15 turns)
                {
                    //Bring in values to points array.
                    cleveland_points[cleveland_index] = int.Parse(clevelandPointsLabel.Text);

                    //Bring in values to health array.
                    cleveland_health[cleveland_index] = int.Parse(ClevelandHealthLabel.Text);
                    cleveland_index++;


                    //Display the points values.

                    scoreListBox.Items.Clear();         //Prevents duplication of the points list
                    healthListBox.Items.Clear();        //Prevents duplication of the health list
                    cleveland_total = 0;                          //Resets total to 0
                    cleveland_totalHealth = 0;                    //Resets totalHealth to 0
                    int value = 0;
                    int valuee = 0;

                    for (int row = 0; row < cleveland_points.Length; row++)
                    {
                        //Putting loop into play for points
                        value = cleveland_points[row];
                        scoreListBox.Items.Add(value);

                        //Putting loop into play for health
                        valuee = cleveland_health[row];
                        healthListBox.Items.Add(valuee);

                        //Get the total points.
                        cleveland_total += value;

                        //Get the total health.
                        cleveland_totalHealth += valuee;
                    }

                    //Display the Cleveland turn points data.
                    clevelandPointsLabel.Text = cleveland_total.ToString("d");
                    MessageBox.Show("The total is " + cleveland_total.ToString("d"));

                    //Display the Cleveland turn health data.
                    ClevelandHealthLabel.Text = cleveland_totalHealth.ToString("d");


                    //Health warnings for each level.

                    //Ok
                    if (cleveland_totalHealth < 5)
                    {
                        MessageBox.Show("You are fine.....for NOW.  Ha ha ha!");
                        ClevelandHealthLabel.BackColor = System.Drawing.Color.Green;
                    }

                    //Tipsy
                    else if (cleveland_totalHealth < 10 && cleveland_totalHealth >= 5)
                    {
                        MessageBox.Show("You are tipsy.");
                        ClevelandHealthLabel.BackColor = System.Drawing.Color.YellowGreen;
                    }

                    //Drunk
                    else if (cleveland_totalHealth < 15 && cleveland_totalHealth >= 10)
                    {
                        MessageBox.Show("You are drunk.  Go easy on the booze.");
                        ClevelandHealthLabel.BackColor = System.Drawing.Color.Yellow;
                    }

                    //Hospital
                    else if (cleveland_totalHealth < 20 && cleveland_totalHealth >= 15)
                    {
                        MessageBox.Show("You are almost dead.");
                        ClevelandHealthLabel.BackColor = System.Drawing.Color.Orange;
                    }

                    //Dead
                    else if (cleveland_totalHealth >= 20)
                    {
                        MessageBox.Show("Game over, Cleveland.  YOU ARE DEAD!!!!");
                        clevelandPointsLabel.Text = "DEAD";
                        ClevelandHealthLabel.Text = "DEAD";
                        ClevelandHealthLabel.BackColor = System.Drawing.Color.Red;
                        clevelandButton.Visible = false;
                    }

                    //Set the winning condition for points
                    if (cleveland_total >= 300 && cleveland_totalHealth < 10)
                    {
                        clevelandPointsLabel.Text = cleveland_total.ToString("d");
                        MessageBox.Show("Congrats, Cleveland.  You won the game.");
                        this.Close();
                    }


                }
                else
                {
                    MessageBox.Show("Amount of available turns has been used.  Game over.");
                }
            }

            //Brian's turn

            else if (characterEntryTextBox.Text == "Brian")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = true;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = false;
                //Create a Brian object
                Brian myBrian = new Brian();

                //Get the Brian data
                BrianTurn(myBrian);

                //Display the Brian turn points data.
                brianPointsLevel.Text = myBrian.PointsBrian.ToString("d");

                //Display the Brian turn health data. 
                BrianHealthLabel.Text = myBrian.HealthBrian.ToString("d");


                //keep track of each turn

                //Input the points into the array
                if (brian_index <= 14)       //index of 0-14(15 turns)
                {
                    //Bring in values to points array.
                    brian_points[brian_index] = int.Parse(brianPointsLevel.Text);

                    //Bring in values to health array.
                    brian_health[brian_index] = int.Parse(BrianHealthLabel.Text);
                    brian_index++;


                    //Display the points values.

                    scoreListBox.Items.Clear();         //Prevents duplication of the points list
                    healthListBox.Items.Clear();        //Prevents duplication of the health list
                    brian_total = 0;                          //Resets total to 0
                    brian_totalHealth = 0;                    //Resets totalHealth to 0
                    int value = 0;
                    int valuee = 0;

                    for (int row = 0; row < brian_points.Length; row++)
                    {
                        //Putting loop into play for points
                        value = brian_points[row];
                        scoreListBox.Items.Add(value);

                        //Putting loop into play for health
                        valuee = brian_health[row];
                        healthListBox.Items.Add(valuee);

                        //Get the total points.
                        brian_total += value;

                        //Get the total health.
                        brian_totalHealth += valuee;
                    }

                    //Display the Brian turn points data.
                    brianPointsLevel.Text = brian_total.ToString("d");
                    MessageBox.Show("The total is " + brian_total.ToString("d"));

                    //Display the Brian turn health data.
                    BrianHealthLabel.Text = brian_totalHealth.ToString("d");


                    //Health warnings for each level.

                    //Ok
                    if (brian_totalHealth < 5)
                    {
                        MessageBox.Show("You are fine.....for NOW.  Ha ha ha!");
                        BrianHealthLabel.BackColor = System.Drawing.Color.Green;
                    }

                    //Tipsy
                    else if (brian_totalHealth < 10 && brian_totalHealth >= 5)
                    {
                        MessageBox.Show("You are tipsy.");
                        BrianHealthLabel.BackColor = System.Drawing.Color.YellowGreen;
                    }

                    //Drunk
                    else if (brian_totalHealth < 15 && brian_totalHealth >= 10)
                    {
                        MessageBox.Show("You are drunk.  Go easy on the booze.");
                        BrianHealthLabel.BackColor = System.Drawing.Color.Yellow;
                    }

                    //Hospital
                    else if (brian_totalHealth < 20 && brian_totalHealth >= 15)
                    {
                        MessageBox.Show("You are almost dead.");
                        BrianHealthLabel.BackColor = System.Drawing.Color.Orange;
                    }

                    //Dead
                    else if (brian_totalHealth >= 20)
                    {
                        MessageBox.Show("Game over, Brian.  YOU ARE DEAD!!!!");
                        brianPointsLevel.Text = "DEAD";
                        BrianHealthLabel.Text = "DEAD";
                        BrianHealthLabel.BackColor = System.Drawing.Color.Red;
                        brianButton.Visible = false;
                    }

                    //Set the winning condition for points
                    if (brian_total >= 300 && brian_totalHealth < 10)
                    {
                        brianPointsLevel.Text = brian_total.ToString("d");
                        MessageBox.Show("Congrats, Brian.  You won the game.");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Amount of available turns has been used.  Game over.");
                }

            }

            //Horace's turn

            else if (characterEntryTextBox.Text == "Horace")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = true;
                jeromePictureBox.Visible = false;
                //Create a Horace object
                Horace myHorace = new Horace();

                //Get the Horace data
                HoraceTurn(myHorace);

                //Display the Horace turn points data.
                horacePointsLabel.Text = myHorace.PointsHorace.ToString("d");

                //Display the Horace turn health data. 
                HoraceHealthLabel.Text = myHorace.HealthHorace.ToString("d");


                //keep track of each turn

                //Input the points into the array
                if (horace_index <= 14)       //index of 0-14(15 turns)
                {
                    //Bring in values to points array.
                    horace_points[horace_index] = int.Parse(horacePointsLabel.Text);

                    //Bring in values to health array.
                    horace_health[horace_index] = int.Parse(HoraceHealthLabel.Text);
                    horace_index++;


                    //Display the points values.

                    scoreListBox.Items.Clear();         //Prevents duplication of the points list
                    healthListBox.Items.Clear();        //Prevents duplication of the health list
                    horace_total = 0;                          //Resets total to 0
                    horace_totalHealth = 0;                    //Resets totalHealth to 0
                    int value = 0;
                    int valuee = 0;

                    for (int row = 0; row < horace_points.Length; row++)
                    {
                        //Putting loop into play for points
                        value = horace_points[row];
                        scoreListBox.Items.Add(value);

                        //Putting loop into play for health
                        valuee = horace_health[row];
                        healthListBox.Items.Add(valuee);

                        //Get the total points.
                        horace_total += value;

                        //Get the total health.
                        horace_totalHealth += valuee;
                    }

                    //Display the Horace turn points data.
                    horacePointsLabel.Text = horace_total.ToString("d");
                    MessageBox.Show("The total is " + horace_total.ToString("d"));

                    //Display the Horace turn health data.
                    HoraceHealthLabel.Text = horace_totalHealth.ToString("d");


                    //Health warnings for each level.

                    //Ok
                    if (horace_totalHealth < 5)
                    {
                        MessageBox.Show("You are fine.....for NOW.  Ha ha ha!");
                        HoraceHealthLabel.BackColor = System.Drawing.Color.Green;
                    }

                    //Tipsy
                    else if (horace_totalHealth < 10 && horace_totalHealth >= 5)
                    {
                        MessageBox.Show("You are tipsy.");
                        HoraceHealthLabel.BackColor = System.Drawing.Color.YellowGreen;
                    }

                    //Drunk
                    else if (horace_totalHealth < 15 && horace_totalHealth >= 10)
                    {
                        MessageBox.Show("You are drunk.  Go easy on the booze.");
                        HoraceHealthLabel.BackColor = System.Drawing.Color.Yellow;
                    }

                    //Hospital
                    else if (horace_totalHealth < 20 && horace_totalHealth >= 15)
                    {
                        MessageBox.Show("You are almost dead.  Despite you being a ghost.");
                        HoraceHealthLabel.BackColor = System.Drawing.Color.Orange;
                    }
                
                    //Dead
                    else if (horace_totalHealth >= 20)
                    {
                        MessageBox.Show("Game over, Horace.  While you are a ghost and not dead, you are now disqualified " +
                            "from the game.");
                        horacePointsLabel.Text = "DEAD";
                        HoraceHealthLabel.Text = "DEAD";
                        HoraceHealthLabel.BackColor = System.Drawing.Color.Red;
                        horaceButton.Visible = false;
                    }

                    //Set the winning condition for points
                    if (horace_total >= 300 && horace_totalHealth < 10)
                    {
                        horacePointsLabel.Text = horace_total.ToString("d");
                        MessageBox.Show("Congrats, Horace. You won the game.");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Amount of available turns has been used.  Game over.");
                }

            }

            //Jerome's turn

            else if (characterEntryTextBox.Text == "Jerome")
            {
                peterPictureBox.Visible = false;
                quagmirePictureBox.Visible = false;
                joePictureBox.Visible = false;
                clevelandPictureBox.Visible = false;
                brianPictureBox.Visible = false;
                horacePictureBox.Visible = false;
                jeromePictureBox.Visible = true;
                //Create a Jerome object
                Jerome myJerome = new Jerome();

                //Get the Jerome data
                JeromeTurn(myJerome);

                //Display the Jerome turn points data.
                jeromePointsLabel.Text = myJerome.PointsJerome.ToString("d");

                //Display the Jerome turn health data. 
                JeromeHealthLabel.Text = myJerome.HealthJerome.ToString("d");


                //keep track of each turn

                //Input the points into the array
                if (jerome_index <= 14)       //index of 0-14(15 turns)
                {
                    //Bring in values to points array.
                    jerome_points[jerome_index] = int.Parse(jeromePointsLabel.Text);

                    //Bring in values to health array.
                    jerome_health[jerome_index] = int.Parse(JeromeHealthLabel.Text);
                    jerome_index++;


                    //Display the points values.

                    scoreListBox.Items.Clear();         //Prevents duplication of the points list
                    healthListBox.Items.Clear();        //Prevents duplication of the health list
                    jerome_total = 0;                          //Resets total to 0
                    jerome_totalHealth = 0;                    //Resets totalHealth to 0
                    int value = 0;
                    int valuee = 0;

                    for (int row = 0; row < jerome_points.Length; row++)
                    {
                        //Putting loop into play for points
                        value = jerome_points[row];
                        scoreListBox.Items.Add(value);

                        //Putting loop into play for health
                        valuee = jerome_health[row];
                        healthListBox.Items.Add(valuee);

                        //Get the total points.
                        jerome_total += value;

                        //Get the total health.
                        jerome_totalHealth += valuee;
                    }

                    //Display the Jerome turn points data.
                    jeromePointsLabel.Text = jerome_total.ToString("d");
                    MessageBox.Show("The total is " + jerome_total.ToString("d"));

                    //Display the Horace turn health data.
                    JeromeHealthLabel.Text = jerome_totalHealth.ToString("d");


                    //Health warnings for each level.

                    //Ok
                    if (jerome_totalHealth < 5)
                    {
                        MessageBox.Show("You are fine.....for NOW.  Ha ha ha!");
                        JeromeHealthLabel.BackColor = System.Drawing.Color.Green;
                    }

                    //Tipsy
                    else if (jerome_totalHealth < 10 && jerome_totalHealth >= 5)
                    {
                        MessageBox.Show("You are tipsy.");
                        JeromeHealthLabel.BackColor = System.Drawing.Color.YellowGreen;
                    }

                    //Drunk
                    else if (jerome_totalHealth < 15 && jerome_totalHealth >= 10)
                    {
                        MessageBox.Show("You are drunk.  Go easy on the booze.");
                        JeromeHealthLabel.BackColor = System.Drawing.Color.Yellow;
                    }

                    //Hospital
                    else if (jerome_totalHealth < 20 && jerome_totalHealth >= 15)
                    {
                        MessageBox.Show("You are almost dead.  Be careful.");
                        JeromeHealthLabel.BackColor = System.Drawing.Color.Orange;
                    }

                    //Dead
                    else if (jerome_totalHealth >= 20)
                    {
                        MessageBox.Show("Game over, Jerome.  YOU ARE DEAD!!!!");
                        jeromePointsLabel.Text = "DEAD";
                        JeromeHealthLabel.Text = "DEAD";
                        JeromeHealthLabel.BackColor = System.Drawing.Color.Red;
                        jeromeButton.Visible = false;
                    }

                    //Set the winning condition for points
                    if (jerome_total >= 300 && jerome_totalHealth < 10)
                    {
                        jeromePointsLabel.Text = jerome_total.ToString("d");
                        MessageBox.Show("Congrats, Jerome.  You won the game.");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Amount of available turns has been used.  Game over.");
                }

            }

            //Exception message for available characters.
            else
            {
                MessageBox.Show("Please enter valid character name.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Clear the input fields for drinks.
            beerTextBox.Text = "";
            wineTextBox.Text = "";
            tequilaTextBox.Text = "";
            waterTextBox.Text = "";

            //Reset the focus.
            beerTextBox.Focus();
        }

        private void Game_board_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create an instance of the instructions form.
            Instructions instructions = new Instructions();

            //Display the form.
            instructions.ShowDialog();
        }

        private void peterButton_Click(object sender, EventArgs e)
        {
            characterEntryTextBox.Text = "Peter";

            //Pic display
            peterPictureBox.Visible = true;
            quagmirePictureBox.Visible = false;
            joePictureBox.Visible = false;
            clevelandPictureBox.Visible = false;
            brianPictureBox.Visible = false;
            horacePictureBox.Visible = false;
            jeromePictureBox.Visible = false;

            //Clear all fields
            beerTextBox.Text = "";
            wineTextBox.Text = "";
            tequilaTextBox.Text = "";
            waterTextBox.Text = "";

            //Reset the focus.
            beerTextBox.Focus();
        }

        private void quagmireButton_Click(object sender, EventArgs e)
        {
            characterEntryTextBox.Text = "Quagmire";

            //Pic display
            peterPictureBox.Visible = false;
            quagmirePictureBox.Visible = true;
            joePictureBox.Visible = false;
            clevelandPictureBox.Visible = false;
            brianPictureBox.Visible = false;
            horacePictureBox.Visible = false;
            jeromePictureBox.Visible = false;

            //Clear all fields
            beerTextBox.Text = "";
            wineTextBox.Text = "";
            tequilaTextBox.Text = "";
            waterTextBox.Text = "";

            //Reset the focus.
            beerTextBox.Focus();
        }

        private void joeButton_Click(object sender, EventArgs e)
        {
            characterEntryTextBox.Text = "Joe";

            //Pic display
            peterPictureBox.Visible = false;
            quagmirePictureBox.Visible = false;
            joePictureBox.Visible = true;
            clevelandPictureBox.Visible = false;
            brianPictureBox.Visible = false;
            horacePictureBox.Visible = false;
            jeromePictureBox.Visible = false;

            //Clear all fields
            beerTextBox.Text = "";
            wineTextBox.Text = "";
            tequilaTextBox.Text = "";
            waterTextBox.Text = "";

            //Reset the focus.
            beerTextBox.Focus();
        }

        private void clevelandButton_Click(object sender, EventArgs e)
        {
            characterEntryTextBox.Text = "Cleveland";

            //Pic display
            peterPictureBox.Visible = false;
            quagmirePictureBox.Visible = false;
            joePictureBox.Visible = false;
            clevelandPictureBox.Visible = true;
            brianPictureBox.Visible = false;
            horacePictureBox.Visible = false;
            jeromePictureBox.Visible = false;

            //Clear all fields
            beerTextBox.Text = "";
            wineTextBox.Text = "";
            tequilaTextBox.Text = "";
            waterTextBox.Text = "";

            //Reset the focus.
            beerTextBox.Focus();
        }

        private void brianButton_Click(object sender, EventArgs e)
        {
            characterEntryTextBox.Text = "Brian";

            //Pic display
            peterPictureBox.Visible = false;
            quagmirePictureBox.Visible = false;
            joePictureBox.Visible = false;
            clevelandPictureBox.Visible = false;
            brianPictureBox.Visible = true;
            horacePictureBox.Visible = false;
            jeromePictureBox.Visible = false;

            //Clear all fields
            beerTextBox.Text = "";
            wineTextBox.Text = "";
            tequilaTextBox.Text = "";
            waterTextBox.Text = "";

            //Reset the focus.
            beerTextBox.Focus();
        }

        private void horaceButton_Click(object sender, EventArgs e)
        {
            characterEntryTextBox.Text = "Horace";

            //Pic display
            peterPictureBox.Visible = false;
            quagmirePictureBox.Visible = false;
            joePictureBox.Visible = false;
            clevelandPictureBox.Visible = false;
            brianPictureBox.Visible = false;
            horacePictureBox.Visible = true;
            jeromePictureBox.Visible = false;

            //Clear all fields
            beerTextBox.Text = "";
            wineTextBox.Text = "";
            tequilaTextBox.Text = "";
            waterTextBox.Text = "";

            //Reset the focus.
            beerTextBox.Focus();
        }

        private void jeromeButton_Click(object sender, EventArgs e)
        {
            characterEntryTextBox.Text = "Jerome";

            //Pic display
            peterPictureBox.Visible = false;
            quagmirePictureBox.Visible = false;
            joePictureBox.Visible = false;
            clevelandPictureBox.Visible = false;
            brianPictureBox.Visible = false;
            horacePictureBox.Visible = false;
            jeromePictureBox.Visible = true;

            //Clear all fields
            beerTextBox.Text = "";
            wineTextBox.Text = "";
            tequilaTextBox.Text = "";
            waterTextBox.Text = "";

            //Reset the focus.
            beerTextBox.Focus();
        }
    }
}