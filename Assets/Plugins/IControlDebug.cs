/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class IControlDebug : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal IControlDebug(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(IControlDebug obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~IControlDebug() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_IControlDebug(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public virtual bool setPrintFunction(SWIGTYPE_p_f_p_q_const__char_v_______int f) {
    bool ret = yarpPINVOKE.IControlDebug_setPrintFunction(swigCPtr, SWIGTYPE_p_f_p_q_const__char_v_______int.getCPtr(f));
    return ret;
  }

  public virtual bool loadBootMemory() {
    bool ret = yarpPINVOKE.IControlDebug_loadBootMemory(swigCPtr);
    return ret;
  }

  public virtual bool saveBootMemory() {
    bool ret = yarpPINVOKE.IControlDebug_saveBootMemory(swigCPtr);
    return ret;
  }

}
