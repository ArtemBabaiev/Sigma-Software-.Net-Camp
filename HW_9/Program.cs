using HW_9.controller;
using HW_9.entity;
using HW_9.service;
using System;
using System.Collections.Generic;
using System.IO;

namespace HW_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            try
            {
                MenuFileCotroller controller = new();
                Menu menu = controller.LoadMenu();
                Console.WriteLine(menu);
                controller.WritePrice(menu);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }
    }
}
