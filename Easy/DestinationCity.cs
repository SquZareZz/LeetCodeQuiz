using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Easy
{
    public class DestinationCity
    {
        public string DestCity(IList<IList<string>> paths)
        {
            var StartCitie = new Dictionary<string, string>();
            var DestinationCities = new HashSet<string>();
            foreach (var path in paths)
            {
                StartCitie[path[0]] = path[1];
                DestinationCities.Add(path[1]);
            }
            return DestinationCities.Where(x => !StartCitie.ContainsKey(x)).First();
        }
    }
}
