using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class yarpSendCameraImage : MonoBehaviour {

	public string sourcePortName;
	public string destPortName;
	public RenderTexture view;

	private int resWidth;
	private int resHeight;
	public Texture2D temp2D;
	private BufferedPortImageRgba imagePort;
	private ImageRgba texImage;

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Initialising Network ... ");
		Network.init();
		Debug.Log ("Initialising Port");
		imagePort = new BufferedPortImageRgba();
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

		//extract byte array from Texture2D
		Color32[] pix = temp2D.GetPixels32();

		//need to wrap external
		//texImage.setExternal((SWIGTYPE_p_void)pix,resWidth,resHeight); 

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
