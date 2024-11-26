using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace lesson1
{
    internal class Program
    {


        struct MyStruct
        {
            public int value;
            public int r;
            public int fff;


        }

        class MyClass
        {
            public int v;

            public int value;
        }


        //Q1

        static void ModifyClass(MyClass myClass)
        {
            myClass.value = 12;
            Console.WriteLine($"Inside ModifyClass: {myClass.value}");
        }
        static void ModifyStruct(MyStruct myStruct)
        {
            myStruct.value = 12;
            Console.WriteLine($"Inside ModifyStruct: {myStruct.value}");
        }

        static void ModifyStructByRef(ref MyStruct myStruct)
        {
            myStruct.value = 42;
            Console.WriteLine($"Inside ModifyStructByRef: {myStruct.value}");
        }



        //Q2

        static int counter = 0;
        static void Recursion()
        {
            int[] localArray = new int[100];
            MyStruct p1;
            //MyStruct p5, p6, p7, p8
            counter++;
            Console.WriteLine($"counter={counter}");
            Recursion();
        }


        //Q3



        public static void MemoryAllocationExperiment()
        {
            long baselineMemory = GC.GetAllocatedBytesForCurrentThread();
            int[] intArray = new int[100];
            long afterIntArray = GC.GetAllocatedBytesForCurrentThread();
            double[] doubleArray = new double[100];
            long afterDoubleArray = GC.GetAllocatedBytesForCurrentThread();

            string[] stringArray = new string[100];
            long afterStringArray = GC.GetAllocatedBytesForCurrentThread();


            MyStruct[] structArray = new MyStruct[100];
            long afterStructArray = GC.GetAllocatedBytesForCurrentThread();

            MyStruct[] structArray1 = new MyStruct[100];
            long afterStructArray1 = GC.GetAllocatedBytesForCurrentThread();

            MyClass[] classArray = new MyClass[100];
            long afterClassArray = GC.GetAllocatedBytesForCurrentThread();


            MyClass[] classArray1= new MyClass[100];
            long afterClassArray1 = GC.GetAllocatedBytesForCurrentThread();




            Console.WriteLine($"Baseline Memory: {baselineMemory} bytes");
            Console.WriteLine($"Int Array Allocation: {afterIntArray - baselineMemory} bytes");
            Console.WriteLine($"Double Array Allocation: {afterDoubleArray - baselineMemory} bytes");
            Console.WriteLine($"String Array Allocation: {afterStringArray - baselineMemory} bytes");
            Console.WriteLine($"MyStruct Array Allocation: {afterStructArray - baselineMemory} bytes");
            Console.WriteLine($"MyStruct Array Allocation: {afterStructArray1 - baselineMemory} bytes");
            Console.WriteLine($"MyClass Array Allocation: {afterClassArray - baselineMemory} bytes");
            Console.WriteLine($"MyClass Array Allocation: {afterClassArray1 - baselineMemory} bytes");

        }


        //Q4
        static void ExpandArray(ref int[] array) // ref הוספנו לפונקציה  
        {
            int[] oldArray = array;
            array = new int[oldArray.Length * 2];
            for (int i = 0; i < oldArray.Length; i++)
            {
                array[i] = oldArray[i];
                array[i + oldArray.Length] = oldArray[i];
            }
        }



        private static void Main(string[] args)
        {

            //Q1
            Console.WriteLine("---------Q1----------");
            Console.WriteLine();
            MyClass myClass = new MyClass();
            myClass.value = 10;
            ModifyClass(myClass);
            Console.WriteLine($"After ModifyClass: {myClass.value}");

            MyStruct myStruct = new MyStruct();
            myStruct.value = 10;
            ModifyStruct(myStruct);
            Console.WriteLine($"After ModifyStruct: {myStruct.value}");


            ModifyStructByRef(ref myStruct);
            Console.WriteLine($"After ModifyStructByRef: {myStruct.value}");




            //Q2
            //Recursion();

            //Q3
            Console.WriteLine("---------Q3----------");
            Console.WriteLine();
            MemoryAllocationExperiment();





            //Q4
            Console.WriteLine("---------Q4----------");
            Console.WriteLine();
            int[] a = { 1, 2, 3 };
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            ExpandArray(ref a); //ref מעבירים את המערך עם 
            Console.WriteLine();
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }


        }

    }


}
