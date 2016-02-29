using UnityEngine;
using System.Collections;

public class PidFilter : MonoBehaviour
{
	private double error_old;       //error at previous step
	private double Kp,Kd,Ki;        //proportional, derivative and integral gains
	
	// integrative stuff
	private double Umax;            //maximum value of the control
	private double Sn;              //integal value

	private double pidError(double error) 
	{
		double ret=Kp*error+Kd*(error-error_old);
		return ret;
	}

	public PidFilter ()
	{
		error_old=0;
		Kp=0;
		Kd=0;
		Ki=0;
		
		Umax = 0.0;
		Sn = 0.0;
	}

	public PidFilter(double kp, double kd=0, double ki = 0, double u_max = 0.0)
	{
		error_old=0;
		Kp=kp;
		Kd=kd;
		Ki=ki;
		
		Umax = u_max;
		Sn = 0.0;
	}

	public PidFilter(PidFilter f)
	{
		error_old=f.error_old;
		Kp=f.Kp;
		Kd=f.Kd;
		Ki=f.Ki;
		
		Umax = f.Umax;
		Sn = f.Sn;
	}

	public void setKs(double kp, double kd=0.0, double ki=0.0, double u_max = 0.0)
	{
		Kp = kp;
		Kd = kd;
		Ki = ki;
		
		Sn = 0;
		Umax = u_max;
	}

	public void reset(double error = 0.0)
	{
		Sn = 0.0;
		error_old = error;
	}

	public double pid (double error)
	{
		double u_tmp;
		double Sn_tmp;
		double u_pd;
		double u;
		
		//compute the pd part
		u_pd = pidError(error);
		
		//compute the temporary integral part
		Sn_tmp = Sn + Ki * error;
		
		//compute the temporary control
		u_tmp = u_pd + Sn_tmp;
		
		//if no saturation occur, then temporary works fine
		Sn = Sn_tmp;
		
		//if saturation occur, redifine integral part
		if (u_tmp > Umax)
			Sn = Umax - u_pd; 
		if (u_tmp < -Umax)
			Sn = -Umax - u_pd;
		
		//redifine error_old
		error_old = error;
		
		//compute the control
		u = Sn + u_pd;
		
		return u;
	}
	
	public double getProportional() { return Kp; }
	public double getDerivative() { return Kd; }
	public double getIntegrative() { return Ki; }
}

public class FirstOrderLowPassFilter
{
	protected double fc;              // cut frequency
	protected double Ts;              // sample time
	protected double y;               // filter current output
	protected double yold;            // old output
	protected double uold;            // old input
	protected double a1, a2;
	protected double b1, b2;

	protected void computeCoeff()
	{
		double tau = 1.0/(2.0*3.1415926535897932384626433832795029*fc);
		b1 = b2 = Ts;
		a1 = 2.0*tau+Ts;
		a2 = Ts-2.0*tau;
	}

	public FirstOrderLowPassFilter(double cutFrequency, double sampleTime, double y0){
		fc = cutFrequency;
		Ts = sampleTime;
		computeCoeff();
		init(y0);
	}

	public void init(double y0)
	{
		y = y0;
		yold = y0;
		uold = (a1+a2)/(b1+b2)*y0;
	}

	public double filt(double u)
	{
		y = (b1*u + b2*uold - a2*yold) / a1;
		uold = u;
		yold = y;
		return y;
	}

	public double getCutFrequency() { return fc; }
	public double getSampleTime() { return Ts; }
	public double output() { return y; }
}


