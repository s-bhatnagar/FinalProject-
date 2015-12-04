namespace F15Team26.Migrations
{
    using F15Team26.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<F15Team26.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(F15Team26.Models.AppDbContext context)
        {
            //{
            //    Customers C1 = new Customers();
            //    C1.Email = "cbaker@example.com";
            //    C1.Password = "CBaker12";
            //    C1.LName = "Baker";
            //    C1.FName = "Christopher";
            //    C1.MI = "L";
            //    C1.Address = "1245 Lake Austin Blvd.";
            //    C1.Zipcode = "78733";
            //    C1.Phone = "5125571146";

            //    Customers C2 = new Customers();
            //    C2.Email = "michelle@example.com";
            //    C2.Password = "jVb0Z6";
            //    C2.LName = "Banks";
            //    C2.FName = "Michelle";
            //    C2.Address = "1300 Tall Pine Lane";
            //    C2.Zipcode = "78261";
            //    C2.Phone = "2102678873";

            //    Customers C3 = new Customers();
            //    C3.Email = "fd@aool.com";
            //    C3.Password = "K9Kz3r";
            //    C3.LName = "Broccolo";
            //    C3.FName = "Franco";
            //    C3.MI = "V";
            //    C3.Address = "62 Browning Rd";
            //    C3.Zipcode = "77019";
            //    C3.Phone = "8175659699";

            //    Customers C4 = new Customers();
            //    C4.Email = "wendy@ggmail.com";
            //    C4.Password = "Tz9Kox";
            //    C4.LName = "Chang";
            //    C4.FName = "Wendy";
            //    C4.MI = "L";
            //    C4.Address = "202 Bellmont Hall";
            //    C4.Zipcode = "78713";
            //    C4.Phone = "5125943222";

            //    Customers C5 = new Customers();
            //    C5.Email = "limchou@yaho.com";
            //    C5.Password = "Q7lH11";
            //    C5.LName = "Chou";
            //    C5.FName = "Lim";
            //    C5.Address = "1600 Teresa Lane";
            //    C5.Zipcode = "78266";
            //    C5.Phone = "2107724599";

            //    Customers C6 = new Customers();
            //    C6.Email = "11111111.Dixon@aool.com";
            //    C6.Password = "8ghOuy";
            //    C6.LName = "Dixon";
            //    C6.FName = "Shan";
            //    C6.Address = "234 Holston Circle";
            //    C6.MI = "D";
            //    C6.Zipcode = "75208";
            //    C6.Phone = "2142643255";

            //    Customers C7 = new Customers();
            //    C7.Email = "louann@ggmail.com";
            //    C7.Password = "AzTp60";
            //    C7.LName = "Feeley";
            //    C7.FName = "Lou Ann";
            //    C7.MI = "K";
            //    C7.Zipcode = "77010";
            //    C7.Phone = "8172556749";

            //    Customers C8 = new Customers();
            //    C8.Email = "tfreeley@minntonka.ci.state.mn.us";
            //    C8.Password = "Mz10yi";
            //    C8.LName = "Freeley";
            //    C8.FName = "Tesa";
            //    C8.MI = "P";
            //    C8.Address = "4448 Fairview Ave.";
            //    C8.Zipcode = "77009";
            //    C8.Phone = "8173255687";

            //    Customers C9 = new Customers();
            //    C9.Email = "mgar@aool.com";
            //    C9.Password = "V2szlu";
            //    C9.LName = "Garcia";
            //    C9.FName = "Margaret";
            //    C9.MI = "L";
            //    C9.Address = "594 Longview";
            //    C9.Zipcode = "77003";
            //    C9.Phone = "8176593544";

            //    Customers C10 = new Customers();
            //    C10.Email = "chaley@thug.com";
            //    C10.Password = "atLm6W";
            //    C10.LName = "Haley";
            //    C10.FName = "Charles";
            //    C10.MI = "E";
            //    C10.Address = "One Cowboy Pkwy";
            //    C10.Zipcode = "75261";
            //    C10.Phone = "2148475583";

            //    Customers C11 = new Customers();
            //    C11.Email = "jeff@ggmail.com";
            //    C11.Password = "WQAu70";
            //    C11.LName = "Hampton";
            //    C11.FName = "Jeffrey";
            //    C11.MI = "T";
            //    C11.Address = "337 38th St.";
            //    C11.Zipcode = "78705";
            //    C11.Phone = "5126978613";

            //    Customers C12 = new Customers();
            //    C12.Email = "wjhearniii@umch.edu";
            //    C12.Password = "L0f3N5";
            //    C12.LName = "Hearn";
            //    C12.FName = "John";
            //    C12.MI = "B";
            //    C12.Address = "4225 North First";
            //    C12.Zipcode = "75237";
            //    C12.Phone = "2148965621";
            //    C12.CreditCard1 = "7197163903436520";
            //    C12.CreditCard1Type = "Master Card";

            //    Customers C13 = new Customers();
            //    C13.Email = "hicks43@ggmail.com";
            //    C13.Password = "s33WOz";
            //    C13.LName = "Hicks";
            //    C13.FName = "Anthony";
            //    C13.MI = "J";
            //    C13.Address = "32 NE Garden Ln., Ste 910";
            //    C13.Zipcode = "78239";
            //    C13.Phone = "2148965621";
            //    C13.CreditCard1 = "6868476042647310";
            //    C13.CreditCard1Type = "VISA";

            //    Customers C14 = new Customers();
            //    C14.Email = "bradsingram@mall.utexas.edu";
            //    C14.Password = "Z6CiUg";
            //    C14.LName = "Ingram";
            //    C14.FName = "Brad";
            //    C14.MI = "S";
            //    C14.Address = "6548 La Posada Ct.";
            //    C14.Zipcode = "78736";
            //    C14.Phone = "5124678821";
            //    C14.CreditCard1 = "3727398982004160";
            //    C14.CreditCard1Type = "Discover";

            //    Customers C15 = new Customers();
            //    C15.Email = "Z6CiUg.Ingram@aool.com";
            //    C15.Password = "1PnrBV";
            //    C15.LName = "Jacobs";
            //    C15.FName = "Todd";
            //    C15.MI = "L";
            //    C15.Address = "4564 Elm St.";
            //    C15.Zipcode = "78731";
            //    C15.Phone = "5124653365";
            //    C15.CreditCard1 = "5454973452517410";
            //    C15.CreditCard1Type = "American Express";

            //    Customers C16 = new Customers();
            //    C16.Email = "victoria@aool.com";
            //    C16.Password = "nothing";
            //    C16.LName = "Lawrence";
            //    C16.FName = "Victoria";
            //    C16.MI = "M";
            //    C16.Address = "6639 Butterfly Ln.";
            //    C16.Zipcode = "78761";
            //    C16.Phone = "5129457399";
            //    C16.CreditCard1 = "5514364986244200";
            //    C16.CreditCard1Type = "Master Card";

            //    Customers C17 = new Customers();
            //    C17.Email = "lineback@flush.net";
            //    C17.Password = "U0Dnc4";
            //    C17.LName = "Lineback";
            //    C17.FName = "Erik";
            //    C17.MI = "W";
            //    C17.Address = "1300 Netherland St";
            //    C17.Phone = "2102449976";
            //    C17.CreditCard1 = "7093643507872300";
            //    C17.CreditCard1Type = "VISA";

            //    Customers C18 = new Customers();
            //    C18.Email = "elowe@netscrape.net";
            //    C18.Password = "v3n5AV";
            //    C18.LName = "Lowe";
            //    C18.FName = "Ernest";
            //    C18.MI = "S";
            //    C18.Address = "3201 Pine Drive";
            //    C18.Zipcode = "78279";
            //    C18.Phone = "2105344627";
            //    C18.CreditCard1 = "8775273552236330";
            //    C18.CreditCard1Type = "American Express";

            //    Customers C19 = new Customers();
            //    C19.Email = "luce_chuck@ggmail.com";
            //    C19.Password = "CU5BiF";
            //    C19.LName = "Luce";
            //    C19.FName = "Chuck";
            //    C19.MI = "B";
            //    C19.Address = "2345 Rolling Clouds";
            //    C19.Zipcode = "78268";
            //    C19.Phone = "2106983548";
            //    C19.CreditCard1 = "1351814661069320";
            //    C19.CreditCard1Type = "Master Card";

            //    Customers C20 = new Customers();
            //    C20.Email = "mackcloud@pimpdaddy.com";
            //    C20.Password = "9VOwdE";
            //    C20.LName = "MacLeod";
            //    C20.FName = "Jennifer";
            //    C20.MI = "D";
            //    C20.Address = "2504 Far West Blvd.";
            //    C20.Zipcode = "78731";
            //    C20.Phone = "5124748138";
            //    C20.CreditCard1 = "1355077062414870";
            //    C20.CreditCard1Type = "VISA";



            //    Customers C21 = new Customers();
            //    C21.Email = "liz@ggmail.com";
            //    C21.Password = "0QyilL";
            //    C21.LName = "Markham";
            //    C21.FName = "Elizabeth";
            //    C21.MI = "P";
            //    C21.Address = "7861 Chevy Chase";
            //    C21.Zipcode = "78732";
            //    C21.Phone = "5124579845";
            //    C21.CreditCard1 = "1241928871243970";
            //    C21.CreditCard1Type = "VISA";

            //    Customers C22 = new Customers();
            //    C22.Email = "mclarence@aool.com";
            //    C22.Password = "zBLq3S";
            //    C22.LName = "Martin";
            //    C22.FName = "Clarence";
            //    C22.MI = "A";
            //    C22.Address = "87 Alcedo St.";
            //    C22.Zipcode = "77045";
            //    C22.Phone = "8174955201";
            //    C22.CreditCard1 = "5310804739616290";
            //    C22.CreditCard1Type = "Discover";

            //    Customers C23 = new Customers();
            //    C23.Email = "smartinmartin.Martin@aool.com";
            //    C23.Password = "1rKkMW";
            //    C23.LName = "Martinez";
            //    C23.FName = "Gregory";
            //    C23.MI = "R";
            //    C23.Address = "8295 Sunset Blvd.";
            //    C23.Zipcode = "77030";
            //    C23.Phone = "8178746718";
            //    C23.CreditCard1 = "7828068665061360";
            //    C23.CreditCard1Type = "American Express";

            //    Customers C24 = new Customers();
            //    C24.Email = "cmiller@mapster.com";
            //    C24.Password = "2HeP6n";
            //    C24.LName = "Miller";
            //    C24.FName = "Charles";
            //    C24.MI = "R";
            //    C24.Address = "8962 Main St.";
            //    C24.Zipcode = "77031";
            //    C24.Phone = "8177458615";
            //    C24.CreditCard1 = "9758965973058220";
            //    C24.CreditCard1Type = "Master Card";

            //    Customers C25 = new Customers();
            //    C25.Email = "nelson.Kelly@aool.com";
            //    C25.Password = "FSb8rA";
            //    C25.LName = "Nelson";
            //    C25.FName = "Kelly";
            //    C25.Address = "2601 Red River";
            //    C25.Zipcode = "78703";
            //    C25.Phone = "5122926966";
            //    C25.CreditCard1 = "5420363774166000";
            //    C25.CreditCard1Type = "Discover";

            //    Customers C26 = new Customers();
            //    C26.Email = "jojoe@ggmail.com";
            //    C26.Password = "xI8Brg";
            //    C26.LName = "Nguyen";
            //    C26.FName = "Joe";
            //    C26.MI = "C";
            //    C26.Address = "1249 4th SW St.";
            //    C26.Zipcode = "75238";
            //    C26.Phone = "2143125897";
            //    C26.CreditCard1 = "6976560896924830";
            //    C26.CreditCard1Type = "American Express";

            //    Customers C27 = new Customers();
            //    C27.Email = "orielly@foxnets.com";
            //    C27.Password = "pS2OJh";
            //    C27.LName = "O'Reilly";
            //    C27.FName = "Bill";
            //    C27.MI = "T";
            //    C27.Address = "8800 Gringo Drive";
            //    C27.Zipcode = "78260";
            //    C27.Phone = "2103450925";
            //    C27.CreditCard1 = "4578875163529160";
            //    C27.CreditCard1Type = "Master Card";

            //    Customers C28 = new Customers();
            //    C28.Email = "or@aool.com";
            //    C28.Password = "8K0cAh";
            //    C28.LName = "Radkovich";
            //    C28.FName = "Anka";
            //    C28.MI = "L";
            //    C28.Address = "1300 Elliott Pl";
            //    C28.Zipcode = "75260";
            //    C28.Phone = "2142345566";
            //    C28.CreditCard1 = "7156646384501590";
            //    C28.CreditCard1Type = "VISA";

            //    Customers C29 = new Customers();
            //    C29.Email = "megrhodes@freezing.co.uk";
            //    C29.Password = "1xVfHp";
            //    C29.LName = "Rhodes";
            //    C29.MI = "C";
            //    C29.Address = "4587 Enfield Rd.";
            //    C29.Zipcode = "78707";
            //    C29.Phone = "5123744746";
            //    C29.CreditCard1 = "6942941089010230";
            //    C29.CreditCard1Type = "Discover";

            //    Customers C30 = new Customers();
            //    C30.Email = "erynrice@aool.com";
            //    C30.Password = "t8Hq8G";
            //    C30.LName = "Rice";
            //    C30.FName = "Eryn";
            //    C30.MI = "M";
            //    C30.Address = "3405 Rio Grande";
            //    C30.Zipcode = "78705";
            //    C30.Phone = "5123876657";
            //    C30.CreditCard1 = "9155495411577090";
            //    C30.CreditCard1Type = "American Express";

            //    Customers C31 = new Customers();
            //    C31.Email = "jorge@hootmail.com";
            //    C31.Password = "m7EMTf";
            //    C31.LName = "Rodriguez";
            //    C31.FName = "Jorge";
            //    C31.Address = "6788 Cotter Street";
            //    C31.Zipcode = "77057";
            //    C31.Phone = "8178904374";
            //    C31.CreditCard1 = "4269847618467190";
            //    C31.CreditCard1Type = "Master Card";

            //    Customers C32 = new Customers();
            //    C32.Email = "ra@aoo.com";
            //    C32.Password = "3wCynC";
            //    C32.LName = "Rogers";
            //    C32.FName = "Allen";
            //    C32.MI = "B";
            //    C32.Address = "4965 Oak Hill";
            //    C32.Zipcode = "78732";
            //    C32.Phone = "5128752943";
            //    C32.CreditCard1 = "9906094629756390";
            //    C32.CreditCard1Type = "VISA";

            //    Customers C33 = new Customers();
            //    C33.Email = "o_st-jean@home.com";
            //    C33.Password = "lO1ZJq";
            //    C33.LName = "Saint-Jean";
            //    C33.FName = "Olivier";
            //    C33.MI = "M";
            //    C33.Address = "255 Toncray Dr.";
            //    C33.Zipcode = "78292";
            //    C33.Phone = "2104145678";
            //    C33.CreditCard1 = "8857413205443210";
            //    C33.CreditCard1Type = "Discover";

            //    Customers C34 = new Customers();
            //    C34.Email = "ss34@ggmail.com";
            //    C34.Password = "oO4op6";
            //    C34.LName = "Saunders";
            //    C34.FName = "Sarah";
            //    C34.MI = "J";
            //    C34.Address = "332 Avenue C";
            //    C34.Zipcode = "78705";
            //    C34.Phone = "5123497810";
            //    C34.CreditCard1 = "8040396531388550";
            //    C34.CreditCard1Type = "American Express";

            //    Customers C35 = new Customers();
            //    C35.Email = "willsheff@email.com";
            //    C35.Password = "V5P2ox";
            //    C35.LName = "Sewell";
            //    C35.FName = "William";
            //    C35.MI = "T";
            //    C35.Address = "2365 51st St.";
            //    C35.Zipcode = "78709";
            //    C35.Phone = "5124510084";
            //    C35.CreditCard1 = "5015140475671290";
            //    C35.CreditCard1Type = "Master Card";

            //    Customers C36 = new Customers();
            //    C36.Email = "sheff44@ggmail.com";
            //    C36.Password = "4XKLsd";
            //    C36.LName = "Sheffield";
            //    C36.FName = "Martin";
            //    C36.MI = "J";
            //    C36.Address = "3886 Avenue A";
            //    C36.Zipcode = "78705";
            //    C36.Phone = "5125479167";
            //    C36.CreditCard1 = "6962592004533190";
            //    C36.CreditCard1Type = "Discover";

            //    Customers C37 = new Customers();
            //    C37.Email = "johnsmith187@aool.com";
            //    C37.Password = "2vmGAv";
            //    C37.LName = "Smith";
            //    C37.FName = "John";
            //    C37.MI = "A";
            //    C37.Address = "23 Hidden Forge Dr.";
            //    C37.Zipcode = "78280";
            //    C37.Phone = "2108321888";
            //    C37.CreditCard1 = "7177961364808080";
            //    C37.CreditCard1Type = "American Express";

            //    Customers C38 = new Customers();
            //    C38.Email = "dustroud@mail.com";
            //    C38.Password = "Ms5kXs";
            //    C38.LName = "Stroud";
            //    C38.FName = "Dustin";
            //    C38.MI = "P";
            //    C38.Address = "1212 Rita Rd";
            //    C38.Zipcode = "75221";
            //    C38.Phone = "2142346667";
            //    C38.CreditCard1 = "6668749400262880";
            //    C38.CreditCard1Type = "Master Card";

            //    Customers C39 = new Customers();
            //    C39.Email = "eric_stuart@aool.com";
            //    C39.Password = "Vj81MN";
            //    C39.LName = "Stuart";
            //    C39.FName = "Eric";
            //    C39.MI = "D";
            //    C39.Address = "5576 Toro Ring";
            //    C39.Zipcode = "78746";
            //    C39.Phone = "5128178335";
            //    C39.CreditCard1 = "1780588472896630";
            //    C39.CreditCard1Type = "Discover";
            //    C39.CreditCard2 = "2981762270647820";
            //    C39.CreditCard2Type = "VISA";

            //    Customers C40 = new Customers();
            //    C40.Email = "peterstump@hootmail.com";
            //    C40.Password = "1XdmSV";
            //    C40.LName = "Stump";
            //    C40.FName = "Peter";
            //    C40.MI = "L";
            //    C40.Address = "1300 Kellen Circle";
            //    C40.Zipcode = "77018";
            //    C40.Phone = "8174560903";
            //    C40.CreditCard1 = "4402795173067790";
            //    C40.CreditCard1Type = "American Express";
            //    C40.CreditCard2 = "7145436218913220";
            //    C40.CreditCard2Type = "American Express";

            //    Customers C41 = new Customers();
            //    C41.Email = "tanner@ggmail.com";
            //    C41.Password = "w9wPff";
            //    C41.LName = "Tanner";
            //    C41.FName = "Jeremy";
            //    C41.MI = "S";
            //    C41.Address = "4347 Almstead";
            //    C41.Zipcode = "77044";
            //    C41.Phone = "8174590929";
            //    C41.CreditCard1 = "1422935985121310";
            //    C41.CreditCard1Type = "Master Card";
            //    C41.CreditCard2 = "4977132658283840";
            //    C41.CreditCard2Type = "Master Card";

            //    Customers C42 = new Customers();
            //    C42.Email = "taylordjay@aool.com";
            //    C42.Password = "Vjb1wI";
            //    C42.LName = "Taylor";
            //    C42.FName = "Allison";
            //    C42.Address = "467 Nueces St.";
            //    C42.Phone = "78705";
            //    C42.CreditCard1 = "2247987109036310";
            //    C42.CreditCard1Type = "VISA";
            //    C42.CreditCard2 = "8602456860474510";
            //    C42.CreditCard2Type = "American Express";

            //    Customers C43 = new Customers();
            //    C43.Email = "y87hu9ik.Taylor@aool.com";
            //    C43.Password = "9yhFS3";
            //    C43.LName = "Taylor";
            //    C43.MI = "Rachel";
            //    C43.Address = "345 Longview Dr.";
            //    C43.Zipcode = "78705";
            //    C43.Phone = "5124512631";
            //    C43.CreditCard1 = "8761707076925830";
            //    C43.CreditCard1Type = "Discover";
            //    C43.CreditCard2 = "1590566912856230";
            //    C43.CreditCard2Type = "VISA";

            //    Customers C44 = new Customers();
            //    C44.Email = "tee_frank@hootmail.com";
            //    C44.Password = "1EIwbx";
            //    C44.LName = "Tee";
            //    C44.FName = "Frank";
            //    C44.MI = "J";
            //    C44.Address = "5590 Lavell Dr";
            //    C44.Zipcode = "77004";
            //    C44.Phone = "8178765543";
            //    C44.CreditCard1 = "1680731306587540";
            //    C44.CreditCard1Type = "American Express";
            //    C44.CreditCard2 = "9167268833061390";
            //    C44.CreditCard2Type = "Discover";

            //    Customers C45 = new Customers();
            //    C45.Email = "tuck33@ggmail.com";
            //    C45.Password = "I6BgsS";
            //    C45.LName = "Tucker";
            //    C45.FName = "Clent";
            //    C45.MI = "J";
            //    C45.Address = "312 Main St.";
            //    C45.Zipcode = "75315";
            //    C45.Phone = "2148471154";
            //    C45.CreditCard1 = "5832667042375460";
            //    C45.CreditCard1Type = "Master Card";
            //    C45.CreditCard2 = "4465504285538790";
            //    C45.CreditCard2Type = "Discover";

            //    Customers C46 = new Customers();
            //    C46.Email = "avelasco@yaho.com";
            //    C46.Password = "PClc7K";
            //    C46.LName = "Velasco";
            //    C46.FName = "Allen";
            //    C46.MI = "G";
            //    C46.Address = "679 W. 4th";
            //    C46.Zipcode = "75207";
            //    C46.Phone = "2143985638";
            //    C46.CreditCard1 = "1368667972354250";
            //    C46.CreditCard1Type = "3517773022040250";
            //    C46.CreditCard2 = "3517773022040250";
            //    C46.CreditCard2Type = "American Express";

            //    Customers C47 = new Customers();
            //    C47.Email = "westj@pioneer.net";
            //    C47.Password = "jW5fPP";
            //    C47.LName = "West";
            //    C47.FName = "Jake";
            //    C47.Zipcode = "75323";
            //    C47.Phone = "2148475244";
            //    C47.CreditCard1 = "1589854795728270";
            //    C47.CreditCard1Type = "Discover";
            //    C47.CreditCard2 = "7579224077662870";
            //    C47.CreditCard2Type = "VISA";

            //    Customers C48 = new Customers();
            //    C48.Email = "louielouie@aool.com";
            //    C48.Password = "fq7yDw";
            //    C48.LName = "Winthorpe";
            //    C48.FName = "Louis";
            //    C48.MI = "L";
            //    C48.Address = "2500 Padre Blvd";
            //    C48.Zipcode = "75220";
            //    C48.Phone = "2145650098";
            //    C48.CreditCard1 = "2381534238100500";
            //    C48.CreditCard1Type = "American Express";
            //    C48.CreditCard2 = "5270385324417050";
            //    C48.CreditCard2Type = "Discover";

            //    Customers C49 = new Customers();
            //    C49.Email = "rwood@voyager.net";
            //    C49.Password = "Pbon0r";
            //    C49.LName = "Wood";
            //    C49.FName = "Reagan";
            //    C49.MI = "B";
            //    C49.Address = "447 Westlake Dr.";
            //    C49.Phone = "5124545242";
            //    C49.CreditCard1 = "8548275652910170";
            //    C49.CreditCard1Type = "Master Card";
            //    C49.CreditCard2 = "8294260418333300";
            //    C49.CreditCard2Type = "Discover";

      //}


            
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
