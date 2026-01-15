using UnityEngine;
using UnityEngine.Events;
namespace Eloi.HordesIO
{
    public class HordesMono_ParseIntegerToText : MonoBehaviour
    {
        public UnityEvent<string> m_onRelayIntegerAsText;
        public void PushIntegerToParseAsText(int integer)
        {
            m_onRelayIntegerAsText.Invoke("" + integer);
            //m_onRelayIntegerAsText.Invoke(integer.ToString());
        }
    }
}