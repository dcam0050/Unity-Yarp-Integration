using UnityEngine;
using System.Collections;

public class DriverLinkCreator : DriverCreator
{
	public string name;
	public PolyDriver holding;

	public DriverLinkCreator(string name, PolyDriver source)
	{
		this.name = name;
		this.holding = source;
	}

	~DriverLinkCreator()
	{
		holding.close ();
	}

	public virtual string toString()
	{
		return name;
	}

	public void close()
	{
		holding.close();
	}
}

