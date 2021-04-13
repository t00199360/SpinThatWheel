
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class WheelAds : MonoBehaviour
{
    private RewardedAd rewardedAd;
    private BannerView bannerView;
    public Canvas rewardCanvas;
    int counter;
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("rewardCanvas");
        counter = 1;
        makeObjectInactive(obj);
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#endif
        this.rewardedAd = new RewardedAd(adUnitId);
        this.RequestBanner();
        this.RequestInterstitial();

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void makeObjectInactive(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void makeObjectActive(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void makeCanvasInactive()
    {
        makeObjectInactive(obj);
    }

    public void afterSpinAsk()
    {
        StartCoroutine(EndSpinAd());
    }

    public IEnumerator EndSpinAd()
    {
        Debug.Log("about to wait 9 seconds");
        yield return new WaitForSeconds(9);
        Debug.Log("waited for 9 seconds");
        obj.gameObject.SetActive(true);
    }


    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }

    private InterstitialAd interstitial;

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif
        Debug.Log("in reqint");
        if (counter < 1)
        {
            // Initialize an InterstitialAd.
            this.interstitial = new InterstitialAd(adUnitId);
            Debug.Log("initialised");
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            Debug.Log("request built");
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
            Debug.Log("in ad loaded");
        }
        counter--;
        if (counter < 0)
        {
            counter = 1;
        }
    }


    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            Debug.Log("showing reward ad");
            this.rewardedAd.Show();
        }
        else
        {
            Debug.Log("rewarded ad was not loaded!");
        }
        counter = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }
}