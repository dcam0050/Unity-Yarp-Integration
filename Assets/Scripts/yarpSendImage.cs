using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class yarpSendImage : MonoBehaviour {
	
	public string sourcePortName;
	public string destPortName;
	public RenderTexture view;

	private int resWidth;
	private int resHeight;
	public Texture2D temp2D;
	private BufferedPortImageRgb imagePort;
	
	YarpImageCheckWrite writeImageThread;

	// Use this for initialization
	void Start () {
		Network.init();
		if(sourcePortName != null)
		{
			Debug.Log ("Initialising Network ... ");
			Network.init();
			Debug.Log ("Initialising Port");
			imagePort = new BufferedPortImageRgb();
			Debug.Log ("Open Port");
			imagePort.open (sourcePortName);

			Debug.Log ("Connect Port");
			Network.connect(sourcePortName, destPortName);
			
			writeImageThread = new YarpImageCheckWrite();
			writeImageThread.imagePort = imagePort;
			resWidth = view.width;
			resHeight = view.height;
			writeImageThread.resWidth = resWidth;
			writeImageThread.resHeight = resHeight;

			bool checkInit = writeImageThread.InitVariables();

			if(checkInit)
			{
				Debug.Log("Initialised Correctly");

				temp2D = new Texture2D(resWidth,resHeight, TextureFormat.ARGB32, false);
			}
			else
			{
				Debug.Log("Could not initialise resolution. No images received");
			}
		}
		else
		{
			Debug.Log("Please specify a source port");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log ("Frame");
		
		if (writeImageThread != null)
		{
			if (writeImageThread.imageWritten)
			{
				//set input texture as the active RenderTexture
				RenderTexture.active = view;

				//fill texture with render texture pixels
				temp2D.ReadPixels(new Rect(0,0,resWidth,resHeight),0,0);
				temp2D.Apply();

				Debug.Log ("Width = " + resWidth + " Height = " + resHeight);
				//extract color array from 2D Texture
				Color32[] pix = temp2D.GetPixels32();
				writeImageThread.colorArray = pix;
				
				writeImageThread.imageWritten = false;
				writeImageThread.Start();
			}
			else
			{
				Debug.Log("Image not written yet");
			}
		}
	}
	
	void OnApplicationQuit() {
		if (writeImageThread != null) 
		{
			Debug.Log ("Closing Thread");
			//checkImageThread.Abort();
			//checkImageThread.Join ();
		}
	}
}

public class YarpImageCheckWrite : ThreadedJob
{
	public bool imageWritten=true, init=false;
	public BufferedPortImageRgb imagePort;
	public int resWidth;
	public int resHeight;
	public Color32[] colorArray;
	public byte[] byteArray;
	//public System.IntPtr newPtr;

	public bool InitVariables()
	{
		Debug.Log("Resolution Set");
		//resWidth = 10;
		//resHeight = 200;
		byteArray = new byte[resWidth*resHeight*3];
		//newPtr = Marshal.AllocHGlobal(byteArray.Length);
		init = true;
		return init;
	}

	protected override void ThreadFunction()
	{
		convertToYarpImage();
		imageWritten = true;
	}

	private void convertToYarpImage()
	{
		ImageRgb texImage = imagePort.prepare();

		texImage.resize(resWidth, resHeight);
		texImage.setTopIsLowIndex(true);
		//texImage.setQuantum(1);
		//texImage.zero();

		int numPix = resWidth * resHeight;
		//convert Color32 array into byte array
		int currLoc = 0;
		Color32 currPix;

		for (int i = 0; i < numPix; i++) 
		{
			currPix = colorArray[i];
			currLoc = (numPix-i-1)*3;
			byteArray[currLoc]=(byte)currPix.r;
			byteArray[currLoc+1]=(byte)currPix.g;
			byteArray[currLoc+2]=(byte)currPix.b;
		}
		System.IntPtr newPtr = Marshal.AllocHGlobal(byteArray.Length);

		Marshal.Copy(byteArray,0,newPtr,byteArray.Length);
		texImage.setExternal(newPtr,resWidth,resHeight);
		imagePort.write();
		imagePort.waitForWrite();
		Marshal.FreeHGlobal(newPtr);
	}
}



