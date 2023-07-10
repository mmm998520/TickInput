namespace GameDevTools.General
{
    /// <summary>
    /// 優化unity數學
    /// </summary>
    public class Mathff
    {
        /// <summary>
        /// 絕對值計算
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float abs(float value)
        {
            return value >= 0 ? value : -value;
        }
        /// <summary>
        /// 絕對值計算
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int abs(int value)
        {
            return value >= 0 ? value : -value;
        }
        /// <summary>
        /// 絕對值計算
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long abs(long value)
        {
            return value >= 0 ? value : -value;
        }
    }
}