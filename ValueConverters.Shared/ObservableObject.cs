using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace ValueConverters
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> property)
        {
            if (property == null)
            {
                return;
            }

            if (!(property.Body is MemberExpression memberExp))
            {
                return;
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberExp.Member.Name));
        }
    }
}
