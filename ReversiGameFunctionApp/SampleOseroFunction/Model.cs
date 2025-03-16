using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleOseroFunction
{
    /// <summary>
    /// JSON パース用の1セル分の要素
    /// </summary>
    /// <remarks>
    /// テストプロジェクトでも使用するだろうから internal ではなく public にしている。
    /// </remarks>
    public class Cell
    {
        public int row { get; set; }
        public int col { get; set; }
        public int status { get; set; }
    }

    /// <summary>
    /// http リクエストの JSON デシリアライズ用
    /// </summary>
    public class InParam
    {
        /// <summary>
        /// 石を置く前の盤面
        /// </summary>
        public List<Cell>? board { get; set; }

        /// <summary>
        /// 置く石の位置及び石の色
        /// </summary>
        public Cell? setBoard { get; set; }

    }

    /// <summary>
    /// http レスポンスの JSON シリアライズ用
    /// </summary>
    public class OutParam
    {
        /// <summary>
        /// 反転したかどうか。
        /// </summary>
        /// <remarks>
        /// 反転した場合 true、反転しなかった場合は false。
        /// 盤面を見て石を置こうとした位置に石が置かれていなければ反転しなかった（＝不正な位置に石を置いた）ことがわかるが、
        /// すでに石が置かれたいた位置に石を置こうとした場合は判別がつかないので追加した。
        /// 呼び出し側で、石を置こうとしている位置に、石が置かれていないことを事前に確認している場合はこのプロパティの参照は不要。
        /// </remarks>
        public bool isTurned { get; set; }

        /// <summary>
        /// 反転後の盤面
        /// </summary>
        public List<Cell>? board { get; set; }

    }

}
