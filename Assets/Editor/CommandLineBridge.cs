/**
 * コマンドラインから起動したの関数の引数を受け取るクラス。
 *
 * @author wakameyy
 * @date   2015/09/05
 */
using System.Collections.Generic;

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
                // メソッド呼び出しのサブオプションがtrue
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
#if false
    public static void DebugMethod() 
    {
        string[] str = GetMethodParametors();
        test( str[0], str[1] );
    }

    public static void test ( string test1, string test2 )
    {
        UnityEngine.Debug.Log( test1 + " " + test2 );
    }
#endif
}
