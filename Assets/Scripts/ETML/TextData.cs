using UnityEngine;

namespace ETML
{
    [CreateAssetMenu(fileName = "TextData", menuName = "Scriptable Objects/TextData")]
    public class TextData : ScriptableObject
    {
        public ENUMModifier modifier;
        public string text;
    }
}
