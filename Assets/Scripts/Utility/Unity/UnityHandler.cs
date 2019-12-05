using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utility.Singleton;

namespace Utility.Unity
{
    public class UnityHandler : SingletonMonoBehaviour<UnityHandler>
    {
        private readonly List<CoroutineHandler> _coroutines = new List<CoroutineHandler>();
        
        /// <summary>
        /// CoroutineStarter Allows Call Unity's Coroutine from non-monobehaviour objects
        /// </summary>
        /// <param name="coroutine">coroutine to start</param>
        /// <param name="tag">Specify type of routine or state</param>
        public void StartCoroutine(IEnumerator coroutine,string tag = "default")
        {
            _coroutines.Add(new CoroutineHandler(coroutine,tag));
            base.StartCoroutine(coroutine);
        }

        /// <summary>
        /// If you really want to use stopCoroutine by 'name', just modify it.
        /// But u already use StopCoroutine(Coroutine) instead. "Sounds more safety"
        /// </summary>
        /// <param name="tag">Specify type of routine or state to stopAll from there</param>
        public new void StopCoroutine(string tag = "default")
        {
            var coroutines = _coroutines.Where(coroutine => coroutine.Tag == tag);
            foreach (var coroutine in coroutines)
            {
                base.StopCoroutine(coroutine.Coroutine);
                _coroutines.Remove(coroutine);
            }
        }
    }
}