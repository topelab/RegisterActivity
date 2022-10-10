using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Topelab.RegisterActivity.Domain.Dtos;

namespace Topelab.RegisterActivity.Domain.Base
{
    /// <summary>
    /// Base model for <typeparamref name="TModel"/>
    /// </summary>
    public class BaseModel<TModel> : INotifyPropertyChanged
        where TModel : class
    {
        private static Action<TModel> whenInitialized;

        /// <summary>
        /// Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Set action that will be called when Model has been initialized
        /// </summary>
        public static void WhenInitialized(Action<TModel> changed) => whenInitialized = changed;

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
        /// Trigger an on initialized event
        /// </summary>
        /// <param name="model">Model</param>
        protected void OnInitialized(TModel model)
        {
            whenInitialized?.Invoke(model);
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

        /// <summary>
        /// Gets joined function using relation
        /// </summary>
        /// <param name="previousCanChange">Previous function</param>
        /// <param name="canChange">New function</param>
        /// <param name="joinRelation">Relation between the functions</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected static Func<TModel, TType, bool> GetJoinedFunc<TType>(Func<TModel, TType, bool> previousCanChange, Func<TModel, TType, bool> canChange, JoinRelationType joinRelation)
            => joinRelation switch
                {
                    JoinRelationType.Replace => canChange,
                    JoinRelationType.And => previousCanChange == null ? canChange : (entity, value) => (previousCanChange?.Invoke(entity, value) ?? true) && (canChange?.Invoke(entity, value) ?? true),
                    JoinRelationType.Or => previousCanChange == null ? canChange : (entity, value) => (previousCanChange?.Invoke(entity, value) ?? true) || (canChange?.Invoke(entity, value) ?? true),
                    _ => throw new NotImplementedException()
                };

        /// <summary>
        /// Gets joined action using relation
        /// </summary>
        /// <param name="previousOnChange">Previous action</param>
        /// <param name="onChange">New onChange action</param>
        /// <param name="joinRelation">Relation between the actions</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected static Action<TModel> GetJoinedAction(Action<TModel> previousOnChange, Action<TModel> onChange, JoinRelationType joinRelation)
            => joinRelation switch
                {
                    JoinRelationType.Replace => onChange,
                    JoinRelationType.And => previousOnChange == null ? onChange : (entity) => { previousOnChange?.Invoke(entity); onChange?.Invoke(entity); },
                    _ => throw new NotImplementedException()
                };

        private void SetValue<T>(ref T field, T newValue, Action<TModel> onChange = null, [CallerMemberName] string propertyName = null)
        {
            field = newValue;
            onChange?.Invoke(Model);
            OnPropertyChanged(propertyName);
        }
    }
}
