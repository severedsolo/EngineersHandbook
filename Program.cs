using System;
using System.Collections.Generic;
using System.Globalization;

namespace severedsoloEngineersHandbook
{
    class EngineersHandbook
    {
        int lastdestination;
        string lastdestinationstring;
        int destination = 0;
        bool returning;
        int plan = 0;
        string planstring;
        int deltav = 0;
        int oxygen = 0;
        int food = 0;
        int ec = 0;
        string destinationstring;
        bool done;
        bool another;
        int returndv;

        static void Main()
        {
            EngineersHandbook k = new EngineersHandbook();
            k.done = false;
            k.destination = 0;
            k.lastdestination = 0;
            Console.WriteLine("severedsolo's Engineers Handbook for KSP");
            Console.WriteLine(Environment.NewLine);
            
            while (k.done == false)
            {
                k.deltav = 0;
                k.gatherInfo();
                k.calculate();

                if (k.deltav > 0)
                {
                    Console.WriteLine("You need " + k.deltav + "m/s of delta-v");
                    Console.WriteLine("Do another calculation? (y/n)");
                    string s = Console.ReadLine();
                    if (s == "n")
                    {
                        k.done = true;
                    }
                }
            }
        }

        public void gatherInfo()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("moho", 1);
            dict.Add("eve", 2);
            dict.Add("gilly", 3);
            dict.Add("kerbin", 4);
            dict.Add("mun", 5);
            dict.Add("minmus", 6);
            dict.Add("duna", 7);
            dict.Add("jool", 8);
            dict.Add("laythe", 9);
            dict.Add("vall", 10);
            dict.Add("tylo", 11);
            dict.Add("bop", 12);
            dict.Add("pol", 13);
            dict.Add("eeloo", 14);
            dict.Add("dres", 15);
            dict.Add("ike", 16);
            dict.Add("sun", 17);

            int planet;
            if (destination == 0 || destination == lastdestination)
            {
                Console.WriteLine("Where are you going?");
                destinationstring = Console.ReadLine().ToLower();
            }
            if (dict.TryGetValue(destinationstring, out planet))
            {
                if (destinationstring != lastdestinationstring)
                {
                    destination = planet;
                    Console.WriteLine("What's the plan?");

                    if (destination != 4 && destination != 17)
                    {
                        Console.WriteLine("Type 1 for Flyby");
                    }
                    Console.WriteLine("Type 2 for Orbit");

                    if (destination != 4 && destination != 8 && destination != 17)
                    {
                        Console.WriteLine("Type 3 for Landing");
                    }

                    plan = Convert.ToInt32(Console.ReadLine(), CultureInfo.CurrentCulture);
                    if (plan > 0 && plan < 4)
                    {
                        if (plan == 1)
                        {
                            planstring = "flyby";
                        }

                        if (plan == 2)
                        {
                            planstring = "orbit";
                        }
                        if (plan == 3)
                        {
                            planstring = "land";
                        }
                        Console.WriteLine("Are you coming back? (y/n)");
                        string returnline = Console.ReadLine().ToLower();
                        if (returnline == "y" || returnline == "n")
                        {
                            if (returnline == "y")
                            {
                                returning = true;
                            }
                            else
                            {
                                returning = false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry. I didn't recognise that");
                    }

                }
                else
                {
                    Console.WriteLine("I've already calculated that one");
                }

            }
        }

        public void calculate()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("mohoflyby", 7630);
            dict.Add("mohoorbit", 10040);
            dict.Add("moholand", 10910);
            dict.Add("eveflyby", 4870);
            dict.Add("eveorbit", 6280);
            dict.Add("eveland", 12280);
            dict.Add("gillyflyby", 4060);
            dict.Add("gillyorbit", 4470);
            dict.Add("gillyland", 4500);
            dict.Add("kerbinorbit", 3200);
            dict.Add("munflyby", 4060);
            dict.Add("munorbit", 4370);
            dict.Add("munland", 4950);
            dict.Add("minmusflyby", 4470);
            dict.Add("minmusorbit", 4630);
            dict.Add("minmusland", 4810);
            dict.Add("dunaflyby", 4490);
            dict.Add("dunaorbit", 4740);
            dict.Add("dunaland", 5350);
            dict.Add("ikeflyby", 4770);
            dict.Add("ikeorbit", 4950);
            dict.Add("ikeland", 5340);
            dict.Add("joolflyby", 5600);
            dict.Add("joolorbit", 8570);
            dict.Add("laytheflyby", 6690);
            dict.Add("laytheorbit", 7700);
            dict.Add("laytheland", 10300);
            dict.Add("vallflyby", 6120);
            dict.Add("vallorbit", 7030);
            dict.Add("vallland", 7890);
            dict.Add("tyloflyby", 4980);
            dict.Add("tyloorbit", 6080);
            dict.Add("tyloland", 8350);
            dict.Add("bopflyby", 8220);
            dict.Add("boporbit", 9120);
            dict.Add("bopland", 9340);
            dict.Add("polflyby", 6420);
            dict.Add("polorbit", 7240);
            dict.Add("polland", 7370);
            dict.Add("eelooflyby", 6620);
            dict.Add("eelooorbit", 7990);
            dict.Add("eelooland", 8610);
            dict.Add("dresflyby", 5970);
            dict.Add("dresorbit", 7260);
            dict.Add("dresland", 7690);
            dict.Add("sunorbit", 4150);


            string s = destinationstring + planstring;
            int d;
            if (dict.TryGetValue(s, out d))
            {
                deltav = d;
                lastdestinationstring = s;
                lastdestination = destination;
                if (deltav < 3200)
                {
                    Console.WriteLine("Something went wrong, trying again");
                    return;
                }
            }

            else
            {
                Console.WriteLine("Your flightplan isn't valid");
                return;
            }
            if (returning == true)
            {
                if (destination == 5 || destination == 6)
                {
                    returnCalc();
                }
                else
                {
                    returndv = deltav - 3200;
                }
                deltav = deltav + returndv;
            }
        }
        
        public void returnCalc()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("munflyby", 0);
            dict.Add("munorbit", 310);
            dict.Add("munland", 890);
            dict.Add("minmusflyby", 930);
            dict.Add("minmusorbit", 160);
            dict.Add("minmusland", 340);

            int d;
            if (dict.TryGetValue(lastdestinationstring, out d))
            {
                returndv = d;
            }
            else
            {
                Console.WriteLine("Something went wrong. Trying again");
            }
        }
    }
}
