using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowania
{
    class MergeSort
    {

        public static void sort(int[] tab)
        {
            int liczbaPrzedzialow;
            int from = 0;
            int przedzial1 = 1;
            int przedzial2 = 1;
            bool parzysta = tab.Length % 2 == 0 ? true : false;
            int n = 1;
            if (parzysta)
            {

            }
            while (przedzial1 < tab.Length)
            {
                from = 0;
                n = 1;
                for (;;)
                {
                    if (przedzial1 * n * 2<= tab.Length)
                    {
                        scalanie(tab, from, przedzial1, przedzial1);
                        from = from + przedzial1 * 2;
                        n++;
                        continue;
                    }
                    if (n == 1)
                    {
                        przedzial2 = tab.Length - przedzial1;
                        scalanie(tab, from, przedzial1, przedzial2); 
                    }
                    break;


                }
                przedzial1 = przedzial1 * 2;

            }

        }

        public static void scalanie(int[] tab, int from1, int przedzial1, int przedzial2)
        {
            //int[] tabWynikowa = new int[tab1.Length + tab2.Length];
            int licznik = from1;
            int tab1Licznik = 0, tab2Licznik = 0;

            int tab1LicznikTo = from1 + przedzial1;
            int tab2LicznikTo = tab1LicznikTo + przedzial2;

            int[] tab1 = new int[przedzial1];
            int[] tab2 = new int[przedzial2];
            for (int i = from1; i < tab1LicznikTo; i++)
            {
                tab1[i - from1] = tab[i];
            }
            for (int i = tab1LicznikTo; i < tab2LicznikTo; i++)
            {
                tab2[i - tab1LicznikTo] = tab[i];
            }

            while (licznik < from1 + przedzial1 + przedzial2)
            {

                if (tab1Licznik == przedzial1 && tab2Licznik < przedzial2)
                {

                    tab[licznik] = tab2[tab2Licznik];

                    tab2Licznik++;
                    licznik++;
                    continue;
                }
                if (tab2Licznik == przedzial2 && tab1Licznik < przedzial1)
                {
                    tab[licznik] = tab1[tab1Licznik];
                    tab1Licznik++;
                    licznik++;
                    continue;
                }
                if (tab1Licznik < przedzial1 && tab2Licznik < przedzial2 && tab1[tab1Licznik] < tab2[tab2Licznik])
                {
                    tab[licznik] = tab1[tab1Licznik];
                    tab1Licznik++;
                    licznik++;
                    continue;
                }
                if (tab1Licznik < przedzial1 && tab2Licznik < przedzial2 && tab1[tab1Licznik] > tab2[tab2Licznik])
                {

                    tab[licznik] = tab2[tab2Licznik];
                    tab2Licznik++;
                    licznik++;
                    continue;
                }

                if (tab1Licznik < przedzial1 && tab2Licznik < przedzial2 && tab1[tab1Licznik] == tab2[tab2Licznik])
                {

                    tab[licznik] = tab1[tab1Licznik];
                    tab1Licznik++;
                    licznik++;

                    tab[licznik] = tab2[tab2Licznik];
                    tab2Licznik++;
                    licznik++;
                    continue;
                }


            }

        }
    }
    class Sortowanie
    {
        public static int[] sort(int[] tab)
        {
            int tmp;
            int licznik = 0;
            int n = 0;
            do
            {
                licznik = 0;
                for (int i = 0; i < tab.Length - 1; i++)
                {

                    if (tab[i] > tab[i + 1])
                    {
                        licznik++;
                        tmp = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = tmp;
                    }
                }
                n++;
            } while (licznik != 0);
            //Console.WriteLine();
            //Console.WriteLine(licznik);
            //Console.WriteLine();
            //Console.WriteLine(n);
            return tab;
        }
    }
    class HeapSort
    {
        public static void sort(int[] array)
        {
            int elements = array.Length;
            for (int i = elements / 2 - 1; i >= 0; i--)
            {
                validateMaxHeap(array, elements, i);
            }
            for (int i = elements - 1; i > 0; i--)
            {
                swap(array, 0, i);
                elements--;
                validateMaxHeap(array, elements, 0);
            }
        }
        private static void validateMaxHeap(int[] array, int heapSize, int parentIndex)
        {
            int maxIndex = parentIndex;
            int leftChild = parentIndex * 2 + 1;
            int rightChild = parentIndex * 2 + 2;
            if (leftChild < heapSize && array[leftChild] > array[maxIndex])
            {
                maxIndex = leftChild;
            }
            if (rightChild < heapSize && array[rightChild] > array[maxIndex])
            {
                maxIndex = rightChild;
            }
            if (maxIndex != parentIndex)
            {
                swap(array, maxIndex, parentIndex);
                validateMaxHeap(array, heapSize, maxIndex);
            }
        }
        private static void swap(int[] array, int index1, int index2)
        {
            int tmp = array[index1];
            array[index1] = array[index2];
            array[index2] = tmp;
        }
    }
    class TestTable
    {
        private  Random r = new Random();
        public int[] testTable;
        public TestTable(int Lenght)
        {
            testTable = createTestTable(Lenght);
        }  
        public  int[] createTestTable(int Lenght)
        {
            int[] tab = new int[Lenght];
            for (int i = 0; i < tab.Length; i++)
            {
               
                tab[i] = r.Next(0, 100);
            }
            return tab;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestTable table1 = new TestTable(6000000);
            TestTable table2 = new TestTable(60000);
            TestTable table3 = new TestTable(6000000);

            DateTime startTest1 = DateTime.Now;
            MergeSort.sort(table1.testTable);
            DateTime endTest1 = DateTime.Now;
            TimeSpan timeMerge = endTest1 - startTest1 ;
            Console.WriteLine("timeMerge: " + timeMerge);
        
            //DateTime startTest2 = DateTime.Now;
            //Sortowanie.sort(table2.testTable);

            //DateTime endTest2 = DateTime.Now;
            //TimeSpan timeBuble = endTest2 - startTest2 ;
            //Console.WriteLine("timeBuble: " + timeBuble);

            DateTime startTest3 = DateTime.Now;
            HeapSort.sort(table3.testTable);

            DateTime endTest3 = DateTime.Now;
            TimeSpan timeHeap = endTest3 - startTest3;
            Console.WriteLine("timeHeap : " + timeHeap);
            //foreach (var item in table.testTable)
            //{
            //    Console.Write(item+"  ");
            //}
            //Console.WriteLine();
            //Console.WriteLine("---------------------------------");
            //MergeSort.sort(table.testTable);
            //foreach (var item in table.testTable)
            //{
            //    Console.Write(item + "  ");
            //}
            //Console.WriteLine();
            //Console.WriteLine("---------------------------------");
            Console.ReadKey();
        }
    }
}
