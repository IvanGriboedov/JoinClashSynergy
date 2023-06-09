﻿using Model.Currency;
using Sources.Ads;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

namespace Sources.View.UI
{
	public class ExtraCoinsButton : MonoBehaviour, IUnityAdsShowListener
	{
		[SerializeField] private AdUnitId _ids;
		[SerializeField] private int _coinsForAd;
		
		private Wallet _wallet;

		public void Initialize(Wallet wallet)
		{
			_wallet = wallet;

			var button = GetComponent<Button>();
			button.onClick.AddListener(() => Advertisement.Show(_ids.Rewarded, this));
		}

		public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
		{
			
		}

		public void OnUnityAdsShowStart(string placementId)
		{
		}

		public void OnUnityAdsShowClick(string placementId)
		{
		}

		public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
		{
			if (showCompletionState != UnityAdsShowCompletionState.COMPLETED)
			{
				return;
			}
			_wallet.Add(_coinsForAd);
		}
	}
}