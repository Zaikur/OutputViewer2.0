using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *Quinton Nelson
 *5/3/2023
 *Cut class, object to store each cut
 */

namespace OutputViewer2._0
{
    internal class Cut
    {
        //Field Declarations
        public string? Job { get; set; }
        public string? Stack { get; set; }
        public string? Name { get; set; }
        public string? Part { get; set; }
        public string? Length { get; set; }
        public string? Width { get; set; }
        public string? Height { get; set; }
        public string? Grade { get; set; }

        //Constructor to make cut objects with default values
        public Cut() { }

        //Expression bodied onstructor to make cut objects with specified values
        public Cut(string job, string stack, string name, string part, string length, string width, string height, string grade)
        {
            Job = job;
            Stack = stack;
            Name = name;
            Part = part;
            Length = length;
            Width = width;
            Height = height;
            Grade = grade;
        }
    }
}
