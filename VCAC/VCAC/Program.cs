/*
 * Created by Ranorex
 * User: Administrator
 * Date: 3/11/2014
 * Time: 7:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WinForms = System.Windows.Forms;
using Microsoft.Win32;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Reporting;
using Ranorex.Core.Testing;
using Globalization.Framework;

namespace ITBM
{
    class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
        
            Keyboard.AbortKey = System.Windows.Forms.Keys.Pause;
            int error = 0;
            Config.DepolyITBM = true;
            Config.DepolySSO= true;
            Config.DepolyVcac = true;
            Config.ConfigSSLSSO = true;
            
           Registry.LocalMachine.CreateSubKey(@"SOFTWARE\VMware, Inc.");

            try
            {
                error = TestSuiteRunner.Run(typeof(Program), Environment.CommandLine);
            }
            catch (Exception e)
            {
                Report.Error("Unexpected exception occurred: " + e.ToString());
                error = -1;
            }
            return error;
        }
    }
}
