using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MarvelHeroes.ViewModel
{
    /// <summary>
    /// Base class for view models
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ViewModelBase()
        {

        }

        #region INotifyPropertyChanged Implementation

        /// <summary>
        /// Flag that indicates whether the property changed is enabled or not
        /// </summary>
        private bool _propertyChangedEnabled = true;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(bool force, [CallerMemberName] string propertyName = "")
        {
            if (_propertyChangedEnabled || force)
            {
                var changed = PropertyChanged;
                if (changed == null)
                    return;

                changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            OnPropertyChanged(true, propertyName);
        }

        /// <summary>
        /// Property changed event
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged<T>(ref T oldValue,
                                            T newValue,
                                            [CallerMemberName] string propertyName = "")
        {
            if (newValue != null &&
                oldValue != null &&
                oldValue.Equals(newValue))
            {
                return;
            }

            oldValue = newValue;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void EnablePropertyChanged(bool value)
        {
            this._propertyChangedEnabled = value;
        }

        #endregion



        #region IDispose Implementation
        /// <summary>
        /// <see cref="IDisposable"/> implementation.
        /// </summary>
        public void Dispose()
        {
            //finalize
            this.Dispose(true);

            //await the thread finalizers
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Destrutor
        /// </summary>
        ~ViewModelBase()
        {
            // Prevents the circular call to dispose.
            this.Dispose(false);
        }

        /// <summary>
        /// When override in derived classe, provides to GC 
        /// the mecanims to ends the memory utilization
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            //when false, don't dispose
            if (this._disposed) return;

            if (!this._disposed)
            {
                this._disposed = true;
            }
        }

        /// <summary>
        /// When true, indicates it is a dispose process
        /// </summary>
        private bool _disposed = false;


        #endregion
    }
}
