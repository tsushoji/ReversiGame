namespace ReversiGameFunctionApp.Models.Params
{
    internal class ReturnStoneInModel
    {
        /// <summary>
        /// 石を置く前の盤面
        /// </summary>
        public List<StoneModel>? board { get; set; }

        /// <summary>
        /// 置く石の位置及び石の色
        /// </summary>
        public StoneModel? setBoard { get; set; }
    }
}
