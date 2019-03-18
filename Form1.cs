using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchForm
{
    public partial class Form1 : Form
    {
        // Class variables for generating random numbers

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        private static int[] arr = new int[100];

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadArray(arr);

            DisplayArray(arr);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int searchNumber;

            //int[] arr = new int[100];

            //loadArray(arr);

            //DisplayArray(arr);

            bool isInputNumeric = Int32.TryParse(SearchText.Text, out searchNumber);

            if (isInputNumeric == false)
                MessageBox.Show("Please enter a numeric value.");
            else
            {
                //loadArray(arr);

                //DisplayArray(arr);

                if (SeqSearch(arr, searchNumber) == true)
                    MessageBox.Show("Sequential Search found " + searchNumber + " in the array!");
                else
                    MessageBox.Show("Sequential Search did not find " + searchNumber + " in the array.");
            }

        }

        public static bool SeqSearch(int[] arr, int sValue)
        {
            for (int i = 0; i < arr.Length; i++)

                if (arr[i] == sValue)

                    return true;

            return false;
        }

        // This method loads up the array with random integers

        public static void loadArray(int[] arr)
        {
            int Min = 0;

            int Max = arr.Length * 10;

            for (int i = 0; i < arr.Length; i++)
            {

                int next = 0;

                while (true)
                {
                    next = RandomNumber(Min, Max);

                    if (!Contains(arr, next))

                        break;
                }

                arr[i] = next;
            }

        }

        //Function to get a random number 

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize

                return random.Next(min, max);
            }
        }

        // Using this to get unique numbers into the array

        public static bool Contains(int[] array, int val)
        {

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == val)
                    return true;
            }

            return false;

        }

        public static void DisplayArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine("");
        }
    }
}
