using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrimesInInterval
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<int> primesInAnInterval(int from, int to)
        {
            List<int> listToReturn = new List<int>();
            int beginning;
            if (from > 2)
            {
                if (from % 2 == 0)
                {
                    beginning = ++from;
                }
                else
                {
                    beginning = from;
                }
            }
            else
            {
                beginning = 2;
            }

            for (int i = beginning; i <= to; i++)
            {
                bool isPrime = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    listToReturn.Add(i);
                }
            }

            return listToReturn;
        }

        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            primeNumbersListBox.Items.Clear();
            int intervalBegin;
            int intervalEnd;
            if (int.TryParse(beginBox.Text,out intervalBegin))
            {
                if (int.TryParse(endBox.Text, out intervalEnd))
                {
                    if (intervalBegin < intervalEnd)
                    {
                        if (intervalBegin > 0)
                        {
                            foreach (int singlePrimeNumber in primesInAnInterval(intervalBegin, intervalEnd))
                            {
                                primeNumbersListBox.Items.Add(singlePrimeNumber);  
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid input.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input.");
                }
            }
            else
            {
                MessageBox.Show("Invalid input.");
            }
        }
    }
}
