﻿#pragma checksum "..\..\SzamlahozTetelHozzaadWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4C3CF4DF27C389313D2BDD1E12DB014D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace Magankorhaz {
    
    
    /// <summary>
    /// SzamlahozTetelHozzaadWindow
    /// </summary>
    public partial class SzamlahozTetelHozzaadWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\SzamlahozTetelHozzaadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SzolgaltatasAraLabel;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\SzamlahozTetelHozzaadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox kezeloorvosComboBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\SzamlahozTetelHozzaadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button okbutton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\SzamlahozTetelHozzaadWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox szolgaltatasneveComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Magankorhaz;component/szamlahoztetelhozzaadwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SzamlahozTetelHozzaadWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\SzamlahozTetelHozzaadWindow.xaml"
            ((Magankorhaz.SzamlahozTetelHozzaadWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SzolgaltatasAraLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.kezeloorvosComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\SzamlahozTetelHozzaadWindow.xaml"
            this.kezeloorvosComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.kezeloorvosComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.okbutton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\SzamlahozTetelHozzaadWindow.xaml"
            this.okbutton.Click += new System.Windows.RoutedEventHandler(this.OKButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.szolgaltatasneveComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\SzamlahozTetelHozzaadWindow.xaml"
            this.szolgaltatasneveComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.szolgaltatasneveComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

