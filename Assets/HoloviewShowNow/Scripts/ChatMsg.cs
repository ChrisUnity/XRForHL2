using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFramework;
using Holoview;

public class FriendListEvent : GlobalEventArgs
{
    public override int Id { get { return 10; } }
    public List<User> Friends=new List<User>();

    public override void Clear() {
        Friends.Clear();
    }
    public FriendListEvent Fill(List<User> friends )
    {
        Friends = friends;
        return this;
    }

}
public class CallResultEvent : GlobalEventArgs
{
    public override int Id
    {
        get
        {
            return 11;
        }
    }
    public bool Result;
    public override void Clear()
    {
        Result = false;
    }
    public CallResultEvent Fill(bool result)
    {
        Result = result;
        return this;
    }
}
public class AcceptConnectedEvent: GlobalEventArgs
{
    public override int Id
    {
        get
        {
            return 12;
        }
    }
    public bool Result;
    public override void Clear()
    {
        Result = false;
    }
    public AcceptConnectedEvent Fill(bool result)
    {
        Result = result;
        return this;
    }
}
public class LoginResultEvent : GlobalEventArgs
{
    public override int Id
    {
        get
        {
            return 13;
        }
    }
    public bool Result;
    public override void Clear()
    {
        Result = false;
    }
    public LoginResultEvent Fill(bool result)
    {
        Result = result;
        return this;
    }
}
