﻿namespace Milimoe.FunGame.Core.Library.SQLScript.Entity
{
    public class UserQuery
    {
        public const string TableName= "User";
        public const string Column_UID = "UID";
        public const string Column_Username = "Username";
        public const string Column_Password = "Password";
        public const string Column_RegTime = "RegTime";
        public const string Column_LastTime = "LastTime";
        public const string Column_LastIP = "LastIP";
        public const string Column_Email = "Email";
        public const string Column_Nickname = "Nickname";
        public const string Column_IsAdmin = "IsAdmin";
        public const string Column_IsOperator = "IsOperator";
        public const string Column_IsEnable = "IsEnable";
        public const string Column_OnlineState = "OnlineState";
        public const string Column_Credits = "Credits";
        public const string Column_Materials = "Materials";
        public const string Column_GameTime = "GameTime";
        public const string Select_Users = $"{Constant.Command_Select} {Constant.Command_All} {Constant.Command_From} {TableName}";

        public static string Select_Users_LoginQuery(string Username, string Password)
        {
            return $"{Select_Users} {Constant.Command_Where} {Column_Username} = '{Username}' and {Column_Password} = '{Password}'";
        }

        public static string Select_Users_Where(string Where)
        {
            return $"{Select_Users} {Constant.Command_Where} {Where}'";
        }

        public static string CheckLogin(string Username, string IP)
        {
            return @$"{Constant.Command_Update} {TableName} {Constant.Command_Set} {Column_LastTime} = '{DateTime.Now}', {Column_LastIP} = '{IP}'
                {Constant.Command_Where} {Column_Username} = '{Username}'";
        }

        public static string Register(string UserName, string Password, string Email)
        {
            return @$"{Constant.Command_Insert} {Constant.Command_Into} {TableName} ({Column_Username}, {Column_Password}, {Column_Email}, {Column_RegTime})
                {Constant.Command_Values} ('{UserName}', '{Password}', {Email}, '{DateTime.Now}')";
        }
    }
}
