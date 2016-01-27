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

            var memberExp = property.Body as MemberExpression;
            if (memberExp == null)
            {
                return;
            }

            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(memberExp.Member.Name));
            }
        }
    }
}
