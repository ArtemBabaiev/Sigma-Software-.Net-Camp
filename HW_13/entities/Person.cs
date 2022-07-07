using HW_13.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.entities
{
    internal class Person
    {
        private readonly Guid id;
        private string name;
        private int age;
        private int timeToService;
        private Position pos;
        private Status status;
        #region construcotrs
        public Person(string name, int age, int timeToService, Position position, Status status)
        {
            id = Guid.NewGuid();
            Name = name;
            Age = age;
            TimeToService = timeToService;
            Position = position;
            Status = status;
        }
        #endregion

        #region properties
        public Guid Id => id;
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public int TimeToService { get => timeToService; set => timeToService = value; }
        internal Position Position { get => pos; set => pos = value; }
        internal Status Status { get => status; set => status = value; }
        #endregion
        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   id.Equals(person.id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }

        public override string? ToString()
        {
            return $"id: {id}, name:{name}, age:{age}, tts:{timeToService}, pos:{pos.ToString()}, status:{status}";
        }
    }
}
