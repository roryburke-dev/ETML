using UnityEngine;

namespace ETML
{
    public class TextManager : MonoBehaviour
    {
        private TextManagerUtilities _utilities;

        private void Awake()
        {
            _utilities = new TextManagerUtilities();
        }
    }
}
