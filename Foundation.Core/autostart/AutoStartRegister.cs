using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using Fundation.Core;

namespace Fundation.Core
{
    public class AutoStartRegister
    {
        public static string ErrorInformation = "";
        private static string getAutoLogonMarkup(AutoLogonSystemState state)
        {
            #region
            if (state == AutoLogonSystemState.isStart)
                return AutoLogonDescribe.AUTOLOGON;
            else
                return AutoLogonDescribe.NOTAUTOLOGON;
            #endregion
        }
        /// <summary>
        /// 把所有自动登录并启动程序的信息写入注册表
        /// </summary>
        /// <param name="writeregisterinformation"></param>
        public static bool WriteAll(AutoStartInformation infor)
        {
            #region
            bool issuccess = false;
            try
            {

                RegistryKey myKeyMachine, myKeyUser;

                myKeyMachine = Registry.LocalMachine
                    .CreateSubKey(AutoStartInformation.RegistAutoLogonPath);
                myKeyMachine.SetValue(AutoStartInformation.KeyAutoLogon
                    , getAutoLogonMarkup(infor.AutologonState));
                myKeyMachine.SetValue(AutoStartInformation.KeyDefaultUserName
                    , infor.Username);
                myKeyMachine.SetValue(AutoStartInformation.KeyDefaultPassword
                    , infor.Password);

                myKeyUser = Registry.CurrentUser.CreateSubKey(
                    AutoStartInformation.RegistAutoLoadExePath);
                myKeyUser.SetValue(AutoStartInformation.KeyAutoloadPath
                    , infor.exefilepath);

                myKeyUser.Close();
                myKeyMachine.Close();
                issuccess = true;
            }
            catch (System.Security.SecurityException)
            {
                ErrorInformation = "不允许修改注册表，请检查杀毒软件是否关闭，并要用管理员身份运行程序！";
            }
            catch (Exception ex)
            {
                ExtConsole.Write(ex.GetType().ToString());
                ErrorInformation = "写入注册表失败，请以管理员身份运行程序！";
            }
            return issuccess;
            #endregion
        }

        /// <summary>
        /// 从注册表读取所有自动登录并启动程序的信息
        /// </summary>
        /// <param name="infor"></param>
        public static void ReadAll(AutoStartInformation infor)
        {
            #region
            RegistryKey myKey;

            myKey = Registry.LocalMachine.OpenSubKey(
                AutoStartInformation.RegistAutoLogonPath);

            object tmpvalue = myKey.GetValue(AutoStartInformation
                .KeyAutoLogon);
            infor.AutologonState = (tmpvalue != null) ?
                (AutoStartState.GetAutoLogonState(tmpvalue.ToString())) 
                : AutoLogonSystemState.notStart;

            tmpvalue = myKey.GetValue(AutoStartInformation
                .KeyDefaultUserName);
            infor.Username = (tmpvalue != null) ?
                (tmpvalue.ToString()) : "";

            tmpvalue = myKey.GetValue(AutoStartInformation
                .KeyDefaultPassword);
            infor.Password = (tmpvalue != null) ?
                (tmpvalue.ToString()) : "";

            myKey = Registry.CurrentUser.OpenSubKey(AutoStartInformation
                .RegistAutoLoadExePath);
            tmpvalue = myKey.GetValue(AutoStartInformation
                .KeyAutoloadPath);
            infor.exefilepath = (tmpvalue != null) ?
                (tmpvalue.ToString()) : ""; 
            myKey.Close();
            #endregion
        }

        #region bhlfy注释
        /*
        /// <summary>
        /// 修改注册表，LocalMachine下面的值，写单个键
        /// </summary>
        /// <param name="WhetherStart">写入注册表的值</param>
        /// <param name="RegistPosition">修改注册表的位置</param>
        public static void RegistAddMessage(string keyname, object keyvalue)
        {
            try
            {
                using (RegistryKey myKey = Registry.LocalMachine.CreateSubKey(RegistPosition))
                {
                    myKey.SetValue(keyname, keyvalue);
                }
            }
            catch
            {throw;}
        }
        
        /// <summary>
        /// 修改CurrentUser下面的键值
        /// </summary>
        /// <param name="keyname"></param>
        /// <param name="keyvalue"></param>
        public static void RegistCurrentUserAddMessage(string keyname, object keyvalue)
        {
            try
            {
                using (RegistryKey myKey = Registry.CurrentUser.CreateSubKey(AutoStartPosition))
                {
                    myKey.SetValue(keyname, keyvalue);
                }
            }
            catch (System.Security.SecurityException)
            { throw; }
            catch
            {throw;}
        }
        
        /// <summary>
        /// 读注册表信息LocalMachine下边的值
        /// </summary>
        /// <param name="keyname"></param>
        /// <param name="RegistPosition"></param>
        /// <returns></returns>
        public static string RegistReadMessage(string keyname)
        {
            string readRegist = "";
            try
            {
                using (RegistryKey myKey = Registry.LocalMachine.OpenSubKey(RegistPosition))
                {
                    if (myKey.GetValue(keyname) == null)                    
                        return readRegist;                    
                    //读自动登录系统的参数，是1时表示自动登录
                    readRegist = myKey.GetValue(keyname).ToString();
                }
            }
            catch (System.ArgumentException)
            { return readRegist; }
            catch (System.Security.SecurityException)
            { ExtMessage.Show("不允许修改注册表，请检查杀毒软件是否关闭，并且以管理员身份运行程序！"); }
            catch (Exception)
            { ExtMessage.Show("出现未知异常！"); }
            return readRegist;
        }
        
        /// <summary>
        /// 读注册表CurrentUser下面的值
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public static string RegistCurrentUserReadMessage(string keyname)
        {
            string readRegist = "";
            try
            {
                using (RegistryKey myKey = Registry.CurrentUser.OpenSubKey(AutoStartPosition))
                {
                    if (myKey.GetValue(keyname) == null)
                        return readRegist;
                    //读自动登录系统的参数，是1时表示自动登录
                    readRegist = myKey.GetValue(keyname).ToString();
                }
            }
            catch (System.ArgumentException)
            { ExtMessage.Show("指定注册表的目录不存在！请进行参数配置！"); }
            catch (System.Security.SecurityException)
            { ExtMessage.Show("不允许修改注册表，请检查杀毒软件是否关闭，并用管理员身份运行程序！"); }
            catch (Exception)
            { ExtMessage.Show("出现未知异常！"); }
            return readRegist;
        }

        /// <summary>
        /// 删除注册表键CurrentUser下面的
        /// </summary>
        /// <param name="sourse"></param>
        public static void deleteRegist(String keyname)
        {
            try
            {
                using (RegistryKey myKey = Registry.CurrentUser.OpenSubKey(AutoStartPosition, true))
                {
                    myKey.DeleteValue(keyname);
                }
            }
            catch (ArgumentException) { }
            catch (Exception e)
            { throw e; }
        }*/
        #endregion
    }
}
