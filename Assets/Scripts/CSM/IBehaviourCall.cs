using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IBehaviourCall
{
    int GetActivity();

    void UnSubscribeAll();

    void Dispose();

}

public struct IHandle
{
    public int Time;
    public Type Type;
}