namespace MarioKart.Core
{
    public class Racer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string WeightClass { get; set; } = "Средний"; 
        public int Speed { get; set; } 
        public int Coins { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Name} | Вес: {WeightClass} | Скорость: {Speed}/10 | Монеты: {Coins}";
        }
    }
}