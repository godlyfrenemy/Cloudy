// Updated by XamlIntelliSenseFileGenerator 01.05.2021 0:26:32
#pragma checksum "..\..\InfoWeatherForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2EDCACDDC16103D59693707AE6EBC7B4E976AFD3E57F61BAA96679237AAFFC1D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using cloudy;


namespace cloudy
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 65 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label WindowLabel;

#line default
#line hidden


#line 66 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid WeatherTable;

#line default
#line hidden


#line 92 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer EditForm;

#line default
#line hidden


#line 101 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteButton;

#line default
#line hidden


#line 102 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditButton;

#line default
#line hidden


#line 103 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;

#line default
#line hidden


#line 125 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;

#line default
#line hidden


#line 128 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox city_box;

#line default
#line hidden


#line 131 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox day_box;

#line default
#line hidden


#line 134 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox month_box;

#line default
#line hidden


#line 150 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox temp_box;

#line default
#line hidden


#line 153 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox precip_box;

#line default
#line hidden


#line 159 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pressure_box;

#line default
#line hidden


#line 165 "..\..\InfoWeatherForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LogInButton;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/cloudy;component/infoweatherform.xaml", System.UriKind.Relative);

#line 1 "..\..\InfoWeatherForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.InfoWeatherForm = ((cloudy.MainWindow)(target));
                    return;
                case 2:
                    this.WindowLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 3:
                    this.WeatherTable = ((System.Windows.Controls.DataGrid)(target));
                    return;
                case 4:
                    this.EditForm = ((System.Windows.Controls.ScrollViewer)(target));
                    return;
                case 5:
                    this.DeleteButton = ((System.Windows.Controls.Button)(target));

#line 101 "..\..\InfoWeatherForm.xaml"
                    this.DeleteButton.Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.EditButton = ((System.Windows.Controls.Button)(target));

#line 102 "..\..\InfoWeatherForm.xaml"
                    this.EditButton.Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);

#line default
#line hidden
                    return;
                case 7:
                    this.AddButton = ((System.Windows.Controls.Button)(target));

#line 103 "..\..\InfoWeatherForm.xaml"
                    this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.SaveButton = ((System.Windows.Controls.Button)(target));
                    return;
                case 9:
                    this.city_box = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 10:
                    this.day_box = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 11:
                    this.month_box = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 12:
                    this.temp_box = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 13:
                    this.precip_box = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 14:
                    this.pressure_box = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 15:
                    this.LogInButton = ((System.Windows.Controls.Button)(target));

#line 165 "..\..\InfoWeatherForm.xaml"
                    this.LogInButton.Click += new System.Windows.RoutedEventHandler(this.LogInButton_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Window InfoWeatherForm;
    }
}

