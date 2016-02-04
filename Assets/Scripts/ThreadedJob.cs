using System.Collections;
using UnityEngine;

public class ThreadedJob
{
	private bool m_IsDone = false;
	private object m_Handle = new object();
	private System.Threading.Thread m_Thread = null;
	public bool IsDone
	{
		get
		{
			bool tmp;
			lock (m_Handle)
			{
				tmp = m_IsDone;
			}
			return tmp;
		}
		set
		{
			lock (m_Handle)
			{
				m_IsDone = value;
			}
		}
	}
	
	public virtual void Start()
	{
		m_Thread = new System.Threading.Thread(Run);
		m_Thread.Start();
	}

	public virtual void Abort()
	{
		m_Thread.Abort();
	}

	public virtual void Join()
	{
		m_Thread.Join();
	}
	
	protected virtual void ThreadFunction() { }
	
	protected virtual void OnFinished() { }
	
	public virtual bool Update()
	{
		if (IsDone)
		{
			OnFinished();
			//Abort(); possibly needed in order to not have too many thread instances
			return true;
		}
		return false;
	}

	IEnumerator WaitFor()
	{
		while(!Update())
		{
			yield return null;
		}
	}
	private void Run()
	{
		IsDone = false;
		ThreadFunction();
		IsDone = true;
	}
}