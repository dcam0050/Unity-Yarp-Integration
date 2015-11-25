using UnityEngine;
using System.Collections;

public class yarpSendCameraImage : MonoBehaviour {
	
	public string destPortName;
	public string sourcePortName;
	public RenderTexture viewTexture;

	BufferedPortImageRgba yarpImagePort;
	Texture2D texture2DImage;
	public int TextureWidth = 640;
	public int TextureHeight = 480;


	// Use this for initialization
	void Start () {
		Network.init();
		yarpImagePort = new BufferedPortImageRgba();
		bool portOpen = yarpImagePort.open(sourcePortName);

		if(portOpen == false)
		{
			Debug.Log("No yarp server detected");
		}

		Network.connect(sourcePortName, destPortName);


		//read resolution of texture to initialise a constant image header

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPostRender()
	{
		//ARGB32 format has first 4 sections of 8bits each alpha, red, green, blue
		//To be interfaced with PixelRgba or PixelRgb 
		// viewTexture.colorBuffer contains the colour data for all pixels in the texture
		//Step 1: understand structure of image data in a PixelRgba
		//Step 2: understand how to extract pixel information from colour buffer
		//Step 3: convert one to the other and send it on
		ImageRgba yarpImage = yarpImagePort.prepare();

		//convert RenderTexture to Texture2D
		texture2DImage = new Texture2D(TextureWidth, TextureHeight, TextureFormat.ARGB32, false);
		texture2DImage.ReadPixels( new Rect(0, 0, TextureWidth, TextureHeight), 0, 0);

		//extract byte data from Texture2D
		//byte[] bytes;
		//bytes = texture2DImage.EncodeToPNG();

		SWIGTYPE_p_void data = texture2DImage.EncodeToPNG();


		yarpImage.resize(TextureWidth, TextureHeight);
		//yarpImage.setExternal(bytes, TextureWidth, TextureHeight);
		//yarpImage.setExternal(
	}
}
