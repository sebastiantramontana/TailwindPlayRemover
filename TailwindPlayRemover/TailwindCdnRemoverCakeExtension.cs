using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace TailwindPlayRemover;

public static class TailwindCdnRemoverCakeExtension
{
    [CakeMethodAlias]
    public static void RemoveTailwindCdn(this ICakeContext context, FilePath htmlFile)
        => TailwindCdnRemover.RemoveCdn(htmlFile.FullPath);
}
