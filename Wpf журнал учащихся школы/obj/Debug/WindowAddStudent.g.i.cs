﻿#pragma checksum "..\..\WindowAddStudent.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75499E7B3B6303816BF44FFC8FB1381FDCF04025"
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
using Wpf_журнал_учащихся_школы;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace Wpf_журнал_учащихся_школы {
    
    
    /// <summary>
    /// WindowAddStudent
    /// </summary>
    public partial class WindowAddStudent : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\WindowAddStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ClassCB;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\WindowAddStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MedGroupCB;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\WindowAddStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FIOTB;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\WindowAddStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SexCB;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\WindowAddStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker DayB;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\WindowAddStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TelTB;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\WindowAddStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBN;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\WindowAddStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBN;
        
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
            System.Uri resourceLocater = new System.Uri("/Wpf журнал учащихся школы;component/windowaddstudent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowAddStudent.xaml"
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
            this.ClassCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\WindowAddStudent.xaml"
            this.ClassCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ClassCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MedGroupCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\WindowAddStudent.xaml"
            this.MedGroupCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.MedGroupCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FIOTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.SexCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\WindowAddStudent.xaml"
            this.SexCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SexCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DayB = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            case 6:
            this.TelTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.AddBN = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\WindowAddStudent.xaml"
            this.AddBN.Click += new System.Windows.RoutedEventHandler(this.AddBN_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CancelBN = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\WindowAddStudent.xaml"
            this.CancelBN.Click += new System.Windows.RoutedEventHandler(this.CancelBN_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

