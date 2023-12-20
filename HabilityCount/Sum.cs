using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabilityCount
{
    public class Sum
    {
        public static List<(string, int)> Users => new List<(string, int)>{
            ("Welvis", Welvis.sumStars()),
            ("Eduardo", Eduardo.sumStars()),
            ("Giuseppe", Giuseppe.sumStars()),
            ("Matheus", Matheus.sumStars()),
            ("Wilton", Wilton.sumStars()),
         };



        public static string View()
        {

            StringBuilder sb = new StringBuilder();

            foreach (var user in Users)
            {
                sb.AppendLine($"\t{user.Item1} - {user.Item2} estrelas\n");
            }

            var sumAll = Users.Sum(x => x.Item2);
            sb.AppendLine();
            sb.AppendLine($"Total de estrelas: {sumAll}");

            return sb.ToString();
        }

    }
}
