﻿#pragma checksum "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E4DFC7459F26E4D50E1FA10C54DBA849"
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


namespace Magankorhaz.UserControlok {
    
    
    /// <summary>
    /// OrvosUjIdopontFelvetele
    /// </summary>
    public partial class OrvosUjIdopontFelvetele : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox idopontOrvos;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idopontReszletek;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UjIdopontMentesGomb;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker idopontDatum;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox idopontOra;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox idopontPerc;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox foglaltIdopontokListBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox idopontPaciens;
        
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
            System.Uri resourceLocater = new System.Uri("/Magankorhaz;component/usercontrolok/orvosujidopontfelvetele.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
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
            this.idopontOrvos = ((System.Windows.Controls.ComboBox)(target));
            
            #line 9 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
            this.idopontOrvos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.idopontOrvos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.idopontReszletek = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.UjIdopontMentesGomb = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
            this.UjIdopontMentesGomb.Click += new System.Windows.RoutedEventHandler(this.UjIdopontMentesGomb_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.idopontDatum = ((System.Windows.Controls.DatePicker)(target));
            
            #line 16 "..\..\..\UserControlok\OrvosUjIdopontFelvetele.xaml"
            this.idopontDatum.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.idopontDatum_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.idopontOra = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.idopontPerc = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.foglaltIdopontokListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            this.idopontPaciens = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

