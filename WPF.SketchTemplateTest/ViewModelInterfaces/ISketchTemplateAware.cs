// -----------------------------------------------------------------------
// <copyright file="ISketchTemplateAware.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace WPF.SketchTemplateTest.ViewModelInterfaces
{
    using System.Windows;

    internal interface ISketchTemplateAware
    {
        DataTemplate SketchTemplate { get; }
    }
}