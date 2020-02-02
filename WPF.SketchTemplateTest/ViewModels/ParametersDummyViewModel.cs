// -----------------------------------------------------------------------
// <copyright file="ParametersDummyViewModel.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace WPF.SketchTemplateTest.ViewModels
{
    #region

    using Microsoft.Xaml.Behaviors.Core;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using WPF.SketchTemplateTest.ViewModelInterfaces;

    #endregion

    public class ParametersDummyViewModel : Bindable, IParametersViewModel
    {
        private ParameterCollection parameters;

        private IParameterTemplateDictionary parameterTemplateDictionary;

        private DataTemplateSelector parameterTemplateSelector =
            new ParameterTemplateSelector(new ParameterTemplateDictionary());

        private DataTemplate sketchTemplate;

        private string title = "Init";

        public ParametersDummyViewModel()
        {
            this.ParameterTemplateSelector = new ParameterTemplateSelector(this.ParameterTemplateDictionary);

            this.SelectionChangedCommand = new ActionCommand(this.SelectionChanged);
        }

        public string Title
        {
            get => this.title;
            set
            {
                if (value == this.title)
                {
                    return;
                }

                this.title = value;
                this.OnPropertyChanged();
            }
        }

        public DataTemplateSelector ParameterTemplateSelector
        {
            get => this.parameterTemplateSelector;
            private set
            {
                if (Equals(value, this.parameterTemplateSelector))
                {
                    return;
                }

                this.parameterTemplateSelector = value;
                this.OnPropertyChanged();
            }
        }

        public ParameterCollection Parameters
        {
            get => this.parameters;
            set
            {
                if (Equals(value, this.parameters))
                {
                    return;
                }

                this.parameters = value;
                this.OnPropertyChanged();
            }
        }

        public DataTemplate SketchTemplate
        {
            get => this.sketchTemplate;
            set
            {
                if (Equals(value, this.sketchTemplate))
                {
                    return;
                }

                this.sketchTemplate = value;
                this.OnPropertyChanged();
            }
        }

        public IParameterTemplateDictionary ParameterTemplateDictionary
        {
            get => this.parameterTemplateDictionary;
            set
            {
                this.parameterTemplateDictionary = value;
                this.ParameterTemplateSelector = new ParameterTemplateSelector(this.ParameterTemplateDictionary);
            }
        }

        public ICommand SelectionChangedCommand { get; set; }

        private void SelectionChanged(object o)
        {
            if (!(o is ISketchTemplateAware sketchTemplateAware))
            {
                return;
            }

            if (sketchTemplateAware.SketchTemplate != null)
            {
                this.SketchTemplate = sketchTemplateAware.SketchTemplate;
            }
        }
    }
}