﻿#pragma checksum "..\..\EditStation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "97AD922BFA5BBD7BC29E4827595D96E9B1BCC0DB69643A329A7B273509C6455E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Rattler;
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


namespace Rattler {
    
    
    /// <summary>
    /// EditStation
    /// </summary>
    public partial class EditStation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\EditStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\EditStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BoxMetro;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\EditStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BoxTram;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\EditStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BoxTrain;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EditStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BoxExpressTrain;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\EditStation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BoxComplex;
        
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
            System.Uri resourceLocater = new System.Uri("/Rattler;component/editstation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditStation.xaml"
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
            this.BoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BoxMetro = ((System.Windows.Controls.CheckBox)(target));
            
            #line 16 "..\..\EditStation.xaml"
            this.BoxMetro.Checked += new System.Windows.RoutedEventHandler(this.setMetro);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BoxTram = ((System.Windows.Controls.CheckBox)(target));
            
            #line 17 "..\..\EditStation.xaml"
            this.BoxTram.Checked += new System.Windows.RoutedEventHandler(this.setTram);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BoxTrain = ((System.Windows.Controls.CheckBox)(target));
            
            #line 18 "..\..\EditStation.xaml"
            this.BoxTrain.Checked += new System.Windows.RoutedEventHandler(this.setTrain);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BoxExpressTrain = ((System.Windows.Controls.CheckBox)(target));
            
            #line 19 "..\..\EditStation.xaml"
            this.BoxExpressTrain.Checked += new System.Windows.RoutedEventHandler(this.setExpressTrain);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BoxComplex = ((System.Windows.Controls.CheckBox)(target));
            
            #line 20 "..\..\EditStation.xaml"
            this.BoxComplex.Checked += new System.Windows.RoutedEventHandler(this.setComplex);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 23 "..\..\EditStation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.done);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

