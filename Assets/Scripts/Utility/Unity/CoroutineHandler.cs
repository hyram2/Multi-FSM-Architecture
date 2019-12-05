using System.Collections;

namespace Utility.Unity
{
    public struct CoroutineHandler
    {
        public IEnumerator Coroutine;
        public string Tag;

        public CoroutineHandler(IEnumerator coroutine, string tag)
        {
            Coroutine = coroutine;
            Tag = tag;
        }
    }
}