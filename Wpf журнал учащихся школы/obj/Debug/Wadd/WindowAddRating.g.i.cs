﻿#pragma checksum "..\..\..\WAdd\WindowAddRating.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4518A6329429F58E48647BD7187FAE825901F695"
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
using Wpf_журнал_учащихся_школы.WAdd;
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


namespace Wpf_журнал_учащихся_школы.WAdd {
    
    
    /// <summary>
    /// WindowAddRating
    /// </summary>
    public partial class WindowAddRating : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\WAdd\WindowAddRating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FIOCB;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\WAdd\WindowAddRating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox MissedChB;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\WAdd\WindowAddRating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker DayB;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\WAdd\WindowAddRating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RatingCB;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\WAdd\WindowAddRating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CommentTB;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\WAdd\WindowAddRating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBN;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\WAdd\WindowAddRating.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Wpf журнал учащихся школы;component/wadd/windowaddrating.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WAdd\WindowAddRating.xaml"
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
            this.FIOCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.MissedChB = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.DayB = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            case 4:
            this.RatingCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.CommentTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AddBN = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\WAdd\WindowAddRating.xaml"
            this.AddBN.Click += new System.Windows.RoutedEventHandler(this.AddBN_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CancelBN = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\WAdd\WindowAddRating.xaml"
            this.CancelBN.Click += new System.Windows.RoutedEventHandler(this.CancelBN_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

