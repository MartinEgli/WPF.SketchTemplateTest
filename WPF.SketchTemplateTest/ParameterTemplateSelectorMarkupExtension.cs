namespace WPF.SketchTemplateTest
{
    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    using WPF.SketchTemplateTest.ViewModelInterfaces;

    public class ParameterTemplateSelectorMarkupExtension : MarkupExtension
    {
        public static readonly DependencyProperty DictionaryProperty = DependencyProperty.Register("Dictionary", typeof(IParameterTemplateDictionary), typeof(ParameterTemplateSelectorMarkupExtension), new PropertyMetadata(default(IParameterTemplateDictionary)));

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            DependencyObject targetObject;
            DependencyProperty targetProperty;

            if (target != null && target.TargetObject is DependencyObject && target.TargetProperty is DependencyProperty)
            {
                targetObject = (DependencyObject)target.TargetObject;
                targetProperty = (DependencyProperty)target.TargetProperty;
            }
            else
            {
                return this; // magic
            }

            // Bind the Param1 to attached property Param1BindingSinkProperty 
            BindingOperations.SetBinding(targetObject, ParameterTemplateSelectorMarkupExtension.BindingSinkProperty, DictionaryBinding);

            // Now you can use Param1

            // Param1 direct access example:
            IParameterTemplateDictionary param1Value = (IParameterTemplateDictionary)targetObject.GetValue(BindingSinkProperty);

            // Param1 use in binding example:
            var param1InnerBinding = new Binding() { Source = targetObject, Path = new PropertyPath("(0).SomeInnerProperty", BindingSinkProperty) }; // binding to Param1.SomeInnerProperty
            var binding = param1InnerBinding.ProvideValue(serviceProvider); // return binding to Param1.SomeInnerProperty
            return new ParameterTemplateSelector(param1Value);
        }

        private static DependencyProperty BindingSinkProperty = DependencyProperty.RegisterAttached("BindingSink", typeof(object)// set the desired type of Param1 for at least runtime type safety check
            , typeof(ParameterTemplateSelectorMarkupExtension), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));


        public Binding DictionaryBinding
        {
            get;
            set;
        }
    }
}