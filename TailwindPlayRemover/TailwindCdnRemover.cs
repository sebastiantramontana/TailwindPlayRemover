using Cake.Core.Annotations;
using HtmlAgilityPack;

[assembly: CakeNamespaceImport("HtmlAgilityPack")]
namespace TailwindPlayRemover;

public static class TailwindCdnRemover
{
    public static void RemoveCdn(string htmlFileFullPath)
    {
        var htmlString = File.ReadAllText(htmlFileFullPath);

        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(htmlString);

        var head = htmlDoc.DocumentNode.SelectSingleNode("//head");

        if (head is null)
        {
            Console.WriteLine("Head node not found!");
            return;
        }

        const string targetSrc = "https://unpkg.com/@tailwindcss/browser@4";
        var tailwindCdnNode = head!.SelectSingleNode($"//script[@src='{targetSrc}']");

        if (tailwindCdnNode is null)
        {
            Console.WriteLine("Tailwind's cdn node not found!");
            return;
        }

        head.RemoveChild(tailwindCdnNode);
        htmlDoc.Save(htmlFileFullPath);
    }
}