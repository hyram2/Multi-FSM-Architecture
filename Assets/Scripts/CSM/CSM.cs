using System.Collections.Generic;

namespace CSM
{
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
}
