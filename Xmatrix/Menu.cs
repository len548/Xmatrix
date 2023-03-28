using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XmatrixType.Xmatrix;

namespace XmatrixType
{
    public class Menu
    {
        private Xmatrix x = new Xmatrix();

        public Menu() { }

        public void run()
        {
            int n;
            do
            {
                writeMenu();
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e) { n = -1; }   
                Console.Clear();
                switch (n)
                {
                    case 1:
                        printMatrix();
                        break;
                    case 2:
                        getElementAt();
                        break;
                    case 3:
                        setMatrix();
                        break;
                    case 4:
                        modifyElement();
                        break;
                    case 5:
                        Add();
                        break;
                    case 6:
                        Multiply();
                        break;
                }
            } while (n != 0);
        }

        public void writeMenu()
        {
            Console.WriteLine("Enter a number between 0 - 4 for a corresponding method!");
            Console.WriteLine("0. Quit - to quit the application.");
            Console.WriteLine("1. Print - to print the matrix.");
            Console.WriteLine("2. Get - to get the element at the index (i, j) of the matrix.");
            Console.WriteLine("3. Set - to set a new matrix.");
            Console.WriteLine("4. Modify - to modify one of the elements of the matrix.");
            Console.WriteLine("5. Add - to sum two matrices.");
            Console.WriteLine("6. Multiply - to mulitply the martix by another.");
            Console.Write(">>>>>>>>>>>>> ");
        }

        public void printMatrix()
        {
            Console.WriteLine(x);
        }
        
        public void modifyElement()
        {
            try
            {
                Console.Write("Enter the index of 'row' >>> ");
                int i = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the index of 'column' >>> ");
                int j = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Enter the number at matrix[{i}, {j}] >>> ");
                int newValue = Convert.ToInt32(Console.ReadLine());
                x.setEntry(i, j, newValue);
                Console.WriteLine($"The new number is set successfully! matrix[{i}, {j}]={x.getEntry(i, j)}\n");
            }
            catch (OutofIndexException oie)
            {
                Console.WriteLine("The number is a wrong index!");
            }
            catch (IndexOfZeroException ie)
            {
                Console.WriteLine("The element at this index is fixed with 0!");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine("The number has to be between -2^32 and 2^32 -1");
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The input is not a number!");
            }
        }
        public void setMatrix()
        {
            try
            {
                Console.Write("Enter the size of matrix >>> ");
                int s = Convert.ToInt32(Console.ReadLine());
                Xmatrix a = new Xmatrix(s);
                for(int i = 0; i < s; i++)
                {
                    for(int j = 0; j < s; j++)
                    {
                        if(a.isInDiagonals(i, j))
                        {
                            Console.Write($"Enter the integer at [{i}, {j}] >>> ");
                            int num = Convert.ToInt32(Console.ReadLine());
                            a.setEntry(i, j, num);
                        }
                    }
                }
                x = a;
                Console.Write("The new Xmatrix has been set:\n");
                printMatrix();

            }
            catch(InvalidSizeException ie)
            {
                Console.WriteLine("The size of the matrix has to be a postive odd number bigger than 2!");
            }
            catch(OverflowException oe)
            {
                Console.WriteLine("The number has to be between -2^32 and 2^32 -1");
            }
            catch(FormatException fe)
            {
                Console.WriteLine("The input is not a number!");
            }
            
        }
        public void getElementAt()
        {

            int i, j;
            try
            {
                Console.Write("Enter the index of 'row' >>> ");
                i = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the index of 'column' >>> ");
                j = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"matrix[{i}, {j}]={x.getEntry(i, j)}\n");
            }
            catch (FormatException fe)
            {
                Console.WriteLine("The input was in a wrong format!");
            }
            catch (OutofIndexException oe)
            {
                Console.WriteLine("Invalid indices, try again!\n");
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine("The The number has to be between -2^32 and 2^32 -1");
            }
        }

        public void Add()
        {
            Console.WriteLine($"Enter elements of a new Xmatrix added to the stored Xmatrix with the size of {x.getSize()}:");
            try
            {
                Xmatrix b = new Xmatrix(x.getSize());
                int n;
                for (int i = 0; i < x.getSize(); i++)
                {
                    for (int j = 0; j < x.getSize(); j++)
                    {
                        if (x.isInDiagonals(i, j))
                        {
                            Console.Write($"The number at [{i}, {j}] >>> ");
                            n = Convert.ToInt32(Console.ReadLine());
                            b.setEntry(i, j, n);
                        }
                    }
                }
                Console.WriteLine($"sum of the matrices:\n{x + b}");
            }
            catch (FormatException e)
            {
                Console.WriteLine("The input is not a number!");
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine("The The number has to be between -2^32 and 2^32 -1");
            }

        }

        public void Multiply()
        {
            Console.WriteLine($"Enter elements of a new Xmatrix multiplied by the stored Xmatrix with the size of {x.getSize()}:");
            try
            {
                Xmatrix b = new Xmatrix(x.getSize());
                int n;
                for (int i = 0; i < x.getSize(); i++)
                {
                    for (int j = 0; j < x.getSize(); j++)
                    {
                        if (x.isInDiagonals(i, j))
                        {
                            Console.Write($"The number at the matrix[{i}, {j}] >>> ");
                            n = Convert.ToInt32(Console.ReadLine());
                            b.setEntry(i, j, n);
                        }
                    }
                }
                Console.WriteLine($"Multiplication of the matrices:\n{x * b}");
            }
            catch (FormatException e)
            {
                Console.WriteLine("The input is not a number!");
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine("The The number has to be between -2^32 and 2^32 -1");
            }
        }
    }
}
