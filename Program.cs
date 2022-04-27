using static System.Console;
using System.IO;
using System.Text;
namespace program
{
 
    class Cliente{
            private string name;
            private int account;
            private string phonenumber;
            private Adress adress;

            public string Name{
                get{return name;}
                set{name = value.ToLower();}
            }
            public int Account{
                get{return account;}
                set{account = value;}
            }
            public string Phonenumber{
                get{return phonenumber;}
                set{phonenumber = value;}
            }
            public Adress peopleAdress{
                get{return adress;}
                set{adress = value;}
            }
        }

        class Adress{
            private int number;
            private string? street;
            private string? neighborhood;
            private string? city;
            private string? state;
            private string? country;
            private int zipcode;

            public int Number{
                get{return number;}
                set{number = value;}
            }
            public string Street{
                get{return street;}
                set{street = value;}
            }
            public string Neighborhood{
                get{return neighborhood;}
                set{neighborhood = value;}
            }
            public string City{
                get{return city;}
                set{city = value;}
            }
            public string State{
                get{return state;}
                set{state = value;}
            }
            public string Country{
                get{return country;}
                set{country = value;}
            }
            public int Zipcode{
                get{return zipcode;}
                set{zipcode = value;}
            }

        }

    class Program
    {
        static string createFile(string archiveName){
            using (StreamWriter writer = new StreamWriter(archiveName, true)){
	        writer.WriteLine("List of users");
	        }
            return archiveName;
        }


    static void writeAccount(Cliente [] user, string name){
        string dir = "../Creating users list/"+name;
       using (StreamWriter writer = new StreamWriter(@dir, true))
{
        for(int x=0; x<user.Length; x++){
            writer.Write("{0};", user[x].Name);
            writer.Write("{0};", user[x].Account);
            writer.Write("{0};", user[x].Phonenumber);
            writer.WriteLine("{0};{1};{2};{3};{4};{5};{6}; ", user[x].peopleAdress.Number, 
            user[x].peopleAdress.Street, user[x].peopleAdress.Neighborhood, user[x].peopleAdress.City,
            user[x].peopleAdress.State, user[x].peopleAdress.Country, user[x].peopleAdress.Zipcode);
        }
}
}

        static void addUser(Cliente[] user){
            for(int x = 0; x< user.Length; x++){
                user[x] = new Cliente();
                Console.WriteLine("Adding new user: ");
                Console.WriteLine("Name: ");
                user[x].Name = Console.ReadLine();
                user[x].Name = user[x].Name.ToUpper();
                int i =0;
                while(i<user[x].Name.Length){
                    if(user[x].Name[i] >= 'A' && user[x].Name[i]<= 'Z'){
                        Console.WriteLine("Invalid Name: {0}", user[x].Name);
                        Console.WriteLine("Type a new Name: ");
                        user[x].Name = Console.ReadLine();
                        user[x].Name = user[x].Name.ToUpper();
                        i = 0;
                    }
                    else{
                        i++;
                    }
                    
                }
                Console.WriteLine("Account Number: ");
                user[x].Account = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Phone number: ");
                user[x].Phonenumber = Console.ReadLine();
                user[x].peopleAdress = addAdress();
            }
        }

        static Adress addAdress(){
            Adress adr = new Adress();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Adress:");
            Console.WriteLine("Number: ");
            adr.Number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Street: ");
            adr.Street = Console.ReadLine();
            Console.WriteLine("Neighborhood: ");
            adr.Neighborhood = Console.ReadLine();
            Console.WriteLine("City: ");
            adr.City = Console.ReadLine();
            Console.WriteLine("State: ");
            adr.State = Console.ReadLine();
            Console.WriteLine("Country: ");
            adr.Country = Console.ReadLine();
            Console.WriteLine("Zipcode: ");
            adr.Zipcode = Convert.ToInt32(Console.ReadLine());
            return adr;
        }


        static bool verifyIfFile_txtExists(string filename){
            string path = "../Creating users list/"+filename;
            bool result = File.Exists(path);
            if(result == false){
                Console.WriteLine("File Not Found!");
                Console.WriteLine("Create a file {0}?\nY or N:", filename);
                string? check = Console.ReadLine();
                check = check.ToLower();
                if(check == "y"){
                    createFile(filename);
                    return true;
                }
                else if(check != "y"){
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to create a new list?");
            Console.WriteLine("Y or N: ");
            string? c = "n";
            c = Console.ReadLine();
            c = c.ToLower();
            string? nameList = "Users.txt";
            if (c == "y"){
                Console.WriteLine("File name: ");
                string? archiveName = Console.ReadLine();
                archiveName = archiveName+".txt";
                 nameList = createFile(archiveName);
            }
            else{
                Console.WriteLine("Open standard txt file? ");
                c = Console.ReadLine();
                c = c.ToLower();
                if (c == "n"){
                    Console.WriteLine("Type the file name: ");
                    nameList = Console.ReadLine();
                    nameList = nameList+".txt";
                }
            }
            bool fileAnswer = verifyIfFile_txtExists(nameList);
            if(fileAnswer == false){
                return;
            }
            Console.WriteLine("How many users do you want to add: ");
            int usersNumbers = Convert.ToInt32(Console.ReadLine());
            int x = 0;
            Cliente [] user = new Cliente[usersNumbers];
            for (x=0; x<usersNumbers; x++){
                addUser(user);
                Console.WriteLine(user[x]);
                usersNumbers --;
            }
            writeAccount(user, nameList);
        }
    }
}