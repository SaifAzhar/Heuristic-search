using System;
using System.Collections.Generic;

namespace ADS_Q6
{
    public class Lorry
    {
        public int Id { get; set; }
        public List<Brick> Bricks { get; set; }

        public Lorry(int id)
        {
            Id = id;
            Bricks = new List<Brick>();
        }

        public void AddBrick(Brick brick)
        {
            Bricks.Add(brick);
        }

        public void RemoveBrick(Brick brick)
        {
            Bricks.Remove(brick);
        }

        public double GetTotalWeight()
        {
            return Bricks.Sum(brick => brick.Weight);
        }
    }
}