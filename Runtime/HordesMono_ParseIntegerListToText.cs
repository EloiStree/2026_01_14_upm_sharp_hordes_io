using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Eloi.HordesIO
{
    public class HordesMono_ParseIntegerListToText : MonoBehaviour
    {
        public UnityEvent<string> m_onRelayIntegerAsText;
        public string m_separation = ",";
        public void PushIntegerToParseAsText(int integer)
        {
            m_onRelayIntegerAsText.Invoke("" + integer);
        }
        public void PushIntegerToParseAsText(int[] integers)
        {
            m_onRelayIntegerAsText.Invoke(string.Join(m_separation, integers));
        }
        public void PushIntegerToParseAsText(List<int> integers)
        {
            m_onRelayIntegerAsText.Invoke(string.Join(m_separation, integers));
        }
    }
}