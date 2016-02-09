/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class GazeEventParameters : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GazeEventParameters(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GazeEventParameters obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GazeEventParameters() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_GazeEventParameters(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public string type {
    set {
      yarpPINVOKE.GazeEventParameters_type_set(swigCPtr, value);
      if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      string ret = yarpPINVOKE.GazeEventParameters_type_get(swigCPtr);
      if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public double motionOngoingCheckPoint {
    set {
      yarpPINVOKE.GazeEventParameters_motionOngoingCheckPoint_set(swigCPtr, value);
    } 
    get {
      double ret = yarpPINVOKE.GazeEventParameters_motionOngoingCheckPoint_get(swigCPtr);
      return ret;
    } 
  }

  public GazeEventParameters() : this(yarpPINVOKE.new_GazeEventParameters(), true) {
  }

}
