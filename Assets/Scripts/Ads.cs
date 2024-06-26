using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Ads : MonoBehaviour
{
    public YandexGame sdk;

    public void AdButton()
    {
        sdk._RewardedShow(1);
    }
    
}
