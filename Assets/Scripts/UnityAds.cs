using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
    string GooglePlayID = "4087783";
    bool TestMode = true;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(GooglePlayID, TestMode);
    }

    public void displayInterstitialAd()
    {
        Advertisement.Show();
    }
}
