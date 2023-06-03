using System.Runtime.CompilerServices;

namespace Domain.Constants
{
    public enum SubjectId
    {
        Math = 1,
        Russian = 2,
        Informatics = 3,
        Biology = 4,
        SocialScience = 5,
        English = 6
    }

    public static class SubjectHelper 
    {
        private static HashSet<SubjectId> Main => new HashSet<SubjectId>() { SubjectId.Math, SubjectId.Russian };

        public static bool IsMain(SubjectId subject)
        {
            return Main.Contains(subject);
        }
    }
}
