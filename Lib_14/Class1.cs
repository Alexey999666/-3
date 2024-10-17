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
        /// ����� ��� ���������� ���������� ��������� ������� �������� ��������������� ���� ��������� ����� �������.
        /// </summary>
        /// <param name="matrix"> ������� � ������� �� ���������� ����������</param>
        /// <param name="M"> ����� �����</param>
        /// <param name="N"> ����� ��������</param>
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

