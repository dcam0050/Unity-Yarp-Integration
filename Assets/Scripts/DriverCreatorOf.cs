using UnityEngine;
using System.Collections;

public class DriverCreatorOf<T> : DriverCreator
{
	private string desc, wrap, code;

	public DriverCreatorOf(string name, string wrap, string code)
	{
		this.desc = name;
		this.wrap = wrap;
		this.code = code;
	}

	public virtual string toString(){
		return desc;
	}

	public virtual string getName(){
		return desc;
	}

	public virtual string getWrapper(){
		return desc;
	}

	public virtual string getCode(){
		return desc;
	}

	public virtual DriverCreator create(){
		return new DriverCreatorOf<T>(desc, wrap, code);
	}

}

