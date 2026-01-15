using UnityEngine;
using UnityEngine.Events;
namespace Eloi.HordesIO
{
    public class HordesMono_IntRelayerWithHistory : MonoBehaviour
    {

        public UnityEvent<int> m_onIntegerRelayed;
        public UnityEvent<int[]> m_onIntegerRelayedHistoryChanged;

        public int[] m_intHistory = new int[10];

        public void PushIntegerInRelay(int integer)
        {


            m_onIntegerRelayed.Invoke(integer);

            if (m_intHistory.Length == 0)
                return;    
            for (int i = m_intHistory.Length - 1; i >= 1; i--) { 
            
                m_intHistory[i] = m_intHistory[i-1];
            }
            m_intHistory[0] = integer;
            m_onIntegerRelayedHistoryChanged.Invoke(m_intHistory);
        }
    }
}