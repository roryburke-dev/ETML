using ETML.Utils.LinkedList;
using UnityEngine;

namespace ETML
{
    [CreateAssetMenu(fileName = "Text", menuName = "Scriptable Objects/Text")]
    public class Text : ScriptableObject
    {
        // Storing text and modifiers in relation
        public TextData[] data;
    }
}
