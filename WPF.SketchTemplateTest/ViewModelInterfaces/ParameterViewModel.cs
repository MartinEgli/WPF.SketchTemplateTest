// -----------------------------------------------------------------------
// <copyright file="ParameterViewModel.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace WPF.SketchTemplateTest.ViewModelInterfaces
{
    using System.Windows;

    using WPF.SketchTemplateTest.ViewModels;

    public class ParameterViewModel : Bindable, IParameterViewModel, ISketchTemplateAware
    {
        private DataTemplate sketchTemplate;

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
    }

    public class IntegerParameterViewModel : Bindable, IIntegerParameterViewModel, ISketchTemplateAware
    {
        private DataTemplate sketchTemplate;

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

        public int Value { get; set; }
    }

    public class StringParameterViewModel : Bindable, IStringParameterViewModel, ISketchTemplateAware
    {
        private DataTemplate sketchTemplate;

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

        public string Text { get; set; }
    }

    public interface IIntegerParameterViewModel : IIntegerReadOnlyParameterViewModel
    {
        new int Value { get; set; }
    }

    public interface IIntegerReadOnlyParameterViewModel : IParameterViewModel
    {
        int Value { get; }
    }

    public interface IStringParameterViewModel : IStringReadOnlyParameterViewModel
    {
        new string Text { get; set; }
    }

    public interface IStringReadOnlyParameterViewModel : IParameterViewModel
    {
        string Text { get; }
    }
}