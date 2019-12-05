using System.Collections;
using UnityEngine;
using Utility.Unity;

namespace FSM.States
{
    public class WWWState : IBehaviourState
    {

        public void Start()
        {
            UnityHandler.Instance.StartCoroutine(GetAvatar(),"WWW");
        }

        public void Update()
        {
            //generic problems, do not need in www state :T
        }

        public void Exit()
        {
        
        }


        IEnumerator GetAvatar()
        {
            yield return new WaitForSeconds(0.1f);
        }
    }
}
