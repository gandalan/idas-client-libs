using Gandalan.Client.Contracts.UIServices;
using System;
using System.ComponentModel;

namespace Gandalan.Client.Contracts
{
    public interface IValidator
    {
        bool HasErrors { get; }
        void Validate();
        void InvokeCancelledSave();

        event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        event EventHandler CancelledSave;
        
        ValidationMessage GetErrors(string propertyName);
    }

    public interface IValidator<T> : IValidator
    {
        void Monitor(T data);
        void Validate(T model);
    }

    public sealed class NullValidator<T> : IValidator<T>
    {
        public bool HasErrors => false;

        public void InvokeCancelledSave()
        {
            CancelledSave?.Invoke(this, null);
        }

#pragma warning disable CS0067 // The event 'NullValidator<T>.ErrorsChanged' is never used
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
#pragma warning restore CS0067 // The event 'NullValidator<T>.ErrorsChanged' is never used
        public event EventHandler CancelledSave;

        public ValidationMessage GetErrors(string propertyName)
        {
            return default(ValidationMessage);
        }

        public void Monitor(T data)
        {   
        }

        public void SetData(T data)
        {
            
        }

        public void Validate()
        {
            
        }

        public void Validate(T model)
        {
        }
    }
}
