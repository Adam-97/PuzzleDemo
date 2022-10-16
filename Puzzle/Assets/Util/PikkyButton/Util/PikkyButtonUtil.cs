namespace Pikky.Button
{
    public class PikkyButtonUtil
    {
        public static float CalculatePercentage(int min, int max, int med) => (float)(med - min) / (max - min);
        public static float CalculatePercentage(float min, float max, float med) => (med - min) / (max - min);
    }
}