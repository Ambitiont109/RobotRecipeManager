﻿#pragma checksum "..\..\Recipe_Creation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BBD2D2E49FDFC307953877D35B153EC676251D60E81E4640AD03D187239543C8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RobotRecipeManager;
using RobotRecipeManager.Controls;
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


namespace RobotRecipeManager {
    
    
    /// <summary>
    /// Recipe_Creation
    /// </summary>
    public partial class Recipe_Creation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\Recipe_Creation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander Flow_Chart;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Recipe_Creation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_Remove_Img;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Recipe_Creation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Top_Size_Lbl;
        
        #line default
        #line hidden
        
        /// <summary>
        /// Top_Size Name Field
        /// </summary>
        
        #line 48 "..\..\Recipe_Creation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.ComboBox Top_Size;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Recipe_Creation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Mass_Lbl;
        
        #line default
        #line hidden
        
        /// <summary>
        /// Mass Name Field
        /// </summary>
        
        #line 60 "..\..\Recipe_Creation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBox Mass;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\Recipe_Creation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal RobotRecipeManager.DesignerCanvas MyDesigner;
        
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
            System.Uri resourceLocater = new System.Uri("/RobotRecipeManager;component/recipe_creation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Recipe_Creation.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.Flow_Chart = ((System.Windows.Controls.Expander)(target));
            return;
            case 2:
            this.Add_Remove_Img = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Recipe_Creation.xaml"
            this.Add_Remove_Img.Click += new System.Windows.RoutedEventHandler(this.Chart_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Top_Size_Lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Top_Size = ((System.Windows.Controls.ComboBox)(target));
            
            #line 48 "..\..\Recipe_Creation.xaml"
            this.Top_Size.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Top_Size_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Mass_Lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Mass = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\Recipe_Creation.xaml"
            this.Mass.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MyDesigner = ((RobotRecipeManager.DesignerCanvas)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

