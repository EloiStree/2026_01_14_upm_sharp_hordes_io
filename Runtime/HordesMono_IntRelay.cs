using UnityEngine;
using UnityEngine.Events;
namespace Eloi.HordesIO
{
    public class HordesMono_IntRelay : MonoBehaviour
    {

        public UnityEvent<int> m_onIntegerRelayed;
        public void PushIntegerInRelay(int integer)
        {

            m_onIntegerRelayed.Invoke(integer);
        }
    }
}