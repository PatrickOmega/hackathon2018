using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public GameObject item1Details;
	public GameObject item1Notification;
	public OVRGrabbable item1;

	public PostRequest postRequest;

	private Vector3 item1OrigPosition;
	private Quaternion item1OrigRotation;

	// Use this for initialization
	void Start () {
		item1OrigPosition = item1.transform.position;
		item1OrigRotation = item1.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (item1.isGrabbed)
		{
			item1Details.SetActive(true);

			if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
			{
				item1Notification.SetActive(true);
				postRequest.request();
			}
		}
		else if (!item1.isGrabbed)
		{
			item1Details.SetActive(false);
			item1.transform.position = item1OrigPosition;
			item1.transform.rotation = item1OrigRotation;
		}


	}
}
