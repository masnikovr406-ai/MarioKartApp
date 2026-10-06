using System;
using System.Collections.Generic;
using System.Linq;

namespace MarioKart.Core
{
    public class Logic
    {
        private readonly List<Racer> _racers = new();
        private int _nextId = 1;

        // создание гонщика
        public Racer AddRacer(string name, string weightClass, int speed, int coins)
        {
            var racer = new Racer
            {
                Id = _nextId++,
                Name = name,
                WeightClass = weightClass,
                Speed = speed,
                Coins = coins
            };
            _racers.Add(racer);
            return racer;
        }

        // чтение всех
        public List<Racer> GetAllRacers()
        {
            return new List<Racer>(_racers);
        }

        // id
        public Racer? GetRacerById(int id)
        {
            return _racers.FirstOrDefault(r => r.Id == id);
        }

        // изменение
        public bool UpdateRacer(int id, string name, string weightClass, int speed, int coins)
        {
            var racer = GetRacerById(id);
            if (racer == null) return false;

            racer.Name = name;
            racer.WeightClass = weightClass;
            racer.Speed = speed;
            racer.Coins = coins;
            return true;
        }

        // удаление
        public bool DeleteRacer(int id)
        {
            var racer = GetRacerById(id);
            if (racer == null) return false;
            return _racers.Remove(racer);
        }

        // биз функция легкий или тяжелый
        public List<Racer> FilterByWeight(string weightClass)
        {
            return _racers
                .Where(r => r.WeightClass.Equals(weightClass, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // биз функция найти быстрого
        public Racer? GetFastestRacer()
        {
            return _racers.OrderByDescending(r => r.Speed).FirstOrDefault();
        }
    }
}