using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCache : MonoBehaviour
{
    [SerializeField] WaitForSeconds wait;

    class Compare : IEqualityComparer<float>
    {
        public bool Equals(float x, float y)
        {
            return x == y;
            //throw new System.NotImplementedException();
        }

        public int GetHashCode(float hash)
        {
            return hash.GetHashCode();
        }
    }

    static readonly Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>(new Compare());

    public static WaitForSeconds waitForSeconds(float fTemp)
    {
        WaitForSeconds waitForSeconds;

        if (dictionary.TryGetValue(fTemp, out waitForSeconds) == false)
        {
            dictionary.Add(fTemp, new WaitForSeconds(fTemp));
        }

        return waitForSeconds;
    }
}
