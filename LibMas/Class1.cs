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

namespace LibMas
{
   
    /// <summary>
    /// ����� ��� ������ � ���������. � ��� ����������� ������ ��� ���������� �������, 
    /// �������� � ���������� ���������� �������, �������� � �������� �� �����.
    /// </summary>
    public class ArrayEditor
    {
        /// <summary>
        /// ������� � �������������� ������ ������� [-20;0)U(0;20]
        /// </summary>
        /// <param name="row"> ���������� �����, ��� �������� ������� </param>
        /// <param name="column"> ���������� �����, ��� �������� ������� </param>
        /// <returns> ������, ��������������������� ���������� ������� </returns>
        public static int[,] Generate(int row, int column)
        {
            Random rnd = new Random();
            int randomNum;
            int[,] arr = new int[row, column];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    do
                    {
                        randomNum = rnd.Next(50);
                    } while (randomNum == 0);
                    arr[i, j] = randomNum;
                }
            }
            return arr;
        }
        /// <summary>
        /// ����� ������ �� ����� ���������� *.txt �������� �������, � ���������� �� � ������
        /// </summary>
        /// <returns name="matr">
        /// ���������� ������, ���������� ������� �� ������������ �����, ��� null, ���� � ����� ���� �� �������� ������� ��� 
        /// ���� ������������ ������ ���������� ����.
        /// </returns>
        public static int[,] Open()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "��� ����� (*.*)|*.*| ��������� ����� (.txt) | *.txt";
            open.FilterIndex = 2;
            open.Title = "�������� �������";
            int row = 0;
            int column = 0;
            List<int> values = new List<int>();
            if (open.ShowDialog() == true)
            {
                using (StreamReader file = new StreamReader(open.FileName))
                {
                    while (!file.EndOfStream)
                    {
                        string line = file.ReadLine();
                        string[] valuesStr = line.Split(' ');
                        foreach (string valueStr in valuesStr)
                        {
                            if (Int32.TryParse(valueStr, out int value))
                            {
                                values.Add(value);
                                column++;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        row++;
                    }
                }
                column /= row;
                int indexList = 0;
                int[,] matr = new int[row, column];
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        matr[i, j] = values[indexList];
                        indexList++;
                    }
                }
                return matr;
            }
            return null;
        }
        /// <summary>
        /// ����� ���������� ������ � ���� ������� *.txt
        /// </summary>
        /// <param name="matr">������, ������� ���������� ���������</param>
        public static void Save(int[,] matr)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "��������� ����� (.txt) | *.txt";
            save.Title = "���������� �������";
            if (save.ShowDialog() == true && matr != null)
            {
                using (StreamWriter file = new StreamWriter(save.FileName))
                {
                    for (int i = 0; i < matr.GetLength(0); i++)
                    {
                        for (int j = 0; j < matr.GetLength(1); j++)
                        {
                            file.Write(matr[i, j].ToString());

                            // ��������� ������ ������ ���� ��� �� ��������� ������� ������
                            if (j < matr.GetLength(1) - 1)
                            {
                                file.Write(" ");
                            }
                        }
                        file.WriteLine();
                    }
                }
            }
        }
    }
    /// <summary>
    /// ����� ��� �������������� ������� � DataGrid, ��������� �������� ����� � ��������� ������ �������
    /// </summary>
    public static class VisualArray
    {
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            if (matrix != null)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    res.Columns.Add("" + (i), typeof(T));
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    var row = res.NewRow();

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        row[j] = matrix[i, j];
                    }

                    res.Rows.Add(row);
                }
            }

            return res;
        }
    }

}
