/// Copyright (C) 2012-2014 Soomla Inc.
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///      http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.

using System;

namespace Soomla.Store
{
	/// <summary>
	/// This type of purchase allows users to purchase <c>PurchasableVirtualItems</c> with other 
	/// <c>VirtualItem</c>s.
	/// 
	/// Real Game Example: Purchase a 'Sword' in exchange for 100 'Gem's. 'Sword' is the item to be purchased,
	/// 'Gem' is the target item, and 100 is the amount.
	/// </summary>
	public class PurchaseWithVirtualItem : PurchaseType
	{
		private const string TAG = "SOOMLA PurchaseWithVirtualItem";

		/// <summary>
		/// The itemId of the item that will actually be taken for this purchase.
		/// </summary>
		public String TargetItemId;

		/// <summary>
		/// The amount we need to take when we purhcase.
		/// </summary>
		public int Amount;
		
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="itemId">The itemId of the <c>VirtualItem</c> that is used to "pay" in order 
		/// 					to make the purchase.</param>
		/// <param name="amount">The number of items (with the given item id) needed in order to make the 
		/// 					purchase.</param>
		public PurchaseWithVirtualItem (String targetItemId, int amount) :
			base()
		{
			this.TargetItemId = targetItemId;
			this.Amount = amount;
		}

		/// <summary>
		/// Buys the purchasable virtual item.
		/// Implementation in subclasses will be according to specific type of purchase.
		/// </summary>
		/// <param name="payload">a string you want to be assigned to the purchase. This string
		/// is saved in a static variable and will be given bacl to you when the
		///  purchase is completed.</param>
		/// <exception cref="Soomla.Store.InsufficientFundsException">throws InsufficientFundsException</exception>
		public override void Buy(string payload)
		{
			SoomlaUtils.LogDebug("SOOMLA PurchaseWithVirtualItem", "Trying to buy a " + AssociatedItem.Name + " with "
			                     + Amount + " pieces of " + TargetItemId);

			VirtualItem item = null;
			try {
				item = StoreInfo.GetItemByItemId(TargetItemId);
			} catch (VirtualItemNotFoundException) {
				SoomlaUtils.LogError(TAG, "Target virtual item doesn't exist !");
				return;
			}

			JSONObject eventJSON = new JSONObject();
			eventJSON.AddField("itemId", AssociatedItem.ItemId);
			StoreEvents.Instance.onItemPurchaseStarted(eventJSON.print());

			int balance = item.GetBalance();
			if (item is VirtualCurrency) {
				balance = VirtualCurrencyStorage.GetBalance(item);
			} else {
				balance = VirtualGoodsStorage.GetBalance(item);
			}

			if (balance < Amount){
				throw new InsufficientFundsException(TargetItemId);
			}

			item.Take(Amount);

			AssociatedItem.Give(1);

			eventJSON = new JSONObject();
			eventJSON.AddField("itemId", AssociatedItem.ItemId);
			eventJSON.AddField("payload", payload);
			StoreEvents.Instance.onItemPurchased(eventJSON.print());
		}
	}
}

