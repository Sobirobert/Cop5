namespace WhatWhere.Data.Entities
{
    public interface IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Count { get; set; }
    }
}