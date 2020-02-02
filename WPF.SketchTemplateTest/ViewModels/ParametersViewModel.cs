// -----------------------------------------------------------------------
// <copyright file="ParametersViewModel.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace WPF.SketchTemplateTest.ViewModels
{
    using Microsoft.Xaml.Behaviors.Core;

    using System.Windows;
    using System.Windows.Input;

    using WPF.SketchTemplateTest.ViewModelInterfaces;

    public class ParametersViewModel : Bindable, IParametersViewModel
    {
        public ParametersViewModel()
        {
            this.SelectionChangedCommand = new ActionCommand(o => this.SelectionChanged(o));
        }

        public ParameterCollection Parameters { get; set; }

        public DataTemplate SketchTemplate { get; set; }

        public IParameterTemplateDictionary ParameterTemplateDictionary { get; set; }

        public ICommand SelectionChangedCommand { get; }

        private void SelectionChanged(object o)
        {
        }
    }
}