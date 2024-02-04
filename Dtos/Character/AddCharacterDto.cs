using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Dtos.Character
{
    public class AddCharacterDto
    {
        public string name { get; set; } = "Ahmed";
        public int hitPoints { get; set; } = 100;
        public int strength { get; set; } = 10;
        public int defense { get; set; } = 10;
        public int intelligence { get; set; } = 10;
        public RpgClass rpgClass { get; set; } = RpgClass.Knight;
    }
}