namespace ReversiGameInProcessFunctionApp.Models
{
    public class OutStoneModel
    {
        /// <summary>
        /// 縦位置
        /// </summary>
        public int? Row { get; set; }

        /// <summary>
        /// 横位置
        /// </summary>
        public int? Col { get; set; }

        /// <summary>
        /// ステータス
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 碁石を置くことができたかどうか
        /// </summary>
        /// <remarks>Power Apps側のカスタムコネクタの戻り値がobject型が扱えないため、碁石のプロパティに持つ</remarks>
        public bool? IsPutStone { get; set; }
    }
}
