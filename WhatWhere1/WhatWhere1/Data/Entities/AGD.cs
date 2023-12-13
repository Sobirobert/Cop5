namespace WhatWhere.Data.Entities
{
    public class AGD : EntityBase
    {
        public AGD(string? name, string? location, int count, DateTime dateChange)
        {
            Name = name;
            Location = location;
            Count = count;
            DateChange = dateChange;
        }

        public AGD()
        {
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public int Count { get; set; }
        public DateTime DateChange { get; set; }

        public override string ToString() => base.ToString() + $", Name: {Name}, Count: {Count}, Location {Location}, DateTime - {DateChange} - (AGD)";
    }
}