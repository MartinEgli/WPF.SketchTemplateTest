// -----------------------------------------------------------------------
// <copyright file="ParametersView.xaml.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Controls;

namespace WPF.SketchTemplateTest.Views
{
    using System.Windows.Input;

    /// <summary>
    ///     Interaction logic for ParametersView.xaml
    /// </summary>
    public partial class ParametersView : UserControl
    {
        public ParametersView()
        {
            this.InitializeComponent();
        }

        protected void SelectCurrentItem(object sender, KeyboardFocusChangedEventArgs e)
        {
            var item = (ListViewItem)sender;
            item.IsSelected = true;
        }
    }
}