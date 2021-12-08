using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdManager : MonoBehaviour
{
    private void Awake()
    {
        LoadInter();
        LoadVideo();
    }
    private static Ad ad;

    public static void LoadBanner()
    {
        ad.LoadBanner();
    }

    public static void LoadInter()
    {
        Action onFailToLoad = () =>
        {
            LoadInter();
        };
        ad.LoadInter(null, onFailToLoad);
    }

    public static void LoadVideo()
    {
        Action onFailToLoad = () =>
        {
            LoadVideo();
        };
        ad.LoadVideo(null, onFailToLoad);
    }

    public static void IsInterReady()
    {
        ad.IsInterReady();
    }
    public static void IsVideoReady()
    {
        ad.IsVideoReady();
    }

    public static void ShowInter(Action onClose)
    {
        onClose += () =>
        {
            LoadInter();
        };
        ad.ShowInter(onClose);
    }

    public static void ShowVideo(Action onRewarded, Action onDidNotReward, Action onClose)
    {
        onClose += () =>
        {
            LoadVideo();
        };
        ad.ShowVideo(onRewarded, onDidNotReward, onClose);
    }

    public static void AddAd(Ad ad)
    {
        AdManager.ad = ad;
    }
}
