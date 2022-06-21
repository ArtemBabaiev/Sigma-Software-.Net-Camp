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
            Menu menu;
            try
            {
                MenuFileCotroller controller = new();
                menu = controller.LoadMenu();
                Console.WriteLine(menu);
                DialogContoller.WriteReportDialog(menu);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
