using HW_13.entities;
using HW_13.eventArgs_classes;
using HW_13.generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13
{
    internal class StationWorkProcess
    {
        List<CashRegister> registers;
        private Report report;


        public StationWorkProcess(List<CashRegister> registers)
        {
            this.registers = registers;
            this.report = new Report();
        }

        public Report StartWork()
        {
            foreach (var item in registers)
            {
                item.OnMaxSizeAdding += OnAddingOverMaxHandler;
                item.OnStopWorking += OnStopWorkingHandler;
            }
            PersonGenerator generator = new();
            //набір люде при початку роботи всіх кас
            //УВАГА файл дана функція також очщує файл від данних для подальшого завантаження НОВИХ користувачів
            List<Person> people = generator.LoadFromFile();
            //розподілення початкових людей до касс
            ArrangeNewPeople(people);
            //так як люди вже закріплені за касою, очищуємо ліст
            people.Clear();


            while (true)
            {
                IsRegistersWorking();
                foreach (var register in registers)
                {
                    //перевірка чи закінчила роботу людина біля каси
                    if (register.ServedPerson?.TimeToService == 0)
                    {
                        report.AddLine($@"Served person {register.ServedPerson.Name} registry №{register.Number} at {DateTime.Now}");
                        register.ServedPerson = null;
                    }
                    //якщо ні зменшуємо її час
                    else if (register.ServedPerson is not null)
                    {
                        register.ServedPerson.TimeToService--;
                    }
                }


                //перевірка на наявність нових людей у списку
                people = generator.LoadFromFile();
                //розподілення по касах
                ArrangeNewPeople(people);
                //очистка списку
                people.Clear();

                //Призначення людей з вищим приіоритетом до порожнього обслугованого місця
                foreach (var register in registers)
                {
                    if (register.ServedPerson is null)
                    {
                        register.Next();
                    }
                }
                //перевірка чи є ще черги у кас
                bool isMoreWork = false;
                foreach (var register in registers)
                {
                    if (!register.IsNoQueue || register.ServedPerson is not null)
                    {
                        isMoreWork = true;
                    }
                }
                if (!isMoreWork)
                {
                    break;
                }
                Thread.Sleep(100);
            }
            return report;
        }

        private void ArrangeNewPeople(List<Person> people)
        {
            if (people.Count == 0)
            {
                return;
            }
            foreach (var person in people)
            {
                var working = (from reg in registers where reg.IsWorking && reg.IsAccepting select reg).ToList();
                int minQueue = working.Min(reg => reg.QueueLength);
                List<CashRegister> minRegisters =
                    (from reg in registers 
                     where reg.QueueLength == minQueue && reg.IsWorking && reg.IsAccepting  
                     select reg).ToList();
                if (minRegisters.Count == 1)
                {
                    minRegisters[0].Enqueue(person);
                    report.AddLine(@$"Added to cash registry {minRegisters[0].Number} person {person.Name} at {DateTime.Now}");
                }
                else
                {
                    double minDistanse = minRegisters.Min(reg => EvaluateDistance(reg, person));
                    CashRegister? register = minRegisters.Where(reg => EvaluateDistance(reg, person) == minDistanse).ToList()[0];
                    register.Enqueue(person);
                    report.AddLine(@$"Added to cash registry {register.Number} person {person.Name} at {DateTime.Now}");
                }
            }
        }

        private double EvaluateDistance(CashRegister register, Person person)
        {
            return Math.Sqrt(Math.Pow(register.Position.X - person.Position.X, 2) + Math.Pow(register.Position.Y - person.Position.Y, 2));
        }

        private void OnAddingOverMaxHandler(MaxQueueSizeEventArgs e)
        {

        }
        private void OnStopWorkingHandler(StopWorkingEventArgs e)
        {
            List<Person> people = new();
            if (e.Register.ServedPerson != null)
            {
                people.Add(e.Register.ServedPerson);
                e.Register.ServedPerson = null;
            }
            int temp = e.Register.QueueLength;
            for (int i = 0; i < temp; i++)
            {
                people.Add(e.Register.Dequeue());
            }
            //це метод перевіряє чи працює каса та чи приймає
            ArrangeNewPeople(people);
        }

        private void IsRegistersWorking()
        {
            string[] strings = File.ReadAllLines(@"txtData/Register.txt");
            Dictionary<int, bool> dict = new();
            foreach (var item in strings)
            {
                var data = item.Split(" ");
                dict.Add(int.Parse(data[0]), bool.Parse(data[1]));
            }
            foreach (var item in registers)
            {
                if (dict.ContainsKey(item.Number) && item.IsWorking != dict[item.Number])
                {
                    item.IsWorking = dict[item.Number];
                }
            }
        }
    }
}
