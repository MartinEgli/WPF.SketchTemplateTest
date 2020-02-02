// -----------------------------------------------------------------------
// <copyright file="ParameterTemplateSelector.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace WPF.SketchTemplateTest
{
    #region

    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Markup;

    using WPF.SketchTemplateTest.Annotations;
    using WPF.SketchTemplateTest.ViewModelInterfaces;

    #endregion

    public class ParameterTemplateSelectorExtension : MarkupExtension
    {
        public Binding DictionaryBinding { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new MultiBinding();
            binding.Bindings.Add(this.DictionaryBinding);
            binding.Converter = new ParameterTemplateSelectorConvertor();
            return binding.ProvideValue(serviceProvider);
        }
    }

    internal class ParameterTemplateSelectorConvertor : IMultiValueConverter
    {
        public object Convert([NotNull] object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.Length != 1) throw new ArgumentNullException(nameof(values));
            if (!(values[0] is IParameterTemplateDictionary value)) return null;
            return new ParameterTemplateSelector(value);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ParameterTemplateSelector : DataTemplateSelector
    {
        private readonly IParameterTemplateDictionary dictionary;

        public ParameterTemplateSelector(IParameterTemplateDictionary dictionary)
        {
            this.dictionary = dictionary;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (container is FrameworkElement element && item != null)
            {
                //if (this.dictionary.TryGetValue(item.GetType(), out var template))
                if (this.dictionary.TryGetValue(item.GetType(), out var template))
                {
                    return template;
                }
            }

            return null;
        }
    }
}