using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using OpenJpegDotNet.Interop;

// ReSharper disable once CheckNamespace
namespace OpenJpegDotNet
{

    public sealed class StdVector<TItem> : OpenJpegObject, IList<TItem>
    {

        #region Fields

        private readonly StdVectorImp<TItem> _Imp;

        #endregion

        #region Constructors

        public StdVector()
        {
            this._Imp = CreateImp();
            this.NativePtr = this._Imp.Create();
        }

        public StdVector(int size)
        {
            this._Imp = CreateImp();
            this.NativePtr = this._Imp.Create(size);
        }

        public StdVector(IEnumerable<TItem> data)
        {
            this._Imp = CreateImp();
            this.NativePtr = this._Imp.Create(data);
        }

        internal StdVector(IntPtr ptr)
        {
            this._Imp = CreateImp();
            this.NativePtr = ptr;
        }

        #endregion

        #region Properties

        public IntPtr ElementPtr
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Imp.GetElementPtr(this.NativePtr);
            }
        }

        public int Size
        {
            get
            {
                this.ThrowIfDisposed();
                return this._Imp.GetSize(this.NativePtr);
            }
        }

        #endregion

        #region Methods

        public TItem[] ToArray()
        {
            this.ThrowIfDisposed();
            return this._Imp.ToArray(this.NativePtr);
        }

        #region Overrides

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();

            if (this.NativePtr == IntPtr.Zero)
                return;

            this._Imp?.Dispose(this.NativePtr);
        }

        #endregion

        #region Helpers

        private static StdVectorImp<TItem> CreateImp()
        {
            if (StdVectorElementTypesRepository.SupportTypes.TryGetValue(typeof(TItem), out var type))
            {
                switch (type)
                {
                    case StdVectorElementTypesRepository.ElementTypes.Int32:
                        return new StdVectorInt32Imp() as StdVectorImp<TItem>;
                    case StdVectorElementTypesRepository.ElementTypes.UInt32:
                        return new StdVectorUInt32Imp() as StdVectorImp<TItem>;
                }
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        #endregion

        #endregion

        #region StdVectorImp

        private abstract class StdVectorImp<T>
        {

            #region Methods

            public abstract void CopyTo(IntPtr ptr, T[] array, int arrayIndex);

            public abstract IntPtr Create();

            public abstract IntPtr Create(int size);

            public abstract IntPtr Create(IEnumerable<T> data);

            public abstract void Dispose(IntPtr ptr);

            public abstract IntPtr GetElementPtr(IntPtr ptr);

            public abstract int GetSize(IntPtr ptr);

            public abstract T[] ToArray(IntPtr ptr);

            #endregion

        }

        private sealed class StdVectorInt32Imp : StdVectorImp<int>
        {

            #region Methods

            public override void CopyTo(IntPtr ptr, int[] array, int arrayIndex)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return;

                var elementPtr = this.GetElementPtr(ptr);
                Marshal.Copy(elementPtr, array, arrayIndex, size);
            }

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_int32_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_int32_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<int> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.ToArray();
                return NativeMethods.std_vector_int32_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_vector_int32_delete(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_int32_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_int32_getSize(ptr).ToInt32();
            }

            public override int[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new int[0];

                var dst = new int[size];
                var elementPtr = this.GetElementPtr(ptr);
                Marshal.Copy(elementPtr, dst, 0, dst.Length);
                return dst;
            }

            #endregion

        }

        private sealed class StdVectorUInt32Imp : StdVectorImp<uint>
        {

            #region Methods

            public override void CopyTo(IntPtr ptr, uint[] array, int arrayIndex)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return;

                var elementPtr = this.GetElementPtr(ptr);
                InteropHelper.Copy(elementPtr, array, arrayIndex, (uint)size);
            }

            public override IntPtr Create()
            {
                return NativeMethods.std_vector_uint32_new1();
            }

            public override IntPtr Create(int size)
            {
                if (size < 0)
                    throw new ArgumentOutOfRangeException(nameof(size));

                return NativeMethods.std_vector_uint32_new2(new IntPtr(size));
            }

            public override IntPtr Create(IEnumerable<uint> data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));

                var array = data.ToArray();
                return NativeMethods.std_vector_uint32_new3(array, new IntPtr(array.Length));
            }

            public override void Dispose(IntPtr ptr)
            {
                NativeMethods.std_vector_uint32_delete(ptr);
            }

            public override IntPtr GetElementPtr(IntPtr ptr)
            {
                return NativeMethods.std_vector_uint32_getPointer(ptr);
            }

            public override int GetSize(IntPtr ptr)
            {
                return NativeMethods.std_vector_uint32_getSize(ptr).ToInt32();
            }

            public override uint[] ToArray(IntPtr ptr)
            {
                var size = this.GetSize(ptr);
                if (size == 0)
                    return new uint[0];

                var dst = new uint[size];
                var elementPtr = this.GetElementPtr(ptr);
                InteropHelper.Copy(elementPtr, dst, 0, (uint)dst.Length);
                return dst;
            }

            #endregion

        }

        #endregion

        #region IEnumerable<TItem> Members

        public IEnumerator<TItem> GetEnumerator()
        {
            return ((IEnumerable<TItem>)this.ToArray()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region IList<TItem> Members

        public void Add(TItem item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TItem item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(TItem[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"{nameof(arrayIndex)} is less than 0.");
            var size = array.Length - arrayIndex;
            if (size > this.Size)
                throw new ArgumentException($"The number of elements in the source StdVector<T> is greater than the available space from {nameof(arrayIndex)} to the end of the destination array.");

            this.ThrowIfDisposed();
            this._Imp.CopyTo(this.NativePtr, array, arrayIndex);
        }

        public bool Remove(TItem item)
        {
            throw new NotImplementedException();
        }

        public int Count => this.Size;

        public bool IsReadOnly => false;

        public int IndexOf(TItem item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, TItem item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public TItem this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        #endregion

    }

}