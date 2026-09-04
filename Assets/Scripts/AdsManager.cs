using UnityEngine;
using GoogleMobileAds.Client;
using GoogleMobileAds.Api;
using System;

public class AdsManager : MonoBehaviour
{
    private RewardedAd rewardedAd;
    private InterstitialAd interstitialAd;
    private BannerView bannerView;

    // استبدل بـ Ad Unit IDs الخاصة بك من Google AdMob
    private string rewardedAdUnitId = "ca-app-pub-3940256099942544/5224354917"; // Test ID
    private string interstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712"; // Test ID
    private string bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111"; // Test ID

    private Action onRewardEarned;

    private void Start()
    {
        // Initialize Mobile Ads SDK
        MobileAds.Initialize();
        LoadBannerAd();
    }

    public void ShowRewardedAd(Action onComplete)
    {
        onRewardEarned = onComplete;
        LoadRewardedAd();
    }

    private void LoadRewardedAd()
    {
        var adRequest = new AdRequest();
        RewardedAd.Load(rewardedAdUnitId, adRequest, HandleRewardedAdLoaded);
    }

    private void HandleRewardedAdLoaded(RewardedAd ad, LoadAdError error)
    {
        if (error != null)
        {
            Debug.LogError("Failed to load rewarded ad: " + error);
            onRewardEarned?.Invoke();
            return;
        }

        rewardedAd = ad;
        ShowRewardedAdInternal();
    }

    private void ShowRewardedAdInternal()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Show((Reward reward) =>
            {
                Debug.Log("User earned reward!");
                onRewardEarned?.Invoke();
            });
        }
    }

    public void ShowInterstitialAd()
    {
        var adRequest = new AdRequest();
        InterstitialAd.Load(interstitialAdUnitId, adRequest, HandleInterstitialAdLoaded);
    }

    private void HandleInterstitialAdLoaded(InterstitialAd ad, LoadAdError error)
    {
        if (error != null)
        {
            Debug.LogError("Failed to load interstitial ad: " + error);
            return;
        }

        interstitialAd = ad;
        if (interstitialAd != null)
        {
            interstitialAd.Show();
        }
    }

    private void LoadBannerAd()
    {
        if (bannerView != null)
            bannerView.Destroy();

        var adRequest = new AdRequest();
        bannerView = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);
        bannerView.LoadAd(adRequest);
    }

    private void OnDestroy()
    {
        if (bannerView != null)
            bannerView.Destroy();
    }
}