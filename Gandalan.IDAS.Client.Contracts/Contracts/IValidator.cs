using Gandalan.Client.Common.Contracts.UIServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts
{
    public interface IValidator
    {
        bool HasErrors { get; }
        void Validate();

        event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

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

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

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
