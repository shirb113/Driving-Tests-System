﻿#pragma checksum "..\..\AddTestPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AF4B587627BE05873E615FBFF2F80F6F6929D65D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLWPF;
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


namespace PLWPF {
    
    
    /// <summary>
    /// AddTestPage
    /// </summary>
    public partial class AddTestPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label welcome;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TestNum;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TesterId;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TraineeId;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateOfTest;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CitytextBox;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StreettextBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HousetextBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CarcomboBox;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GearcomboBox;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TesterNote;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\AddTestPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OKbutton;
        
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
            System.Uri resourceLocater = new System.Uri("/PLWPF;component/addtestpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddTestPage.xaml"
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
            this.welcome = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.TestNum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TesterId = ((System.Windows.Controls.TextBox)(target));
            
            #line 58 "..\..\AddTestPage.xaml"
            this.TesterId.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TraineeId = ((System.Windows.Controls.TextBox)(target));
            
            #line 59 "..\..\AddTestPage.xaml"
            this.TraineeId.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DateOfTest = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.CitytextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.StreettextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.HousetextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 63 "..\..\AddTestPage.xaml"
            this.HousetextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CarcomboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.GearcomboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.TesterNote = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.OKbutton = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\AddTestPage.xaml"
            this.OKbutton.Click += new System.Windows.RoutedEventHandler(this.OKbutton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

