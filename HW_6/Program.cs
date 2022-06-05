using HW_6.Task1;
using HW_6.Task1.controller;
using HW_6.Task1.entity;
using HW_6.Task2;
using System;
using System.IO;
using System.Reflection;

namespace HW_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("**********************TASK 1****************************");
            Task1Demo.Start();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("**********************TASK 2****************************");
            Task2Demo.Start();

        }
    }
}
