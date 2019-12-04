using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSM
{
    private List<IBehaviourCall> _currentCalls = new List<IBehaviourCall>();
    
    void Call<TBehaviourCall>() where TBehaviourCall : IBehaviourCall
    {
    }

    void VerifyActivity()
    {
        
    }
    void DisposeCall()
    {
        
    }

    
}
