using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class yarpChangeFace : MonoBehaviour {
	
	private BufferedPortImageRgb inputImagePort;
	public string inputPortName;
	public string sourcePortName;
	
	YarpImageCheck checkImageThread;
	
	private Texture2D image2DTex; 
	public GameObject plane;
	private Renderer planeRender;

	private Texture2D bodyTexOriginal;
	public GameObject model;
	private Renderer bodyRenderer;

	private Texture2D body2DTex; 
	public GameObject planeFace;
	private Renderer planeBodyRender;

	private Color32[] bodyColorArrayOrig;
	private Color32[] bodyColorArray;
	public int xoffset = 10;
	public int xrange = 10;
	public int yoffset = 0;
	public int yrange = 10;
	public int xwidth = 0;
	public int ywidth = 0;
	public byte fillColor = 255;
	public byte alphaColor = 255;

	// Use this for initialization
	void Start () {
		Network.init();
		if(sourcePortName != null)
		{
			inputImagePort = new BufferedPortImageRgb();
			inputImagePort.open (inputPortName);
			Network.connect(sourcePortName, inputPortName);
			
			checkImageThread = new YarpImageCheck();
			checkImageThread.imagePort = inputImagePort;
			checkImageThread.Start();
			bool checkInit = checkImageThread.InitVariables();

			if(checkInit)
			{
				Debug.Log("Initialised Correctly");
				image2DTex = new Texture2D(checkImageThread.resWidth,checkImageThread.resHeight,TextureFormat.ARGB32, false);
				image2DTex.wrapMode = TextureWrapMode.Clamp;
				planeRender = plane.GetComponent<Renderer>();

				bodyRenderer = model.GetComponent<Renderer>();
				bodyTexOriginal = bodyRenderer.material.mainTexture as Texture2D;
				bodyColorArrayOrig = bodyTexOriginal.GetPixels32();

				xwidth = bodyTexOriginal.width;
				ywidth = bodyTexOriginal.height;
				body2DTex = new Texture2D(bodyTexOriginal.width,bodyTexOriginal.height,TextureFormat.ARGB32, false);
				body2DTex.wrapMode = TextureWrapMode.Clamp;
				planeBodyRender = planeFace.GetComponent<Renderer>();
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
		
		if (checkImageThread != null)
		{
			if (checkImageThread.imageReceived)
			{
				Debug.Log ("Image Received");

				//apply input image to plane 1
				image2DTex.SetPixels32(checkImageThread.colorArray);
				image2DTex.Apply();
				planeRender.material.mainTexture = image2DTex;


				//modify body texture
				//considering x to be rows and y to be columns
				bodyColorArray = (Color32[])bodyColorArrayOrig.Clone();
				int k = 0;
				int arrSize = checkImageThread.colorArray.Length;
				for(int i = xoffset; i<xoffset+xrange; i++)
				{
					for(int j = yoffset; j<yoffset+yrange; j++)
					{
						bodyColorArray[(i*xwidth)+j] = new Color32(fillColor,fillColor,fillColor,alphaColor);
						//bodyColorArray[(i*xwidth)+j]=checkImageThread.colorArray[arrSize-k-1];
						k++;
					}
				}
				body2DTex.SetPixels32(bodyColorArray);
				body2DTex.Apply();

				//apply body texture to plane2
				planeBodyRender.material.mainTexture = body2DTex;
				

				//apply body texture to body
				bodyRenderer.material.mainTexture = body2DTex;

				//get another image
				checkImageThread.imageReceived = false;
				checkImageThread.Start();
			}
			else
			{
				Debug.Log("No image yet");
			}
		}
	}
	
	void OnApplicationQuit() {
		if (checkImageThread != null) 
		{
			Debug.Log ("Closing Thread");
			//checkImageThread.Abort();
			//checkImageThread.Join ();
		}
	}
}


