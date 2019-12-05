using UnityEngine;
using Utility.Singleton;

namespace Utility
{
    public class Settings : Singleton<Settings>
    {
        [Header("WWW")] 
        public string URL = "";
    }
}
