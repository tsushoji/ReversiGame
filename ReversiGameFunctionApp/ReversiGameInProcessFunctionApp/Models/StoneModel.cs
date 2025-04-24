namespace ReversiGameFunctionApp.Models
{
    public class StoneModel
    {
        /// <summary>
        /// New
        /// </summary>
        public StoneModel() { }

        /// <summary>
        /// 縦位置
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// 横位置
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// ステータス
        /// </summary>
        public int Status { get; set; }
    }
}

