namespace Game.Tools
{
    public static class LayerTools
    {
        public static bool EqualLayers(int layerMask, int layer2)
        {
            return (layerMask & (1 << layer2)) > 0;
        }
    }
}
