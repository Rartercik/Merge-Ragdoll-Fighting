using Game.BodyComponents;

namespace Game.Tools
{
    public static class BodyTools
    {
        public static void ChangeAll(PartsChanger[] partsChangers, BodyPart[] parts)
        {
            foreach (var changer in partsChangers)
            {
                foreach (var part in parts)
                {
                    if (changer.BodyPartType == part.Type)
                    {
                        changer.Change(part.Prefab);
                    }
                }
            }
        }
    }
}
