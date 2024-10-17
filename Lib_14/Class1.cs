using Microsoft.Win32;
using System.Data;
using System.IO;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
namespace Lib_14
{
   
    public class ClassCountElementsGreaterThanAverage
    {
        /// <summary>
        /// метод для нахождения количества элементов больших среднего арифметического всех элементов этого столбца.
        /// </summary>
        /// <param name="matrix"> матрица в которой мы производим вычисления</param>
        /// <param name="M"> число строк</param>
        /// <param name="N"> число столбцов</param>
        /// <returns></returns>
        public static int[] CountElementsGreaterThanAverage(int[,] matrix, int M, int N)
        {
            int[] counts = new int[N];

            for (int j = 0; j < N; j++)
            {
                double sum = 0;
                for (int i = 0; i < M; i++)
                {
                    sum += matrix[i, j];
                }
                double average = sum / M;

                int count = 0;
                for (int i = 0; i < M; i++)
                {
                    if (matrix[i, j] > average)
                    {
                        count++;
                    }
                }
                counts[j] = count;
            }

            return counts;
        }
    }
}

