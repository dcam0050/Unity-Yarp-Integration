/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class DriverCreator : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal DriverCreator(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  public DriverCreator(){}

  internal static HandleRef getCPtr(DriverCreator obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~DriverCreator() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_DriverCreator(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public new string toString() {
    string ret = yarpPINVOKE.DriverCreator_toString(swigCPtr);
    return ret;
  }

  public virtual DeviceDriver create() {
    IntPtr cPtr = yarpPINVOKE.DriverCreator_create(swigCPtr);
    DeviceDriver ret = (cPtr == IntPtr.Zero) ? null : new DeviceDriver(cPtr, false);
    return ret;
  }

  public virtual string getName() {
    string ret = yarpPINVOKE.DriverCreator_getName(swigCPtr);
    return ret;
  }

  public virtual string getWrapper() {
    string ret = yarpPINVOKE.DriverCreator_getWrapper(swigCPtr);
    return ret;
  }

  public virtual string getCode() {
    string ret = yarpPINVOKE.DriverCreator_getCode(swigCPtr);
    return ret;
  }

  public virtual PolyDriver owner() {
    IntPtr cPtr = yarpPINVOKE.DriverCreator_owner(swigCPtr);
    PolyDriver ret = (cPtr == IntPtr.Zero) ? null : new PolyDriver(cPtr, false);
    return ret;
  }

}
