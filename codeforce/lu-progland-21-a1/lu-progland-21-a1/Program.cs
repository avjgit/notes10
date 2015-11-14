using System;
using System.Collections.Generic;
using System.Linq;
namespace lu_progland_21_a1{

    // Sākumā šo uzdevumu atrisināju man jau zināmajā programmēšanas valodā

    class Program    {
        static void Main(string[] args){
            var A = new List<Tuple<char, char>>(){
                new Tuple<char, char>('a', 'b')
            };

            var B = new List<Tuple<char, char>>(){
                new Tuple<char, char>('b', 'c'),
                new Tuple<char, char>('b', 'd'),
            };

            var C = new List<Tuple<char, char>>();

            foreach (var a in A)
                foreach (var b in B.Where(x => x.Item1 == a.Item2))
                    C.Add(new Tuple<char, char>(a.Item1, b.Item2));
        
            // šeit gan netiek nodrošināta unikalitāte
            foreach (var element in C)
                Console.WriteLine(element);
        }
    }
}
