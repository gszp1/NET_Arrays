using System;

namespace Arrays
{
    public class Tests
    {
        public static int ConstructorsTests()
        {
            System.Console.WriteLine("---- Running constructors tests ----");
            if (ConstructorTest(1, 2, 5, false) == -1)
            {
                return -1;
            }

            if (ConstructorTest(2, 5, 5, false) == -1)
            {
                return -1;
            }

            if (ConstructorTest(3, 200, 200, false) == -1)
            {
                return -1;
            }

            if (ConstructorTest(4, 0, 0, true) == -1)
            {
                return -1;
            }

            if (ConstructorTest(5, -200, -200, true) == -1)
            {
                return -1;
            }

            Console.WriteLine("\n ++ Tests passed successfully ++ \n");
            return 0;
        }

        private static int ConstructorTest(int testId, int size, int expectedSize, bool expectedException)
        {
            AutoResizeArray<int> array;
            try
            {
                array = new(size);
            } catch (Exception) {
                if (expectedException)
                {
                    Console.WriteLine($"Test { testId } passed - Expected invalid size exception was thrown.");
                    return 0;
                } else
                {
                    Console.WriteLine($"Test { testId } failed - Expected invalid size exception was not thrown.");
                    return -1;
                }
            }
            if (array.AllocatedSize != expectedSize)
            {
                Console.WriteLine($"Test { testId } failed - Expected array size: { expectedSize } - Actual array size: {array.AllocatedSize}");
                return -1;
            }
            Console.WriteLine($"Test { testId } passed - Expected array size: { expectedSize } - Actual array size: { array.AllocatedSize }");
            return 0;
        }
        

        public static int AddTests()
        {
            System.Console.WriteLine("---- Running Add function tests ---- ");

            AutoResizeArray<string> arrayString = new(1);
            arrayString.Add("Hello World!");
            if (arrayString[0].Equals("Hello World!"))
            {
                Console.WriteLine($"Test {1} passed - Expected string: Hello World! - String at the end of array : {arrayString[arrayString.UsedSize - 1]}"); 
            } else
            {
                Console.WriteLine($"Test {1} failed - Expected string: Hello World! - String at the end of array : {arrayString[arrayString.UsedSize - 1]}");
                return -1;
            }

            AutoResizeArray<int> array = new(3);
            for (int i = 0; i < 20; ++i)
            {
                array.Add(i);
                if (array[i] == i)
                {
                    Console.WriteLine($"Test {i + 2} passed - Expected value : {i} - Value at the end of array {array.UsedSize - 1} : {array[array.UsedSize - 1]}");
                }
                else
                {
                    Console.WriteLine($"Test {i + 2} failed - Expected value : {i} - Value at the end of array {array.UsedSize - 1} : {array[array.UsedSize - 1]}");
                    return -1;
                }
            }

            Console.WriteLine("\n ++ Tests passed successfully ++ \n");
            return 0;
        }

        public static int IndexerTests()
        {
            System.Console.WriteLine("---- Running Indexer tests ---- ");

            AutoResizeArray<int> array = new(5);
            int exceptionCatched = 0;
            try
            {
                int i = array[-1];
            } catch(Exception)
            {
                Console.WriteLine($"Test {1} passed - Atempt of accessing data under negative index.");
                exceptionCatched = 1;
            }
            if (exceptionCatched == 0)
            {
                Console.WriteLine($"Test {1} failed - Atempt of accessing data under negative index.");
                return -1;
            }

            exceptionCatched = 0;
            try
            {
                int i = array[5];
            }
            catch (Exception)
            {
                Console.WriteLine($"Test {2} passed - Atempt of accessing data under larger than written cells index - Exception thrown.");
                exceptionCatched = 1;
            }
            if (exceptionCatched == 0)
            {
                Console.WriteLine($"Test {2} failed - Atempt of accessing data under larger than written cells index - Exception not thrown.");
                return -1;
            }

            exceptionCatched = 0;
            try
            {
                array[-1] = 5;
            }
            catch (Exception)
            {
                Console.WriteLine($"Test {3} passed - Atempt of writing data under negative index - Exception thrown.");
                exceptionCatched = 1;
            }
            if (exceptionCatched == 0)
            {
                Console.WriteLine($"Test {3} failed - Atempt of writing data under negative index - Exception not thrown.");
                return -1;
            }
            exceptionCatched = 0;
            try
            {
                array[200] = 5;
            }
            catch (Exception)
            {
                Console.WriteLine($"Test {4} failed - Atempt of writing data under larger than allocated cells index - Exception thrown.");
                return -1;
            }
            if (exceptionCatched == 0)
            {
                Console.WriteLine($"Test {4} passed - Atempt of writing data under larger than allocated cells index\n" +
                    $" - Written data: {array[200]} - allocatedSize before: 5 - Current allocatedSize: {array.AllocatedSize} - Current usedSize: {array.UsedSize}\n" +
                    $" - Written under index: {200}");
            }

            Console.WriteLine("\n ++ Tests passed successfully ++ \n");
            return 0;
        }

        public static int ResizeTests()
        {
            System.Console.WriteLine("---- Running reshape tests ---- ");

            int testId = 1;
            int expectedSize = 12;
            AutoResizeArray<int> array = new(5);
            for (int i = 0; i < 30; ++i)
            {
                array.Add(i);
                Console.WriteLine($"Added element: {array[i]} - Allocated size: {array.AllocatedSize} - Used size: {array.UsedSize}");
                if (i == 6 || i == 13 || i == 27)
                {
                    if (array.AllocatedSize != expectedSize)
                    {
                        Console.WriteLine($"\nTest {testId} failed - Expected size: {expectedSize} - Actual size: {array.AllocatedSize}\n");
                        return -1;
                    }
                    Console.WriteLine($"\nTest {testId} passed - Expected size: {expectedSize} - Actual size: {array.AllocatedSize}\n");
                    ++testId;
                    expectedSize = (expectedSize + 1) * 2;
                }
            }

            Console.WriteLine("\n ++ Tests passed successfully ++ \n");
            return 0;
        }

        public static int ToStringTests()
        {
            System.Console.WriteLine("---- Running ToString function tests ---- ");
            AutoResizeArray<int> array = new(5);
            for (int i = 0; i < 5; ++ i)
            {
                array.Add(i);
            }
            string expectedString = "0.| 0\n1.| 1\n2.| 2\n3.| 3\n4.| 4\n";
            if (expectedString.Equals(array.ToString()) == false) {
                System.Console.WriteLine($"Test {1} failed - Expected string:\n{expectedString}Actual string:\n{array}");
                return -1;
            }
            System.Console.WriteLine($"Test {1} passed - Expected string:\n{expectedString}Actual string:\n{array}");

            AutoResizeArray<string> stringArray = new(5);
            stringArray.Add("Hello World!");
            stringArray.Add("Integer");
            stringArray.Add("Double");
            expectedString = "0.| Hello World!\n1.| Integer\n2.| Double\n";
            if (expectedString.Equals(stringArray.ToString()) == false)
            {
                System.Console.WriteLine($"Test {2} failed - Expected string:\n{expectedString}Actual string:\n{stringArray}");
                return -1;
            }
            System.Console.WriteLine($"Test {2} passed - Expected string:\n{expectedString}Actual string:\n{stringArray}");
            Console.WriteLine("\n ++ Tests passed successfully ++ \n");
            return 0;
        }

        public static void RunTests()
        {
            int testResult = 0;
            testResult += ConstructorsTests();
            testResult += AddTests();
            testResult += IndexerTests();
            testResult += ToStringTests();
            testResult += ResizeTests();
            if (testResult == 0)
            {
                Console.WriteLine("\n +++ All tests passed +++ \n");
            } else
            {
                Console.WriteLine("\n --- Not all tests passed --- \n");
            }
        }
    }

}
