// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2201 $</version>
// </file>

// This file is automatically generated - any changes will be lost

#pragma warning disable 1591

namespace Debugger.Wrappers.CorDebug
{
	using System;
	
	
	public partial class ICorDebugCodeEnum
	{
		
		private Debugger.Interop.CorDebug.ICorDebugCodeEnum wrappedObject;
		
		internal Debugger.Interop.CorDebug.ICorDebugCodeEnum WrappedObject
		{
			get
			{
				return this.wrappedObject;
			}
		}
		
		public ICorDebugCodeEnum(Debugger.Interop.CorDebug.ICorDebugCodeEnum wrappedObject)
		{
			this.wrappedObject = wrappedObject;
			ResourceManager.TrackCOMObject(wrappedObject, typeof(ICorDebugCodeEnum));
		}
		
		public static ICorDebugCodeEnum Wrap(Debugger.Interop.CorDebug.ICorDebugCodeEnum objectToWrap)
		{
			if ((objectToWrap != null))
			{
				return new ICorDebugCodeEnum(objectToWrap);
			} else
			{
				return null;
			}
		}
		
		~ICorDebugCodeEnum()
		{
			object o = wrappedObject;
			wrappedObject = null;
			ResourceManager.ReleaseCOMObject(o, typeof(ICorDebugCodeEnum));
		}
		
		public bool Is<T>() where T: class
		{
			System.Reflection.ConstructorInfo ctor = typeof(T).GetConstructors()[0];
			System.Type paramType = ctor.GetParameters()[0].ParameterType;
			return paramType.IsInstanceOfType(this.WrappedObject);
		}
		
		public T As<T>() where T: class
		{
			try {
				return CastTo<T>();
			} catch {
				return null;
			}
		}
		
		public T CastTo<T>() where T: class
		{
			return (T)Activator.CreateInstance(typeof(T), this.WrappedObject);
		}
		
		public static bool operator ==(ICorDebugCodeEnum o1, ICorDebugCodeEnum o2)
		{
			return ((object)o1 == null && (object)o2 == null) ||
			       ((object)o1 != null && (object)o2 != null && o1.WrappedObject == o2.WrappedObject);
		}
		
		public static bool operator !=(ICorDebugCodeEnum o1, ICorDebugCodeEnum o2)
		{
			return !(o1 == o2);
		}
		
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public override bool Equals(object o)
		{
			ICorDebugCodeEnum casted = o as ICorDebugCodeEnum;
			return (casted != null) && (casted.WrappedObject == wrappedObject);
		}
		
		
		public void Skip(uint celt)
		{
			this.WrappedObject.Skip(celt);
		}
		
		public void Reset()
		{
			this.WrappedObject.Reset();
		}
		
		public ICorDebugEnum Clone()
		{
			ICorDebugEnum ppEnum;
			Debugger.Interop.CorDebug.ICorDebugEnum out_ppEnum;
			this.WrappedObject.Clone(out out_ppEnum);
			ppEnum = ICorDebugEnum.Wrap(out_ppEnum);
			return ppEnum;
		}
		
		public uint Count
		{
			get
			{
				uint pcelt;
				this.WrappedObject.GetCount(out pcelt);
				return pcelt;
			}
		}
		
		public uint Next(uint celt, System.IntPtr values)
		{
			uint pceltFetched;
			this.WrappedObject.Next(celt, values, out pceltFetched);
			return pceltFetched;
		}
	}
}

#pragma warning restore 1591
