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

            filters2.Add(new Tech(){ExperienceYears = 1, Name = "Java"});
            filters2.Add(new Tech(){ExperienceYears = 1, Name = "C#"});

            
            

            

            var cands= new List<Candidate>();
            
            cands.Add(
                new Candidate()
                {
                    Name = "A",
                    Techs = new List<Tech>()
                    {
                        new Tech(){ExperienceYears = 1, Name = "Java"}
                    }
                }
                );

            cands.Add(
                new Candidate()
                {
                    Name = "B",
                    Techs = new List<Tech>()
                    {
                        new Tech(){ExperienceYears = 5, Name = "Java"}
                    }
                }
            );

            cands.Add(
                new Candidate()
                {
                    Name = "C",
                    Techs = new List<Tech>()
                    {
                        new Tech(){ExperienceYears = 5, Name = "C#"}
                    }
                }
            );

            cands.Add(
                new Candidate()
                {
                    Name = "D",
                    Techs = new List<Tech>()
                    {
                        new Tech(){ExperienceYears = 3, Name = "C#"},
                        new Tech(){ExperienceYears = 2, Name = "Java"},
                    }
                }
            );

            //var filters = new List<Func<Candidate, Tech>>();
            //var result = FilterCands(cands, filters, new Tech());

            var f1 = new Filter(){Duration = 1, Name="C#"};
            var f2 = new Filter(){Duration = 1, Name="Java"};
            //var f3 = new Filter(){Duration = 1, Name="Javascript"};
            
            var filters = new List<Filter>() {f1,f2};

            var r = cands.Where(AppropriateExperienceExists(filters));







        }

        static Func<Candidate, bool> AppropriateExperienceExists(List<Filter> filters)
        {
            Func<Candidate, bool> complexFilter = cand =>
            {
                foreach (var filter in filters)
                {
                    bool found = false;
                    
                    foreach (var tech in cand.Techs)
                    {
                        if (tech.Name == filter.Name & tech.ExperienceYears >= filter.Duration)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        return false;
                    }
                }
                return true;
            };

            return complexFilter;
        }









    }

    public class Tech
    {
        public string Name { get; set; }
        public int ExperienceYears { get; set; }
    }

    public class Filter
    {
        public string Name { get; set; }
        public int Duration { get; set; }
    }

    public class Candidate
    {
        public string Name { get; set; }
        public List<Tech> Techs { get; set; }
    }

    
}
