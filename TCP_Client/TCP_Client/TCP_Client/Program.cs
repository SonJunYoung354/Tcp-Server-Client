using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TCP_Client
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 프로그램 실행시 변경될 메인 폼
            Application.Run(new Form2());
        }
    }
}
