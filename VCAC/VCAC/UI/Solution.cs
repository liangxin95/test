/*
 * Created by Ranorex
 * User: Administrator
 * Date: 5/6/2014
 * Time: 5:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using System.Collections;
using Globalization.Framework;
using ITBM.UI;

namespace ITBM.UI
{
	public class Solution
	{
		public Solution()
		{
		}
		/// <summary>
		/// adding comment
		/// </summary>
		/// <param name="webdoc"></param>
		public static void waitforIEComplete(WebDocument webdoc){
			while (webdoc.State!="complete") {
				Delay.Seconds(1);
			}
		}
		
		/// <summary>
		/// adding comment
		/// </summary>
		/// <param name="webdoc"></param>
		public static string Clip2text(){
			return WinForms.Clipboard.GetText();
		}
		public static void text2Clip(string inputString){
			WinForms.Clipboard.SetText(inputString);
		}
		/// <summary>
		/// addming comment
		/// </summary>
		/// <param name="adapter"></param>
		public static void paste2Adapter(Adapter adapter){
			adapter.PressKeys("{CONTROL down}{akey}{CONTROL up}");
			adapter.PressKeys("{DELETE}");
			adapter.PressKeys("{CONTROL down}{vkey}{CONTROL up}");
		}
		
		
		
		public static void text22Adapter(string inputString,Adapter adapter){
			Solution.text2Clip(inputString);
			Solution.paste2Adapter(adapter);
		}
		/// <summary>
		/// exist already
		/// </summary>
		/// <param name="xPath"></param>
		/// <param name="duration"></param>
		public static void waitforElmDisappear(string xPath, Duration duration){
			Element elm;
			if(Host.Local.TryFindSingle(xPath,duration,out elm)){
				while(Host.Local.TryFindSingle(xPath,1000,out elm));
			}
		}
		public static void allowFirefoxAccess(){
			Element elm;
			if(Host.Local.TryFindSingle("/dom[@page='certerror']",300000,out elm)){
				WebDocument webdoc = "/dom[@page='certerror']";
				string  webElmIUnderstandTheRisk = "/dom[@page='certerror']//button[@onclick='toggle(''expertContent'');']";
				string  webElmAddException = "/dom[@domain='']//button[@id='exceptionDialogButton' and @visible='true']";
				if (Solution.FindNextElement(webElmIUnderstandTheRisk,webElmAddException))
					{((WebElement)webElmAddException).Click();}
				else
				{
					throw new Exception("Unexplected False valuse returned by function Solution.FindNextElement()");
				}
				CheckBox formElmPermanentlyStoreThisException = "/form[@class='MozillaDialogClass']//checkbox";
				Delay.Milliseconds(1000);
				formElmPermanentlyStoreThisException.Click();
				Button formElmConfirmSecurityException = "/form[@class='MozillaDialogClass']/button[@accessiblekeyboardshortcut!=null]";
				Delay.Milliseconds(1000);
				formElmConfirmSecurityException.Click();
		//		Solution.waitforIEComplete(webdoc);
			}
			else
			{
				throw new Exception("Failed to find the xpath /dom[@page='certerror']");
			}
		}
		/// <summary>
		///   After Clicking ParentElement,ChildElement will show up .If don't click ParentElement,Clild Element never show up.
		/// </summary>
		/// <param name="ParentElement">Already show up</param>
		/// <param name="Element">this paramenter will show up following clicking ParentElement</param>
		/// <param name="duration">within given time,If still not find out ClildElement,so abandon</param>
		public static bool FindNextElement(string ParentElement, string ClildElement){
			Element elm;
			bool flag=false;
			if(Host.Local.TryFindSingle(ParentElement,100000,out elm)){
				WebElement Parent = ParentElement;
				do{
					Parent.Click();
				    flag=Host.Local.TryFindSingle(ClildElement,100000,out elm);
				}
				while(!flag);
			}
			else
			{
				throw new Exception("Failed to find the xpath " + ParentElement);
			}
			return flag;
	
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="checkbox"></param>
		public static void checkTheCheckbox(InputTag checkbox){
			if(checkbox.Checked=="False"){
				checkbox.Click();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="checkbox"></param>
		public static void configff(){
			RxPath.DefaultSearchTimeout=30000;
			Host.Local.RunApplication("firefox");
			GUIUtility.WaitForExist("/form[@processname='firefox' and @active='True']//radiobutton[2]",20000);
            RadioButton a = "/form[@processname='firefox' and @active='True']//radiobutton[2]";
            a.Click();
            Delay.Seconds(1);
            Button b = "/form[@processname='firefox' and @active='True']/button[@accessiblestate='Default, Focusable']";
            b.Click();
            Delay.Seconds(1);
			CheckBox c1 = "/form[@class='MozillaDialogClass' and @active='True']/checkbox";
			c1.Click();
			Delay.Seconds(1);
            Button c2 = "/form[@class='MozillaDialogClass' and @active='True']/button[@accessiblestate='Focusable']";
            c2.Click();
            Delay.Seconds(1);
			Keyboard.Press("{control down}{shift down}{akey}{shift up}{control up}");
            Delay.Seconds(1);
            ListItem e = "/form[@processname='firefox' and @active='True']//listitem[@index='2' and @accessiblestate='Focusable, Selectable']";
            e.Click();
            Delay.Seconds(1);
            Button f = "/form[@processname='firefox' and @active='True']//listitem[@accessiblename~'^Ranorex']/button[2]";
            f.Click();
            Delay.Seconds(1);
            Button g = "/form[@processname='firefox' and @active='True']//text[@text='4.1.5.17134']/../button[1]";
            g.Click();
            Delay.Seconds(3);
            Element elemt;
            Host.Local.TryFindSingle("/form[@processname='firefox' and @active='True']//listitem[@accessiblename~'^Ranorex']",60000,out elemt);
            Host.Local.KillApplications("firefox");
            
            //禁掉火狐升级的代码
            Delay.Seconds(3);
            Host.Local.OpenBrowser("","firefox",true,true);
            Delay.Seconds(5);
            Keyboard.Press("{alt}");
            Delay.Seconds(1);
            Keyboard.Press("{left 2}");
            Delay.Seconds(1);
            Keyboard.Press("{down}");
            Delay.Seconds(1);
            Keyboard.Press("{up}");
            Delay.Seconds(1);
            Keyboard.Press("{enter}");
            Delay.Seconds(5);
            //GUIUtility.WaitForExist(UI.LC.ConfigFireforx.OptionDialogForm,120000);
			UI.ConfigFireforx.OptionDialogForm.MoveTo();
			Delay.Seconds(2);
			UI.ConfigFireforx.AdvancedListItem.Click();
			Delay.Seconds(2);
			UI.ConfigFireforx.UpdatePageTab.Click();
			Delay.Seconds(2);
			UI.ConfigFireforx.NeverUpdateRadioButton.Click();
			Delay.Seconds(2);
			UI.ConfigFireforx.OKButton.Click();
			Delay.Seconds(2);
			Host.Local.KillBrowser("firefox");
			Delay.Seconds(5);
		}
//		public static void checkTheCheckbox(LabelTag Lbcheckbox){
//			Lbcheckbox.Click();
//		}
		
}
}
