﻿#pragma checksum "..\..\..\WSearch\WSearch.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CAED31DF69ACD8A3EA202C307502566B4AF22D7C"
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
using Wpf_журнал_учащихся_школы.WSearch;


namespace Wpf_журнал_учащихся_школы.WSearch {
    
    
    /// <summary>
    /// WSearch
    /// </summary>
    public partial class WSearch : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\WSearch\WSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategoryCB;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\WSearch\WSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTB;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\WSearch\WSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridTotal;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\WSearch\WSearch.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBN;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\WSearch\WSearch.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Wpf журнал учащихся школы;component/wsearch/wsearch.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WSearch\WSearch.xaml"
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
            this.CategoryCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\..\WSearch\WSearch.xaml"
            this.CategoryCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CategoryCB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.DataGridTotal = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\WSearch\WSearch.xaml"
            this.DataGridTotal.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridTotal_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddBN = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\WSearch\WSearch.xaml"
            this.AddBN.Click += new System.Windows.RoutedEventHandler(this.AddBN_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CancelBN = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\WSearch\WSearch.xaml"
            this.CancelBN.Click += new System.Windows.RoutedEventHandler(this.CancelBN_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

