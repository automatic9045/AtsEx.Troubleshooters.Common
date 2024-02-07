using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AtsEx.PluginHost.Troubleshooting;

namespace AtsEx.Troubleshooters.Common
{
    public class Troubleshooter : ITroubleshooter
    {
        public bool Resolve(Exception exception)
        {
            if (exception is FileLoadException fileLoadException && exception.HResult == -2146233067) // 0x80131515
            {
                ErrorDialog.Show("ゾーン識別子により、ファイルの読込がブロックされました。", $"ファイル '{fileLoadException.FileName}' のゾーン識別子を削除してください。");
                return true;
            }
            else if (exception is BadImageFormatException && exception.HResult == -2146234341) // 0x8013101B
            {
                ErrorDialog.Show(".NET Framework のバージョンが一致しません。", "BVE Trainsim 5 の BveTs.exe.config が正しく編集されているかどうか確認してください。");
                return true;
            }
            else if (exception is KeyNotFoundException && exception.Message.Contains("パラメータ 'Material' をもつパブリックインスタンスメソッド"))
            {
                ErrorDialog.Show("想定されないバージョンの SlimDX が読み込まれました。", "コンピューターに SlimDX SDK がインストールされている場合は、アンインストールしてください。");
                return true;
            }

            return false;
        }
    }
}
