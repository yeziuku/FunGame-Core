﻿/**
 * 此文件保存State（状态）的枚举
 */
namespace Milimoe.FunGame.Core.Library.Constant
{
    public enum StartMatchState
    {
        Matching,
        Success,
        Enable,
        Cancel
    }

    public enum RoomState
    {
        Created,
        Closed,
        Matching,
        Gaming,
        Complete
    }

    public enum OnlineState
    {
        Offline,
        Online,
        Matching,
        InRoom,
        Gaming
    }

    public enum ClientState
    {
        Online,
        WaitConnect,
        WaitLogin
    }
}
