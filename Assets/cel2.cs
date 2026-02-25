
using UnityEngine;

public class cel2 : MonoBehaviour
{
    public float zycie = 100f;
    public void Obrazenie(float ilosc)
    {
        zycie -= ilosc;
        if (zycie <= 0f)
        {
            smierc();
        }
    }
    void smierc()
    {
        Destroy(gameObject);
    }
}
