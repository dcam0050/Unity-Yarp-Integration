/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class Vector : Portable {
  private HandleRef swigCPtr;

  internal Vector(IntPtr cPtr, bool cMemoryOwn) : base(yarpPINVOKE.Vector_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(Vector obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~Vector() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_Vector(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public Vector() : this(yarpPINVOKE.new_Vector__SWIG_0(), true) {
  }

  public Vector(uint s) : this(yarpPINVOKE.new_Vector__SWIG_1(s), true) {
  }

  public Vector(uint s, double def) : this(yarpPINVOKE.new_Vector__SWIG_2(s, def), true) {
  }

  public Vector(uint s, SWIGTYPE_p_double p) : this(yarpPINVOKE.new_Vector__SWIG_3(s, SWIGTYPE_p_double.getCPtr(p)), true) {
  }

  public Vector(Vector r) : this(yarpPINVOKE.new_Vector__SWIG_4(Vector.getCPtr(r)), true) {
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public void size(uint s) {
    yarpPINVOKE.Vector_size__SWIG_0(swigCPtr, s);
  }

  public void resize(uint s) {
    yarpPINVOKE.Vector_resize__SWIG_0(swigCPtr, s);
  }

  public void resize(uint size, double def) {
    yarpPINVOKE.Vector_resize__SWIG_1(swigCPtr, size, def);
  }

  public uint size() {
    uint ret = yarpPINVOKE.Vector_size__SWIG_1(swigCPtr);
    return ret;
  }

  public uint length() {
    uint ret = yarpPINVOKE.Vector_length(swigCPtr);
    return ret;
  }

  public void zero() {
    yarpPINVOKE.Vector_zero(swigCPtr);
  }

  public new string toString(int precision, int width) {
    string ret = yarpPINVOKE.Vector_toString__SWIG_0(swigCPtr, precision, width);
    return ret;
  }

  public new string toString(int precision) {
    string ret = yarpPINVOKE.Vector_toString__SWIG_1(swigCPtr, precision);
    return ret;
  }

  public new string toString_c() {
    string ret = yarpPINVOKE.Vector_toString_c(swigCPtr);
    return ret;
  }

  public Vector subVector(uint first, uint last) {
    Vector ret = new Vector(yarpPINVOKE.Vector_subVector(swigCPtr, first, last), true);
    return ret;
  }

  public bool setSubvector(int position, Vector v) {
    bool ret = yarpPINVOKE.Vector_setSubvector(swigCPtr, position, Vector.getCPtr(v));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public SWIGTYPE_p_double data() {
    IntPtr cPtr = yarpPINVOKE.Vector_data__SWIG_0(swigCPtr);
    SWIGTYPE_p_double ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_double(cPtr, false);
    return ret;
  }

  public bool isEqual(Vector r) {
    bool ret = yarpPINVOKE.Vector_isEqual(swigCPtr, Vector.getCPtr(r));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void push_back(double elem) {
    yarpPINVOKE.Vector_push_back(swigCPtr, elem);
  }

  public void pop_back() {
    yarpPINVOKE.Vector_pop_back(swigCPtr);
  }

  public System.IntPtr getGslVector() { return yarpPINVOKE.Vector_getGslVector__SWIG_0(swigCPtr); }

  public SWIGTYPE_p_double access(uint i) {
    SWIGTYPE_p_double ret = new SWIGTYPE_p_double(yarpPINVOKE.Vector_access__SWIG_0(swigCPtr, i), false);
    return ret;
  }

  public void clear() {
    yarpPINVOKE.Vector_clear(swigCPtr);
  }

  public new bool read(ConnectionReader connection) {
    bool ret = yarpPINVOKE.Vector_read(swigCPtr, ConnectionReader.getCPtr(connection));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new bool write(ConnectionWriter connection) {
    bool ret = yarpPINVOKE.Vector_write(swigCPtr, ConnectionWriter.getCPtr(connection));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public double get(int j) {
    double ret = yarpPINVOKE.Vector_get(swigCPtr, j);
    return ret;
  }

  public void set(int j, double v) {
    yarpPINVOKE.Vector_set(swigCPtr, j, v);
  }

}
