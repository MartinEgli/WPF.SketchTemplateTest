// -----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows;

namespace WPF.SketchTemplateTest
{
    using System.Reflection;

    using WPF.SketchTemplateTest.ViewModelInterfaces;
    using WPF.SketchTemplateTest.ViewModels;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            var resourceDictionary = new ResourceDictionary
            {
                Source = new ResourceUriBuilder("TestResources.xaml")
                                                 .AddAuthorityAppliction()
                                                 .AddAssembly(Assembly.GetExecutingAssembly())
                                                 .Build()
            };

            var viewModel = new ParametersDummyViewModel();
            viewModel.ParameterTemplateDictionary = new ParameterTemplateDictionary();
            {
                if (resourceDictionary["ParameterDataTemplate"] is DataTemplate parameterDataTemplate)
                {
                    viewModel.ParameterTemplateDictionary.Add(
                        new DictionaryEntry<Type, DataTemplate>
                        {
                            Key = parameterDataTemplate.DataType as Type,
                            Value = parameterDataTemplate
                        });
                }
            }

            {
                if (resourceDictionary["IntegerParameterTemplate"] is DataTemplate parameterDataTemplate)
                {
                    viewModel.ParameterTemplateDictionary.Add(
                        new DictionaryEntry<Type, DataTemplate>
                        {
                            Key = parameterDataTemplate.DataType as Type,
                            Value = parameterDataTemplate
                        });
                }
            }

            {
                if (resourceDictionary["StringParameterTemplate"] is DataTemplate parameterDataTemplate)
                {
                    viewModel.ParameterTemplateDictionary.Add(
                        new DictionaryEntry<Type, DataTemplate>
                        {
                            Key = parameterDataTemplate.DataType as Type,
                            Value = parameterDataTemplate
                        });
                }
            }

            if (resourceDictionary["SketchDataTemplate"] is DataTemplate dataTemplate)
            {
                viewModel.SketchTemplate = dataTemplate;
            }

            viewModel.Title = "Hall Martin";
            viewModel.Parameters = new ParameterCollection();
            if (resourceDictionary["Sketch1Template"] is DataTemplate template1)
            {
                viewModel.Parameters.Add(new ParameterViewModel { SketchTemplate = template1 });
            }

            if (resourceDictionary["Sketch2Template"] is DataTemplate template2)
            {
                viewModel.Parameters.Add(new ParameterViewModel { SketchTemplate = template2 });
            }

            {
                if (resourceDictionary["Sketch3Template"] is DataTemplate template)
                {
                    viewModel.Parameters.Add(new IntegerParameterViewModel { SketchTemplate = template });
                }
            }

            {
                if (resourceDictionary["Sketch4Template"] is DataTemplate template)
                {
                    viewModel.Parameters.Add(new StringParameterViewModel { SketchTemplate = template });
                }
            }
            {
                if (resourceDictionary["Sketch5Template"] is DataTemplate template)
                {
                    viewModel.Parameters.Add(new StringParameterViewModel { SketchTemplate = template });
                }
            }

            this.DataContext = viewModel;
        }
    }
}