using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RegisterActivity.Base
{
    /// <summary>
    /// Base model for <typeparamref name="TModel"/>
    /// </summary>
    public class BaseModel<TModel> : INotifyPropertyChanged
        where TModel : class
    {
        /// <summary>
        /// Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Model
        /// </summary>
        protected TModel Model => this as TModel;

        /// <summary>
        /// Trigger a PropertyChanged event
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Set value of <paramref name="field"/> of property <paramref name="propertyName"/>
        /// if value is different from previous and evaluation of <paramref name="canChange"/> is true
        /// </summary>
        /// <typeparam name="T">Type of field</typeparam>
        /// <param name="field">Field to set value</param>
        /// <param name="newValue">New value to set</param>
        /// <param name="onChange">Action called after value changed and just before PropertChanged triggered</param>
        /// <param name="canChange">Function called to test if value can be changed</param>
        /// <param name="propertyName">Property name of field to set value</param>
        protected void SetProperty<T>(ref T field, T newValue, Action<TModel> onChange = null, Func<TModel, T, bool> canChange = null, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue)
                && (canChange?.Invoke(Model, newValue) ?? true))
            {
                SetValue(ref field, newValue, onChange, propertyName);
            }
        }


        private void SetValue<T>(ref T field, T newValue, Action<TModel> onChange = null, [CallerMemberName] string propertyName = null)
        {
            field = newValue;
            onChange?.Invoke(Model);
            OnPropertyChanged(propertyName);
        }
    }
}
