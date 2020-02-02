// -----------------------------------------------------------------------
// <copyright file="IParametersViewModel.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace WPF.SketchTemplateTest.ViewModelInterfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;

    using WPF.SketchTemplateTest.ViewModels;

    public interface IParametersViewModel : INotifyPropertyChanged
    {
        ParameterCollection Parameters { get; }

        DataTemplate SketchTemplate { get; }

        IParameterTemplateDictionary ParameterTemplateDictionary { get; }

        ICommand SelectionChangedCommand { get; }
    }

    public class ParameterCollection : ObservableCollection<IParameterViewModel>
    {
    }

    public class ParameterTemplateDictionary : CollectionDictionary<Type, DataTemplate>, IParameterTemplateDictionary
    {
    }

    public class CollectionDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>,
                                                      ICollection<DictionaryEntry<TKey, TValue>>
    {
        private readonly Collection<DictionaryEntry<TKey, TValue>> collection =
            new Collection<DictionaryEntry<TKey, TValue>>();

        private readonly Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        public TValue this[TKey key] => this.dictionary[key];

        public IEnumerable<TKey> Keys => this.dictionary.Keys;

        public IEnumerable<TValue> Values => this.dictionary.Values;

        int ICollection<DictionaryEntry<TKey, TValue>>.Count => this.collection.Count;

        bool ICollection<DictionaryEntry<TKey, TValue>>.IsReadOnly { get; } = false;

        int IReadOnlyCollection<KeyValuePair<TKey, TValue>>.Count => this.dictionary.Count;

        public IEnumerator<DictionaryEntry<TKey, TValue>> GetEnumerator()
        {
            return this.collection.GetEnumerator();
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return this.dictionary.GetEnumerator();
        }

        public bool ContainsKey(TKey key)
        {
            return this.dictionary.ContainsKey(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return this.dictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(DictionaryEntry<TKey, TValue> item)
        {
            this.dictionary.Add(item.Key, item.Value);
            this.collection.Add(item);
        }

        public void Clear()
        {
            this.collection.Clear();
            this.dictionary.Clear();
        }

        public bool Contains(DictionaryEntry<TKey, TValue> item)
        {
            return this.collection.Contains(item);
        }

        public void CopyTo(DictionaryEntry<TKey, TValue>[] array, int arrayIndex)
        {
            this.collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(DictionaryEntry<TKey, TValue> item)
        {
            this.dictionary.Remove(item.Key);
            return this.collection.Remove(item);
        }
    }

    public interface IParameterTemplateDictionary : IReadOnlyDictionary<Type, DataTemplate>,
                                                    ICollection<DictionaryEntry<Type, DataTemplate>>
    {
    }

    //, ICollection<DictionaryEntry<Type, DataTemplate>> { }
}