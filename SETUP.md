# 🎮 خطوات التثبيت والإعداد

## المتطلبات

- Unity 2022 LTS أو أحدث
- جهاز كمبيوتر يعمل بـ Windows/Mac/Linux
- حساب Google Play Developer
- حساب Google AdMob

## الخطوات

### 1. تثبيت Google Mobile Ads SDK

```
في Unity:
Window > TextMesh Pro > Import TMP Essential Resources
Window > Google Mobile Ads > Settings
```

### 2. الحصول على Ad Unit IDs

1. اذهب إلى [Google AdMob](https://admob.google.com)
2. أنشئ تطبيق جديد
3. انسخ:
   - App ID
   - Rewarded Ad Unit ID
   - Interstitial Ad Unit ID
   - Banner Ad Unit ID

### 3. تحديث AdsManager.cs

```csharp
// استبدل IDs الاختبار بـ IDs الحقيقية
private string rewardedAdUnitId = "your-rewarded-ad-unit-id";
private string interstitialAdUnitId = "your-interstitial-ad-unit-id";
private string bannerAdUnitId = "your-banner-ad-unit-id";
```

### 4. إعدادات اللعبة

- Player Settings > Package Name: `com.yourname.footballgame`
- Build Settings > Build APK للموبايل

### 5. الاختبار

استخدم Google AdMob Test Device IDs

## 🚀 النشر على Google Play

1. بناء APK نهائي
2. إنشاء حساب Google Play Developer ($25)
3. نشر التطبيق
4. الانتظار للموافقة (2-4 ساعات)

## 💰 تفعيل الإعلانات

بمجرد نشر التطبيق على Google Play، ستبدأ الإعلانات تظهر وتكسب منها!
