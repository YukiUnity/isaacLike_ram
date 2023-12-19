using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUpFeedBack : MonoBehaviour
{
    public void isCoinPickUped()
    {
        simdata.Score += 50;
    }
}
