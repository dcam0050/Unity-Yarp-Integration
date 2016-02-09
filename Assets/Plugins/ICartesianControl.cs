/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class ICartesianControl : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal ICartesianControl(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(ICartesianControl obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~ICartesianControl() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_ICartesianControl(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public virtual bool setTrackingMode(bool f) {
    bool ret = yarpPINVOKE.ICartesianControl_setTrackingMode(swigCPtr, f);
    return ret;
  }

  public virtual bool getTrackingMode(SWIGTYPE_p_bool f) {
    bool ret = yarpPINVOKE.ICartesianControl_getTrackingMode(swigCPtr, SWIGTYPE_p_bool.getCPtr(f));
    return ret;
  }

  public virtual bool setReferenceMode(bool f) {
    bool ret = yarpPINVOKE.ICartesianControl_setReferenceMode(swigCPtr, f);
    return ret;
  }

  public virtual bool getReferenceMode(SWIGTYPE_p_bool f) {
    bool ret = yarpPINVOKE.ICartesianControl_getReferenceMode(swigCPtr, SWIGTYPE_p_bool.getCPtr(f));
    return ret;
  }

  public virtual bool setPosePriority(string p) {
    bool ret = yarpPINVOKE.ICartesianControl_setPosePriority(swigCPtr, p);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getPosePriority(SWIGTYPE_p_std__string p) {
    bool ret = yarpPINVOKE.ICartesianControl_getPosePriority(swigCPtr, SWIGTYPE_p_std__string.getCPtr(p));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getPose(Vector x, Vector o, Stamp stamp) {
    bool ret = yarpPINVOKE.ICartesianControl_getPose__SWIG_0(swigCPtr, Vector.getCPtr(x), Vector.getCPtr(o), Stamp.getCPtr(stamp));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getPose(Vector x, Vector o) {
    bool ret = yarpPINVOKE.ICartesianControl_getPose__SWIG_1(swigCPtr, Vector.getCPtr(x), Vector.getCPtr(o));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getPose(int axis, Vector x, Vector o, Stamp stamp) {
    bool ret = yarpPINVOKE.ICartesianControl_getPose__SWIG_2(swigCPtr, axis, Vector.getCPtr(x), Vector.getCPtr(o), Stamp.getCPtr(stamp));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getPose(int axis, Vector x, Vector o) {
    bool ret = yarpPINVOKE.ICartesianControl_getPose__SWIG_3(swigCPtr, axis, Vector.getCPtr(x), Vector.getCPtr(o));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool goToPose(Vector xd, Vector od, double t) {
    bool ret = yarpPINVOKE.ICartesianControl_goToPose__SWIG_0(swigCPtr, Vector.getCPtr(xd), Vector.getCPtr(od), t);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool goToPose(Vector xd, Vector od) {
    bool ret = yarpPINVOKE.ICartesianControl_goToPose__SWIG_1(swigCPtr, Vector.getCPtr(xd), Vector.getCPtr(od));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool goToPosition(Vector xd, double t) {
    bool ret = yarpPINVOKE.ICartesianControl_goToPosition__SWIG_0(swigCPtr, Vector.getCPtr(xd), t);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool goToPosition(Vector xd) {
    bool ret = yarpPINVOKE.ICartesianControl_goToPosition__SWIG_1(swigCPtr, Vector.getCPtr(xd));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool goToPoseSync(Vector xd, Vector od, double t) {
    bool ret = yarpPINVOKE.ICartesianControl_goToPoseSync__SWIG_0(swigCPtr, Vector.getCPtr(xd), Vector.getCPtr(od), t);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool goToPoseSync(Vector xd, Vector od) {
    bool ret = yarpPINVOKE.ICartesianControl_goToPoseSync__SWIG_1(swigCPtr, Vector.getCPtr(xd), Vector.getCPtr(od));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool goToPositionSync(Vector xd, double t) {
    bool ret = yarpPINVOKE.ICartesianControl_goToPositionSync__SWIG_0(swigCPtr, Vector.getCPtr(xd), t);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool goToPositionSync(Vector xd) {
    bool ret = yarpPINVOKE.ICartesianControl_goToPositionSync__SWIG_1(swigCPtr, Vector.getCPtr(xd));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getDesired(Vector xdhat, Vector odhat, Vector qdhat) {
    bool ret = yarpPINVOKE.ICartesianControl_getDesired(swigCPtr, Vector.getCPtr(xdhat), Vector.getCPtr(odhat), Vector.getCPtr(qdhat));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool askForPose(Vector xd, Vector od, Vector xdhat, Vector odhat, Vector qdhat) {
    bool ret = yarpPINVOKE.ICartesianControl_askForPose__SWIG_0(swigCPtr, Vector.getCPtr(xd), Vector.getCPtr(od), Vector.getCPtr(xdhat), Vector.getCPtr(odhat), Vector.getCPtr(qdhat));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool askForPose(Vector q0, Vector xd, Vector od, Vector xdhat, Vector odhat, Vector qdhat) {
    bool ret = yarpPINVOKE.ICartesianControl_askForPose__SWIG_1(swigCPtr, Vector.getCPtr(q0), Vector.getCPtr(xd), Vector.getCPtr(od), Vector.getCPtr(xdhat), Vector.getCPtr(odhat), Vector.getCPtr(qdhat));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool askForPosition(Vector xd, Vector xdhat, Vector odhat, Vector qdhat) {
    bool ret = yarpPINVOKE.ICartesianControl_askForPosition__SWIG_0(swigCPtr, Vector.getCPtr(xd), Vector.getCPtr(xdhat), Vector.getCPtr(odhat), Vector.getCPtr(qdhat));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool askForPosition(Vector q0, Vector xd, Vector xdhat, Vector odhat, Vector qdhat) {
    bool ret = yarpPINVOKE.ICartesianControl_askForPosition__SWIG_1(swigCPtr, Vector.getCPtr(q0), Vector.getCPtr(xd), Vector.getCPtr(xdhat), Vector.getCPtr(odhat), Vector.getCPtr(qdhat));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getDOF(Vector curDof) {
    bool ret = yarpPINVOKE.ICartesianControl_getDOF(swigCPtr, Vector.getCPtr(curDof));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool setDOF(Vector newDof, Vector curDof) {
    bool ret = yarpPINVOKE.ICartesianControl_setDOF(swigCPtr, Vector.getCPtr(newDof), Vector.getCPtr(curDof));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getRestPos(Vector curRestPos) {
    bool ret = yarpPINVOKE.ICartesianControl_getRestPos(swigCPtr, Vector.getCPtr(curRestPos));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool setRestPos(Vector newRestPos, Vector curRestPos) {
    bool ret = yarpPINVOKE.ICartesianControl_setRestPos(swigCPtr, Vector.getCPtr(newRestPos), Vector.getCPtr(curRestPos));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getRestWeights(Vector curRestWeights) {
    bool ret = yarpPINVOKE.ICartesianControl_getRestWeights(swigCPtr, Vector.getCPtr(curRestWeights));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool setRestWeights(Vector newRestWeights, Vector curRestWeights) {
    bool ret = yarpPINVOKE.ICartesianControl_setRestWeights(swigCPtr, Vector.getCPtr(newRestWeights), Vector.getCPtr(curRestWeights));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getLimits(int axis, SWIGTYPE_p_double min, SWIGTYPE_p_double max) {
    bool ret = yarpPINVOKE.ICartesianControl_getLimits(swigCPtr, axis, SWIGTYPE_p_double.getCPtr(min), SWIGTYPE_p_double.getCPtr(max));
    return ret;
  }

  public virtual bool setLimits(int axis, double min, double max) {
    bool ret = yarpPINVOKE.ICartesianControl_setLimits(swigCPtr, axis, min, max);
    return ret;
  }

  public virtual bool getTrajTime(SWIGTYPE_p_double t) {
    bool ret = yarpPINVOKE.ICartesianControl_getTrajTime(swigCPtr, SWIGTYPE_p_double.getCPtr(t));
    return ret;
  }

  public virtual bool setTrajTime(double t) {
    bool ret = yarpPINVOKE.ICartesianControl_setTrajTime(swigCPtr, t);
    return ret;
  }

  public virtual bool getInTargetTol(SWIGTYPE_p_double tol) {
    bool ret = yarpPINVOKE.ICartesianControl_getInTargetTol(swigCPtr, SWIGTYPE_p_double.getCPtr(tol));
    return ret;
  }

  public virtual bool setInTargetTol(double tol) {
    bool ret = yarpPINVOKE.ICartesianControl_setInTargetTol(swigCPtr, tol);
    return ret;
  }

  public virtual bool getJointsVelocities(Vector qdot) {
    bool ret = yarpPINVOKE.ICartesianControl_getJointsVelocities(swigCPtr, Vector.getCPtr(qdot));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getTaskVelocities(Vector xdot, Vector odot) {
    bool ret = yarpPINVOKE.ICartesianControl_getTaskVelocities(swigCPtr, Vector.getCPtr(xdot), Vector.getCPtr(odot));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool setTaskVelocities(Vector xdot, Vector odot) {
    bool ret = yarpPINVOKE.ICartesianControl_setTaskVelocities(swigCPtr, Vector.getCPtr(xdot), Vector.getCPtr(odot));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool attachTipFrame(Vector x, Vector o) {
    bool ret = yarpPINVOKE.ICartesianControl_attachTipFrame(swigCPtr, Vector.getCPtr(x), Vector.getCPtr(o));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool getTipFrame(Vector x, Vector o) {
    bool ret = yarpPINVOKE.ICartesianControl_getTipFrame(swigCPtr, Vector.getCPtr(x), Vector.getCPtr(o));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool removeTipFrame() {
    bool ret = yarpPINVOKE.ICartesianControl_removeTipFrame(swigCPtr);
    return ret;
  }

  public virtual bool checkMotionDone(SWIGTYPE_p_bool f) {
    bool ret = yarpPINVOKE.ICartesianControl_checkMotionDone__SWIG_0(swigCPtr, SWIGTYPE_p_bool.getCPtr(f));
    return ret;
  }

  public virtual bool waitMotionDone(double period, double timeout) {
    bool ret = yarpPINVOKE.ICartesianControl_waitMotionDone__SWIG_0(swigCPtr, period, timeout);
    return ret;
  }

  public virtual bool waitMotionDone(double period) {
    bool ret = yarpPINVOKE.ICartesianControl_waitMotionDone__SWIG_1(swigCPtr, period);
    return ret;
  }

  public virtual bool waitMotionDone() {
    bool ret = yarpPINVOKE.ICartesianControl_waitMotionDone__SWIG_2(swigCPtr);
    return ret;
  }

  public virtual bool stopControl() {
    bool ret = yarpPINVOKE.ICartesianControl_stopControl(swigCPtr);
    return ret;
  }

  public virtual bool storeContext(SWIGTYPE_p_int id) {
    bool ret = yarpPINVOKE.ICartesianControl_storeContext(swigCPtr, SWIGTYPE_p_int.getCPtr(id));
    return ret;
  }

  public virtual bool restoreContext(int id) {
    bool ret = yarpPINVOKE.ICartesianControl_restoreContext(swigCPtr, id);
    return ret;
  }

  public virtual bool deleteContext(int id) {
    bool ret = yarpPINVOKE.ICartesianControl_deleteContext(swigCPtr, id);
    return ret;
  }

  public virtual bool getInfo(Bottle info) {
    bool ret = yarpPINVOKE.ICartesianControl_getInfo(swigCPtr, Bottle.getCPtr(info));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool registerEvent(CartesianEvent arg0) {
    bool ret = yarpPINVOKE.ICartesianControl_registerEvent(swigCPtr, CartesianEvent.getCPtr(arg0));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool unregisterEvent(CartesianEvent arg0) {
    bool ret = yarpPINVOKE.ICartesianControl_unregisterEvent(swigCPtr, CartesianEvent.getCPtr(arg0));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool tweakSet(Bottle options) {
    bool ret = yarpPINVOKE.ICartesianControl_tweakSet(swigCPtr, Bottle.getCPtr(options));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool tweakGet(Bottle options) {
    bool ret = yarpPINVOKE.ICartesianControl_tweakGet(swigCPtr, Bottle.getCPtr(options));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool checkMotionDone(BVector flag) {
    bool ret = yarpPINVOKE.ICartesianControl_checkMotionDone__SWIG_1(swigCPtr, BVector.getCPtr(flag));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool checkMotionDone() {
    bool ret = yarpPINVOKE.ICartesianControl_checkMotionDone__SWIG_2(swigCPtr);
    return ret;
  }

  public bool isMotionDone() {
    bool ret = yarpPINVOKE.ICartesianControl_isMotionDone(swigCPtr);
    return ret;
  }

}
