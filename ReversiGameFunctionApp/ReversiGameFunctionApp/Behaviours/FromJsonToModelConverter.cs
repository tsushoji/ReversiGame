using Newtonsoft.Json.Linq;
using ReversiGameFunctionApp.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ReversiGameFunctionApp.Behaviours 
{
    public class FromJsonToModelConverter
    {
        public FromJsonToModelConverter() { }

        public List<BoardModel> ConvertToBoardModelList(JArray jsonArray)
        {
            var result = new List<BoardModel>();
            foreach (JObject element in jsonArray)
            {
                
                result.Add(ConvertToBoardModel(element));
            }

            return result;
        }

        public BoardModel ConvertToBoardModel(JObject json)
        {
            return new BoardModel
                {
                    Row = Convert.ToInt32(json["row"]),
                    Col = Convert.ToInt32(json["col"]),
                    Status = Convert.ToInt32(json["status"]),
                };
        }
    }
}

