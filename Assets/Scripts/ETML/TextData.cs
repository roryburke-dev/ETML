using UnityEngine;

namespace ETML
{
    [CreateAssetMenu(fileName = "TextData", menuName = "Scriptable Objects/TextData")]
    public class TextData : ScriptableObject
    {
        public Modifier modifier;
        public string text;
    }
}
