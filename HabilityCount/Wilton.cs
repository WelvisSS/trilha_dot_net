using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabilityCount;

public static class Wilton
{
    public static string Name => "Wilton";
    public static List<(string, int)> Skills => new List<(string, int)>{
        ("Fundamentos de C#", 3),
        ("Habilidades Gerais de Desenvolvimento", 2),
        ("Fundamentos de Banco de Dados", 1),
        ("Fundamentos basicos de ASP.NET Core", 2),
        ("ORM", 0),
        ("Injeção de Dependencia", 1),
        ("Caching", 1),
        ("Log Frameworks", 1),
        ("Banco de Dados", 1),
        ("API Cliente e Comunicação", 2),
        ("Comunicação em tempo real", 1),
        ("Mapeamento de Objeto", 1),
        ("Marcação de tarefas", 1),
        ("Testagem", 1),
        ("Micro-Serviços", 1),
        ("CI/CD", 1),
        ("Design e Arquitetura de software", 2),
        ("Bibliotecas de cliente", 2),
        ("Engine de template", 1),
        ("Bibliotecas adicionais", 1)
         };
    public static int sumStars()
    {
        int sum = Skills.Sum(skill => skill.Item2);
        return sum;
    }
    public static string View()
    {
        var sb = new System.Text.StringBuilder();
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
