using System;

namespace Modul5_FinalProekt
{
    class Program
    {

        //  метод проверки ввода возраста > 0:
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            {
                corrnumber = 0;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("проверьте запись, число должно быть целым и больше нуля");
                Console.BackgroundColor = ConsoleColor.Black;
                return true;
            }
        }


        // метод  проверки ввода пустой строки и чтобы в строке не было цифр, если строка пустая, просим ввести еще раз:
        static string Check(ref string chekname)
        {
            for (; chekname.Length < 1;)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Пустая строка или вы что-то не так написали, введите еще раз: ");
                chekname = Console.ReadLine();
                Console.BackgroundColor = ConsoleColor.Black;
                return Check(ref chekname);
            }

            while (int.TryParse(chekname, out int result))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите без цифр:");
                Console.BackgroundColor = ConsoleColor.Black;
                chekname = Console.ReadLine();

                return Check(ref chekname);

            }
            return chekname;

        }


        // метод ввода имени, фамилии, возраста, с проверкой методами Chek(ref ..) & ChekNum():
        static (string Name, string LastName, int Age) EnterUser()
        {
            (string Name, string LastName, int Age) User;

            Console.WriteLine("Введите имя: ");
            User.Name = Console.ReadLine();
            Check(ref User.Name);

            Console.WriteLine("Введите фамилию: ");
            User.LastName = Console.ReadLine();
            Check(ref User.LastName);
            string age;
            int intage;
            do
            {
                Console.WriteLine("Введите возраст цифрами: ");
                age = Console.ReadLine();

            } while (CheckNum(age, out intage));

            User.Age = intage;

            return User;



        }

        //  массив ввода кличек питомцев:

        static (int Petout, string[] NamePetoout) EnterUserPet()
        {
            (int Pet, string[] NamePet) UserPet;
            string num;
            int intnum;
            do
            {
                Console.WriteLine("Cколько у вас питомцев(цифрами): ");
                num = Console.ReadLine();
            }
            while (CheckNum(num, out intnum));
            UserPet.Pet = intnum;


            int k = UserPet.Pet;
            UserPet.NamePet = new string[k];
            Console.WriteLine("Введите его(их) имена, после ввода каждого имени нажмите клавишу \"Enter:\"", k);
            for (int i = 0; i < UserPet.NamePet.Length; i++)
            {
                UserPet.NamePet[i] = Console.ReadLine();
                Check(ref UserPet.NamePet[i]);
            }

            return UserPet;

        }

        // проверка есть ли питомцы:

        static string ChekPet(ref string chek)
        {
            if (chek == "да")
            {

                return chek;
            }
            else if (chek == "нет")
            {
                return chek;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("напишите да или нет!!!");
                Console.BackgroundColor = ConsoleColor.Black;
                chek = Console.ReadLine();
                return ChekPet(ref chek);
            }


        }
        // Вывод массива :
        static string[] NameArray(ref string[] namearray)
        {
            for (int i = 0; i < namearray.Length; i++)
            {
                Console.Write(" {0}\t ", namearray[i]);
            }
            return namearray;
        }




        static void Main(string[] args)
        {
            // переменные:
            string name;
            string lastname;
            int age;
            int pet = 0;
            string[] namepet = new string[pet];
            bool haspet = false;

            // Просим пользователя ввести  имя, фамилию, возраст:
            (name, lastname, age) = EnterUser();

            //Спрашиваем есть ли у пользователя питомцы, если да то записываем их в массив методом EnterUserPet():
            Console.WriteLine("{0}, у вас есть питомцы?(да или нет)", name);
            var result = Console.ReadLine();
            Check(ref result);
            ChekPet(ref result);
            if (result == "да")
            {
                (pet, namepet) = EnterUserPet();  // записываем питомцев
            }
            else
            {
                pet = 0; // нет 
            }
            string numcolor;
            int intnumcolor;
            do
            {
                Console.WriteLine("Укажите число любимых цветов: ");//  пока не введём число > 0  
                numcolor = Console.ReadLine();
            }
            while (CheckNum(numcolor, out intnumcolor));

            string[] favcolors = new string[intnumcolor]; //массив с цветами

            Console.WriteLine("Введите цвета:");

            for (int i = 0; i < favcolors.Length; i++)
            {
                favcolors[i] = Console.ReadLine();
                Check(ref favcolors[i]);
            }


            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nИмя: {0}\nФамилия: {1}\nВозраст: {2}", name, lastname, age);
            if (pet > 0)
            {
                Console.WriteLine("Питомцы: {0}", pet);
                Console.Write("Имена питомцев:");

                NameArray(ref namepet);
            }
            else
            {
                Console.WriteLine("Питомцы: {0}", pet);//Питомцы : 0 
            }

            Console.Write("\nЛюбимые цвета:");
            NameArray(ref favcolors);



            Console.ReadKey();

        }
    }
}