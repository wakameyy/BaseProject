/**
 * コマンドラインから起動したの関数の引数を受け取るクラス。
 * 
 * @author wakameyy
 * @date   2015/09/05
 */
using System.Collections.Generic;

namespace WakLib {
    ///<summary>
    /// string[] args = WakLib.CommnadLineBridge.GetMethodParametors();</br>
    /// のように呼び出せば取得できる。
    ///</summary>
    public static class CommandLineBridge {

        public static string[] GetMethodParametors()
        {
            const string EXECUTE_METHOD = "-executeMethod";

            string[] cmds = System.Environment.GetCommandLineArgs();
            List<string> args = new List<string>();
            bool isExecuteMethod = false;
            foreach( string str in cmds )
            {
                if( isExecuteMethod )
                {
                    // メソッド呼び出しのサブオプション
                    if( str.StartsWith("-") )
                    {
                        // 他のサブオプションのため、終了
                        break;
                    }
                    // 引数を追加
                    args.Add( str );
                }
                else
                {
                    isExecuteMethod = str == EXECUTE_METHOD;
                }
            }
            if( args.Count != 0 )
            {
                args.RemoveAt( 0 );
            }
            // 返す
            return args.ToArray();
        }
    }
}