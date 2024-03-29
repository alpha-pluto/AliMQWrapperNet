//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace ons {

public class LocalTransactionExecuter : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal LocalTransactionExecuter(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LocalTransactionExecuter obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~LocalTransactionExecuter() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          ONSClient4CPPPINVOKE.delete_LocalTransactionExecuter(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public LocalTransactionExecuter() : this(ONSClient4CPPPINVOKE.new_LocalTransactionExecuter(), true) {
    SwigDirectorConnect();
  }

  public virtual TransactionStatus execute(Message msg) {
    TransactionStatus ret = (TransactionStatus)ONSClient4CPPPINVOKE.LocalTransactionExecuter_execute(swigCPtr, Message.getCPtr(msg));
    if (ONSClient4CPPPINVOKE.SWIGPendingException.Pending) throw ONSClient4CPPPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("execute", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateLocalTransactionExecuter_0(SwigDirectorexecute);
    ONSClient4CPPPINVOKE.LocalTransactionExecuter_director_connect(swigCPtr, swigDelegate0);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(LocalTransactionExecuter));
    return hasDerivedMethod;
  }

  private int SwigDirectorexecute(global::System.IntPtr msg) {
    return (int)execute(new Message(msg, false));
  }

  public delegate int SwigDelegateLocalTransactionExecuter_0(global::System.IntPtr msg);

  private SwigDelegateLocalTransactionExecuter_0 swigDelegate0;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(Message) };
}

}
