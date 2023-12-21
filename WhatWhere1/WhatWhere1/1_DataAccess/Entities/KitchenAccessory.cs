namespace WhatWhere.Data.Entities
{
    public class KitchenAccessory : EntityBase
    {
        public KitchenAccessory(string? name, string? location, int count, DateTime dateChanges)
        {
            Name = name;
            Location = location;
            Count = count;
            DateChange = dateChanges;
        }

        public KitchenAccessory()
        {
        }

        public string? Name { get; set; }
        public string? Location { get; set; }
        public int Count { get; set; }
        public DateTime DateChange { get; set; }

        public override string ToString() => base.ToString() + $", Name: {Name}, Count: {Count}, Location: {Location}, DateTime - {DateChange}  - (KitchenAccessories)";
    }
}