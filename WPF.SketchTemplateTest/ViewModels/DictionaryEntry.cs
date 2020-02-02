// -----------------------------------------------------------------------
// <copyright file="DictionaryEntry.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace WPF.SketchTemplateTest.ViewModels
{
    public class DictionaryEntry<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }
    }
}