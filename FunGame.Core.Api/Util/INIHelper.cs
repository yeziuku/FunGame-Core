﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FunGame.Core.Api.Util
{
    public class INIHelper
    {
        /*
         * 声明API函数
         */
        public string INIPath = System.Environment.CurrentDirectory.ToString() + @"\FunGame.ini";
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="INIPath">ini文件路径</param>
        public INIHelper(string INIPath = "")
        {
            if (INIPath != "")
                this.INIPath = INIPath;
        }

        /// <summary>
        /// 写入ini文件
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public void WriteINI(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, INIPath);
        }

        /// <summary>
        /// 读取ini文件
        /// </summary>
        /// <param name="Section">Section</param>
        /// <param name="Key">键</param>
        /// <returns>返回的值</returns>
        public string ReadINI(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(256);
            int i = GetPrivateProfileString(Section, Key, "", temp, 256, INIPath);
            return temp.ToString();
        }

        /// <summary>
        /// 查询ini文件是否存在
        /// </summary>
        /// <returns>是否存在</returns>
        public bool ExistINIFile()
        {
            return File.Exists(INIPath);
        }

        /// <summary>
        /// 初始化ini文件
        /// </summary>
        public void Init()
        {
            /**
             * Server
             */
            WriteINI("Server", "Name", "FunGame Server");
            WriteINI("Server", "Password", "");
            WriteINI("Server", "Describe", "Just Another FunGame Server.");
            WriteINI("Server", "Notice", "This is the FunGame Server's Notice.");
            WriteINI("Server", "Key", "");
            WriteINI("Server", "Status", "1");
            /**
             * Socket
             */
            WriteINI("Socket", "Port", "22222");
            WriteINI("Socket", "MaxPlayer", "20");
            WriteINI("Socket", "MaxConnectFailed", "0");
            /**
             * MySQL
             */
            WriteINI("MySQL", "DBServer", "localhost");
            WriteINI("MySQL", "DBPort", "3306");
            WriteINI("MySQL", "DBName", "fungame");
            WriteINI("MySQL", "DBUser", "root");
            WriteINI("MySQL", "DBPassword", "pass");
        }
    }
}
