using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System;
using LTA.Base;
using LTA.UI;
using TMPro;
namespace LTA.LTAPopUp
{
	public class PopUpText : BasePopUp
	{
		[SerializeField]
		protected TextMeshProUGUI txtTitle,txtMessage;
		
		//[SerializeField]
		//protected RectTransform rectTransform;

		public void Init(string message)
		{
			txtMessage.text = message;
			//StartCoroutine(ShowNormalMessage(message));
		}

		public void Init(string title,string message)
		{
			//if (txtTitle == null)
			//{
			//	txtTitle = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
			//	txtMessage = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
			//}
			txtTitle.text = title;
			Init(message);
			//StartCoroutine(ShowNormalMessage(message));
		}

		//IEnumerator ShowNormalMessage(string mes)
		//{
		//	mes = Utils.CutString(mes, 300);
		//	txtMessage.text = mes;
		//	yield return new WaitForEndOfFrame();
		//	if (rectTransform != null)
		//	{
		//		Vector2 OriSize = rectTransform.sizeDelta;
		//		rectTransform.sizeDelta = new Vector2(OriSize.x, Mathf.Clamp(txtMessage.preferredHeight, 300f, 500f) + 20);
		//	}

		//}

	}
}
