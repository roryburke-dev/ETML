using ETML.Utils;
using UnityEngine;

namespace ETML.Model.ScriptableObject
{
    [CreateAssetMenu(fileName = "SO_Profile", menuName = "Scriptable Objects/SO_Profile")]
    public class SO_Profile : UnityEngine.ScriptableObject
    {
        public ENUMProfile profile;
    }
}
