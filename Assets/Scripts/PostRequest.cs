using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;


public class PostRequest : MonoBehaviour {

	public TextMesh displayTxt;

	private string url = "https://flask.sa-hackathon-06.cluster.extend.sap.cx";

	public UnityWebRequest request()
	{
		var req = new UnityWebRequest(url, "POST");
		Order order = new Order();
		string json = JsonUtility.ToJson(order, true);
		Debug.Log(json);
		byte[] rawBody = Encoding.UTF8.GetBytes(json);
		req.uploadHandler = (UploadHandler)new UploadHandlerRaw(rawBody);
		req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
		req.SetRequestHeader("Content-Type", "application/json");
		req.SendWebRequest();
		displayTxt.text = "Processing request...";
		StartCoroutine(Wait(req));
		if (req.error != null)
		{
			Debug.Log("Error: " + req.error);
		}
		else {
			Debug.Log("All ok");
			Debug.Log("Status Code: " + req.responseCode);
		}

		return req;

	}

	IEnumerator Wait(UnityWebRequest req)
	{
		print(Time.time);
		yield return new WaitForSeconds(15);
		print(Time.time);
		displayTxt.text = "Product Ordered!";
	}
}
