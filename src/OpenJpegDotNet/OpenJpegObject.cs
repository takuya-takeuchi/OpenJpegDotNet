using System;

namespace OpenJpegDotNet
{

    /// <summary>
    /// A class which has a pointer of native structure.
    /// </summary>
    public abstract class OpenJpegObject : IDisposable
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenJpegObject"/> class with the specified value indicating whether this instance is disposable.
        /// </summary>
        /// <param name="isEnabledDispose">true if this instance is disposable; otherwise, false.</param>
        protected OpenJpegObject(bool isEnabledDispose = true)
        {
            this.IsEnableDispose = isEnabledDispose;
        }

        #endregion

        #region Finalizer

        // IMPORTANT
        //      OpenJpegDotNet passes and get native pointer to unmanaged domain and from.
        //      Sometimes, OpenJpegDotNet create OpenJpegObject from native pointer.
        //      There may be some OpenJpegObject has same native pointer .
        //      It means that developer may dispose objects has same one.
        //      To avoid this, OpenJpegObject has IsEnableDispose property.
        //      OpenJpegObject checks this property when Dispose method is called.
        //      However, if OpenJpegObject implements finalizer and developer forgets to dispose, OpenJpegObject may
        //      be disposed by GC and native pointer will be corrupted.
        //      
        //      If user add OpenJpegObject to StdVector<T> and set null to passed OpenJpegObject.
        //      Generally, OpenJpegObject means pointer and it should not disposed automatically.
        //      If it's disposed automatically, element passed to StdVector<T> also be corrupt.
        //      This problem is only occured on C# rather than C++ because GC and finalizer.
        //
        //      In conclusion, OpenJpegDotNet doesn't implement finalizer.
        //
        ///// <summary>
        ///// Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
        ///// </summary>
        //~OpenJpegObject()
        //{
        //    this.Dispose(false);
        //}

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this instance has been disposed.
        /// </summary>
        /// <returns>true if this instance has been disposed; otherwise, false.</returns>
        public bool IsDisposed
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is disposable.
        /// </summary>
        /// <returns>true if this instance is disposable; otherwise, false.</returns>
        public bool IsEnableDispose
        {
            get;
        }

        /// <summary>
        /// Gets a pointer of native structure.
        /// </summary>>
        public IntPtr NativePtr
        {
            get;
            internal set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// If this object is disposed, then <see cref="System.ObjectDisposedException"/> is thrown.
        /// </summary>
        public void ThrowIfDisposed()
        {
            if (this.IsDisposed)
                throw new ObjectDisposedException(this.GetType().FullName);
        }

        internal void ThrowIfDisposed(string objectName)
        {
            if (this.IsDisposed)
                throw new ObjectDisposedException(objectName);
        }

        #region Overrides

        /// <summary>
        /// Determines whether this instance and another specified <see cref="OpenJpegObject"/> object have the same value.
        /// </summary>
        /// <param name="obj">The <see cref="OpenJpegObject"/> to compare to this instance.</param>
        /// <returns><code>true</code> if the value of the <paramref name="obj"/> parameter is the same as the value of this instance; otherwise, <code>false</code>. If <paramref name="obj"/> is <code>null</code>, the method returns <code>false</code>.</returns>
        protected bool Equals(OpenJpegObject obj)
        {
            return this.NativePtr.Equals(obj.NativePtr);
        }

        /// <summary>
        /// Determines whether this instance and a specified object, which must also be a <see cref="OpenJpegObject"/> object, have the same value.
        /// </summary>
        /// <param name="obj">The <see cref="OpenJpegObject"/> to compare to this instance.</param>
        /// <returns><code>true</code> if <paramref name="obj"/> is a <see cref="OpenJpegObject"/> and its value is the same as this instance; otherwise, <code>false</code>. If <paramref name="obj"/> is <code>null</code>, the method returns <code>false</code>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return this.Equals((OpenJpegObject) obj);
        }

        /// <summary>
        /// Returns the hash code for this string.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.NativePtr.GetHashCode();
        }

        /// <summary>
        /// Releases all managed resources.
        /// </summary>
        protected virtual void DisposeManaged()
        {

        }

        /// <summary>
        /// Releases all unmanaged resources.
        /// </summary>
        protected virtual void DisposeUnmanaged()
        {

        }

        #endregion

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Releases all resources used by this <see cref="OpenJpegObject"/>.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            //GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by this <see cref="OpenJpegObject"/>.
        /// </summary>
        /// <param name="disposing">Indicate value whether <see cref="IDisposable.Dispose"/> method was called.</param>
        private void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            this.IsDisposed = true;

            if (disposing)
            {
                if (this.IsEnableDispose)
                    this.DisposeManaged();
            }

            if (this.IsEnableDispose)
                this.DisposeUnmanaged();

            this.NativePtr = IntPtr.Zero;
        }

        #endregion

    }

}
