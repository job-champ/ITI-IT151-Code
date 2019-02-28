using System;

// Multidimensional Array Example
namespace Main
{

   class MatrixWork
   {
      // Class variables for generating random numbers
      private static readonly Random random = new Random(); 
      private static readonly object syncLock = new object(); 
      
      public static void Main( string[] args )
      {


	// this declares an integer 2D array or matrix with 3 row elements
	// and 3 column elements and initializes all of them to their 
	// default value which is zero
	int[,] mat1 = new int[3,3]; 
	int[,] mat2 = new int[mat1.GetLength(0), mat1.GetLength(1)];
	int[,] resultMat = new int[mat1.GetLength(0), mat1.GetLength(1)];

	// Load Matrices

	loadMatrix(mat1);
	loadMatrix(mat2);

	// Display Matrix 1 and Matrix 2
	
	Console.WriteLine("Matrix 1:");
	printMatrix(mat1);
	
	Console.WriteLine("Matrix 2:");
	printMatrix(mat2);

	// Multiply Matrix 1 and Matrix 2

	resultMat = multiplyMatrices(mat1, mat2);

	// Display the result of the multiplication
	
	Console.WriteLine("Matrix 1 * Matrix2:");
	printMatrix(resultMat);

	Console.ReadKey();


      }

      // This method loads up the matrix with random integers
      static void loadMatrix(int[,] mat)
      {
	int Min = 0;
	int Max = 20;

	for (int i = 0; i < 3; i++)
	{
		for(int j = 0; j < 3; j++)
		{
		    mat[i,j] = RandomNumber(Min, Max);
		}

        }
      }

      // This method multiplies matrices
      static int[,] multiplyMatrices(int[,] mat1, int[,] mat2)
      {
	    int[,] result = new int[mat1.GetLength(0), mat1.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < result.GetLength(0); k++)
                    {
                        result[i, j] += mat1[i, k] * mat2[k, j];
                    }
                }
            }

	    return result;
      }

      // This method prints the matrix
      static void printMatrix(int[,] mat)
      {
	for (int i = 0; i < 3; i++)
        {
        	for (int j = 0; j < 3; j++)
               	{
                   Console.Write(mat[i, j] + "\t");
                }
                Console.WriteLine();
        }
	Console.WriteLine();
      }
      
      //Function to get a random number 
      public static int RandomNumber(int min, int max)
      {
      	lock(syncLock) 
        { // synchronize
        	return random.Next(min, max);
        }
      }

   }
}
