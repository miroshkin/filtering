using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtering
{
    class Program
    {
        static void Main(string[] args)
        {
            var filters2 = new List<Tech>();

            filters2.Add(new Tech(){Duration = 1, Name = "Java"});
            filters2.Add(new Tech(){Duration = 1, Name = "C#"});

            
            

            

            var cands= new List<Cand>();
            
            cands.Add(
                new Cand()
                {
                    Name = "A",
                    Techs = new List<Tech>()
                    {
                        new Tech(){Duration = 1, Name = "Java"}
                    }
                }
                );

            cands.Add(
                new Cand()
                {
                    Name = "B",
                    Techs = new List<Tech>()
                    {
                        new Tech(){Duration = 5, Name = "Java"}
                    }
                }
            );

            cands.Add(
                new Cand()
                {
                    Name = "C",
                    Techs = new List<Tech>()
                    {
                        new Tech(){Duration = 5, Name = "C#"}
                    }
                }
            );

            cands.Add(
                new Cand()
                {
                    Name = "D",
                    Techs = new List<Tech>()
                    {
                        new Tech(){Duration = 3, Name = "C#"}
                    }
                }
            );

            var filters = new List<Func<Cand, Tech>>();
            

            var result = FilterCands(cands, filters, new Tech());

        }


        public static IEnumerable<Cand> FilterCands (IEnumerable<Cand> cands, IEnumerable<Func<Cand, Tech>> filters, Tech filterValue)
        {
            foreach (var filter in filters)
            {
                cands = cands.Where(d => filter(d).Duration >(filterValue.Duration) & filter(d).Name == filterValue.Name);
            }

            return cands;
        }

        

    }

    public class Tech
    {
        public string Name { get; set; }
        public int Duration { get; set; }
    }

    public class Cand
    {
        public string Name { get; set; }
        public List<Tech> Techs { get; set; }
    }

    
}
