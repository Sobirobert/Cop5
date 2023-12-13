namespace WhatWhere.Data.Entities
{
    public abstract class EntityBase : IEntity
    {
        public EntityBase(string? name, string? location, int count, DateTime? changeDate)
        {
            Name = name;
            Location = location;
            Count = count;
            DateChange = changeDate;
        }

        public EntityBase()
        { }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int Count { get; set; }
        public DateTime? DateChange { get; set; }

        public override string ToString() => $"Id: {Id}";
    }
}