   M S B A M L   `   `   `  ���� M  IRobotRecipeManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:RobotRecipeManagerRobotRecipeManager  I)clr-namespace:RobotRecipeManager.ControlsRobotRecipeManager.Controls       RobotRecipeManager.Window1   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    ,s clr-namespace:RobotRecipeManager    5c)clr-namespace:RobotRecipeManager.Controls      � WindowStartupLocation$  CenterScreen=� � Title$  Robot Recipe Manager��$	��850��$
��1000�� � 	Resources    DesignerCanvasContextMenu.  (System.Windows.Input.ApplicationCommands   Paste m� Command m� Icon'   !RobotRecipeManager.DesignerCanvas   	SelectAll��%z   &	        �� .@�m� $��Paste��# Z  �� $ ��Resources/Images/Paste.png��$��16��m� $��
Select All��# Z .��� $��10q� � RowDefinitions �� $
��Auto ��� $��* �.+���   	MyToolbar#��[ � $��1��$��0,10,0,0q� � ColumnDefinitions �� $	��265 ��� .+��� $��0��$��0,0,0,0q�.+�9� -   	 9�Name$	 
Flow_Chart��$��Images/Icons��  FlowChartStencils#��[ 
 9� 
IsExpanded
 . �� $��0��$��0��$��10q�._��� -   $��Add or Remove Images��� .+��� $��1��$��1��$��10q�._��� -   $��Top_Size_Lbl��$��-1,1,2,0q�.��Enter Top Size�� $��2��$��1��$��10q�$��0,25,0,0q�._��� -   $��Top_Size��� .+��� $��1��$��1��$��10q�._��� -   $��Mass_Lbl��$��-1,0,2,0q�.��
Enter Mass�� $��4��$��1��$��10q�$��0,25,0,0q�._��� -   $
��Mass���� |�.  $��2��
�������$��Stretch=�$��Right=��� $��Diagram��$��1��$��3,0,0,0q�.���� $
��Auto=�$
��Auto=�.��  -     Name$ 
MyDesigner��|�.   WindowBackgroundBrush#��[ $��10q� � ContextMenu# [   � FocusVisualStyle Z� 