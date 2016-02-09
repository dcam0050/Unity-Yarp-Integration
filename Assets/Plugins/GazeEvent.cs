/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class GazeEvent : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GazeEvent(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GazeEvent obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GazeEvent() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_GazeEvent(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public GazeEventParameters gazeEventParameters {
    set {
      yarpPINVOKE.GazeEvent_gazeEventParameters_set(swigCPtr, GazeEventParameters.getCPtr(value));
    } 
    get {
      IntPtr cPtr = yarpPINVOKE.GazeEvent_gazeEventParameters_get(swigCPtr);
      GazeEventParameters ret = (cPtr == IntPtr.Zero) ? null : new GazeEventParameters(cPtr, false);
      return ret;
    } 
  }

  public GazeEventVariables gazeEventVariables {
    set {
      yarpPINVOKE.GazeEvent_gazeEventVariables_set(swigCPtr, GazeEventVariables.getCPtr(value));
    } 
    get {
      IntPtr cPtr = yarpPINVOKE.GazeEvent_gazeEventVariables_get(swigCPtr);
      GazeEventVariables ret = (cPtr == IntPtr.Zero) ? null : new GazeEventVariables(cPtr, false);
      return ret;
    } 
  }

  public virtual void gazeEventCallback() {
    yarpPINVOKE.GazeEvent_gazeEventCallback(swigCPtr);
  }

}
