using System.Text;
namespace HabilityCount;

public static class Welvis
{
    public static string Name => "Welvis Silva Souza";
    public static List<(string, int)> Skills => new List<(string, int)>{
            ("Fundamentos de C#", 5),
            ("Habilidades Gerais de Desenvolvimento",5),
            ("Fundamentos de Banco de Dados",5),
            ("Fundamentos de C#", 3),
            ("Habilidades Gerais de Desenvolvimento", 4),
            ("Fundamentos de Banco de Dados", 5),
            ("Fundamentos basicos de ASP.NET Core", 2),
            ("ORM", 3),
            ("Injeção de Dependencia", 5),
            ("Caching", 1),
            ("Log Frameworks", 1),
            ("Banco de Dados", 5),
            ("API Cliente e Comunicação", 4),
            ("Comunicação em tempo real", 1),
            ("Mapeamento de Objeto", 5),
            ("Marcação de tarefas", 4),
            ("Testagem", 3),
            ("Micro-Serviços", 1),
            ("CI/CD", 2),
            ("Design e Arquitetura de software", 2),
            ("Bibliotecas de cliente", 2),
            ("Engine de template", 1),
            ("Bibliotecas adicionais", 1)
         };
    public static string View()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Nome: {Name}");
        sb.AppendLine();
        sb.AppendLine("Habilidades:");
        foreach (var skill in Skills)
        {
            sb.AppendLine($"\t{skill.Item1} - {skill.Item2} estrelas");
        }
        var sum = Skills.Sum(x => x.Item2);
        sb.AppendLine();
        sb.AppendLine($"Total de estrelas: {sum}");
        return sb.ToString();
    }
}
