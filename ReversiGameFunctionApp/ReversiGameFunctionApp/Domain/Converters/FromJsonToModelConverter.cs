using Newtonsoft.Json.Linq;
using ReversiGameFunctionApp.Models;

namespace ReversiGameFunctionApp.Domain.Behaviours 
{
    internal class FromJsonToModelConverter
    {
        /// <summary>
        /// New
        /// </summary>
        public FromJsonToModelConverter() { }

        /// <summary>
        /// Json配列から碁石モデルリストへ変換
        /// </summary>
        /// <param name="jsonArray">Json配列</param>
        /// <returns></returns>
        public List<StoneModel> ConvertToBoardModelList(JArray jsonArray)
        {
            var result = new List<StoneModel>();
            foreach (JObject element in jsonArray)
            {
                
                result.Add(ConvertToBoardModel(element));
            }

            return result;
        }

        /// <summary>
        /// Jsonオブジェクトから碁石モデルへ変換
        /// </summary>
        /// <param name="json">Jsonオブジェクト</param>
        /// <returns>碁石モデル</returns>
        public StoneModel ConvertToBoardModel(JObject json)
        {
            return new StoneModel
                {
                    Row = Convert.ToInt32(json["row"]),
                    Col = Convert.ToInt32(json["col"]),
                    Status = Convert.ToInt32(json["status"]),
                };
        }
    }
}

