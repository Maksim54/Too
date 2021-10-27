using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iseseisev_too
{
    class Program
    {
        static int saali_suurus()
        {
            Console.WriteLine("Choose the size of the hall: 1,2,3");//выбираем тип размера для зала 1,2 или 3
            int suurus = int.Parse(Console.ReadLine());
            return suurus;//возвращаем значение suurus
        }
        static int[,] saal = new int[,] { };//создаётся пустой двумерный массив
        static int[] ost = new int[] { };//хранит переменную ost и saal
        static int kohad, read,mitu,mitu_veel;
        static void Saali_taitmine(int suurus)//используется в качестве возвращаемого типа метода,чтобы указать,что метод не возвращает значение.
        {
            Random rnd = new Random();//генерируем значения kohad и read через random
            if (suurus == 1)//делается проверка
            {
                kohad = 20;read = 10;
            }
            else if (suurus==2)//делается проверка
            {
                kohad = 20;read = 20;
            }
            else
            {
                kohad = 30;
                read = 20;
            }
            saal = new int[read, kohad];//
            for (int rida = 0; rida < read; rida++)
            {
                for (int koht = 0; koht < kohad; koht++)
                {
                    saal[rida, koht] = rnd.Next(0, 2);
                }
            }
        }

        static void Saal_ekraanile()//
        {
            Console.Write("     ");//
            for (int koht = 0; koht < kohad; koht++)
            {
                if (koht.ToString().Length == 2)
                { Console.Write(" {0}", koht + 1); }
                else
                { Console.Write(" {0}", koht + 1); }
            }

            Console.WriteLine();//
            for (int rida = 0; rida < read; rida++)
            {
                Console.Write("Row " + (rida + 1).ToString() + ":");
                for (int koht = 0; koht < kohad; koht++)
                {

                    Console.Write(saal[rida, koht] + "  ");//к каждому номеру добавляется +1 тем самым увеличивает число пока не кончатся места в зале
                }
                Console.WriteLine();//пустая строка после окончания мест
            }
        }
        static int pileti_koht;

        static bool Muuk()
        {
            Console.WriteLine("Row:");//выбираем нужный нам ряд
            int pileti_rida = int.Parse(Console.ReadLine());
            Console.WriteLine("How many tickets you want?:");//записываем сколько билетов мы хотим купить
            mitu = int.Parse(Console.ReadLine());//
            ost = new int[mitu];//
            int p = (kohad - mitu) / 2;//
            bool t = false;//объявляем логическую переменную t
            int k = 0;//значение k приравниваем нулю
            do
            {
                if (saal[pileti_rida, p] == 0)//Если в зале место обозначено нулем,то оно является свободным
                {
                    ost[k] = p;
                    Console.WriteLine("place {0} is free", p);//отображает свободные места
                    t = true;
                }
                else
                {
                    Console.WriteLine("place {0} booked", p);//отображает места,которые забронированы
                    t = false;
                    ost = new int[mitu];
                    k = 0;//
                    p = (kohad - mitu) / 2;//
                    break;//делаем сброс переменной
                }
                p = p + 1;//+ к месту
                k++;
            } while (mitu != k);//в операторе while 
            if (t==true)
            {
                Console.WriteLine("your place is:");//отображает места,которые выбрал пользователь
                foreach (var koh in ost)//цикл начинается, первый элемент массива выбирается и присваивается переменной цикла
                {
                    Console.WriteLine("{0}\n", koh);
                }
            }
            else
            {
                Console.WriteLine("There are no vacancies in this row. Do you want to search in the second row?");//если место занято,то мы должны выбрать любое другое,которое свободно
            }
            return t;//возвращаем значение t
        }

        static bool muuk_ise()
        {
            Console.WriteLine("Row:");
            int pileti_rida = int.Parse(Console.ReadLine());
            Console.WriteLine("Row:");
            int pileti_koht = int.Parse(Console.ReadLine());
            if (saal[pileti_rida,pileti_koht] == 0)
            {
                saal[pileti_rida, pileti_koht] = 1;
            }
        }

        static void Main(string[] args)//
        {
            int suurus = saali_suurus();
            Saali_taitmine(suurus);//
            while (true)
            {
                Saal_ekraanile();
                int valik = int.Parse(Console.ReadLine());
                Console.WriteLine("1-own choice, 2-machine choice");
                if (valik == 1)
                {
                    int koh = 0;
                    Console.WriteLine("How many tickets want to buy?");
                    int kogus = int.Parse(Console.ReadLine());
                    bool muuk = false;
                    while (muuk!=true)
                    {
                        for (int i = 0; i < (kohad - 1) * (read - 1); i++)//kui valime 0-d
                        {
                            muuk = muuk_ise();
                            if (muuk) { koh++; }
                            if (koh==kogus) { break; }
                            {
                                koh++;
                            }
                            if (koh == kogus)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    bool muuk = false;
                    while (Muuk()!=true)
                    {
                        muuk=Muuk();
                    }
                }
            }
            Console.ReadKey();
            //Console.ReadLine();
        }
    }
}