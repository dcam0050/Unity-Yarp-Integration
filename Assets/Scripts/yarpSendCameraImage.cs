using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

//this code receives a texture2D from a unity camera and converts it into a yarp image

public class yarpSendCameraImage : MonoBehaviour {

	public string sourcePortName;
	public string destPortName;
	public RenderTexture view;

	private int resWidth;
	private int resHeight;
	public Texture2D temp2D;
	private BufferedPortImageRgb imagePort;
	private ImageRgb texImage;

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Initialising Network ... ");
		Network.init();
		Debug.Log ("Initialising Port");
		imagePort = new BufferedPortImageRgb();
		Debug.Log ("Open Port");
		imagePort.open (sourcePortName);

		Debug.Log ("Connect Port");
		Network.connect(sourcePortName, destPortName);

		//RenderTexture.active = view;
		resWidth = view.width;
		resHeight = view.height;
		temp2D = new Texture2D(resWidth,resHeight, TextureFormat.ARGB32, false);
	}

	void Update ()
	{
		//prepare port
		texImage = imagePort.prepare();

		//set resolution and parameters of image
		texImage.resize(resWidth, resHeight);
		texImage.setTopIsLowIndex(false);
		texImage.setQuantum(1);
		
		texImage.zero(); //test
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		//set input texture as the active RenderTexture
		RenderTexture.active = view;

		//fill texture with render texture pixels
		temp2D.ReadPixels(new Rect(0,0,resWidth,resHeight),0,0);
		temp2D.Apply();

		Debug.Log ("Width = " + resWidth + " Height = " + resHeight);

		//extract byte array from Texture2D
		Color32[] pix = temp2D.GetPixels32();
		int numPix = temp2D.width * temp2D.height;

		//create pointer to texImage
		System.IntPtr imagePtr = texImage.getRawImage();
		int imageSize = texImage.getRawImageSize();
		byte[] byteArray = new byte[imageSize];

		//convert Color32 array into byte array
		int currLoc = 0;
		for (int i = 0; i < numPix; i++) 
		{
			Color currPix = pix[i];
			currLoc = i*3;
			byteArray[currLoc]=(byte)currPix.r;
			byteArray[currLoc+1]=(byte)currPix.g;
			byteArray[currLoc+2]=(byte)currPix.b;
		}

		System.IntPtr arrayPointer = Marshal.AllocHGlobal(imageSize);
		Marshal.Copy(byteArray, 0, imagePtr, imageSize);
		Marshal.FreeHGlobal(arrayPointer);

		texImage.setExternal (imagePtr, resWidth, resHeight);
		//send image
		imagePort.write();
	}

	public void changeRes (int newWidth, int newHeight)
	{
		resWidth = newWidth;
		resHeight = newHeight;
		temp2D.Resize(resWidth,resHeight);
	}
}
