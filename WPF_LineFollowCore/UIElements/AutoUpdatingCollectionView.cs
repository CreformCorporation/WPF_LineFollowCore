using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Collections.Specialized;

namespace UIElements
{
    public class AutoUpdatingCollectionView : ListCollectionView
    {
        public AutoUpdatingCollectionView(IList sourceCollection)
            : base(sourceCollection)
        {
            try
            {
                //subscribe to the property changed events of all of the objects within the collection
                foreach (var item in sourceCollection)
                {
                    if (item is INotifyPropertyChanged)
                    {
                        ((INotifyPropertyChanged)item).PropertyChanged += SourceCollectionItemPropertyChanged;
                    }
                }
                //subscribe the collection changed event of the source collection
                ((INotifyCollectionChanged)(this.SourceCollection)).CollectionChanged += SourceCollectionChanged;
            }
            catch (Exception ex)
            {
                //TODO: Log Exception
                Console.WriteLine("Problem Updating CollectionView");
                Console.WriteLine(ex.StackTrace);
            }
        }

        //we use this event handler to subscribe to any new objects and unsubscribe from any old objects
        private void SourceCollectionChanged(object collection, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    if (item is INotifyPropertyChanged)
                    {
                        ((INotifyPropertyChanged)item).PropertyChanged += SourceCollectionItemPropertyChanged;
                    }
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    if (item is INotifyPropertyChanged)
                    {
                        ((INotifyPropertyChanged)item).PropertyChanged -= SourceCollectionItemPropertyChanged;
                    }
                }
            }
        }

        //invoke refresh on the ICollectionView
        private void SourceCollectionItemPropertyChanged(object sender, EventArgs e)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(Refresh);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception when refreshing CollectionView. " + ex.Message);
            }
        }
    }
}
