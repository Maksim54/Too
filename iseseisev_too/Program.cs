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
            Console.WriteLine("Vali saali suurus:1,2,3");
            int suurus = int.Parse(Console.ReadLine());
            return suurus;
        }
        static int[,] saal = new int[,] { };
        static int kohad, read;
        static void Saali_taitmine(int suurus)
        {
            Random rnd = new Random();
            if (suurus == 1)
            {kohad = 20;read = 10;}
            else if (suurus==2)
            {kohad = 20;read = 20;}
            else
            {
                kohad = 30;
                read = 20;
            }
            saal = new int[read, kohad];
            for (int rida = 0; rida < read; rida++)
            {
                for (int koht = 0; koht < kohad; koht++)
                {
                    saal[rida, koht] = rnd.Next(0, 2);
                }
            }
        }

        static void Saal_ekraanile()
        {
            for (int rida = 0; rida < read; rida++)
            {
                for (int koht = 0; koht < kohad; koht++)
                {
                    Console.Write(saal[rida,koht]);
                }
                Console.WriteLine();
            }
        }

        static bool Muuk()
        {            
            Console.WriteLine("rida-->");
            int pileti_rida = int.Parse(Console.ReadLine());
            Console.WriteLine("koht-->");
            int pileti_koht = int.Parse(Console.ReadLine());
            if (saal[pileti_koht-1,pileti_rida-1]==0)
            {
                saal[pileti_rida - 1, pileti_rida - 1] = 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            int suurus = saali_suurus();
            Random rnd = new Random();
            Saali_taitmine(suurus);
            while (true)
            {
                Saal_ekraanile();
                bool ost = Muuk();
                Console.WriteLine(ost);
            }
            //Console.ReadLine();
        }
    }
}