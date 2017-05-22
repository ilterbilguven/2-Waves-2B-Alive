using UnityEngine;
using UnityEngine.Advertisements;


/// <summary>
/// For using Unity's Ads Service.
/// </summary>
public class AdsController : MonoBehaviour
{
	public static void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
}