   M S B A M L   `   `   `  ����M  IRobotRecipeManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:RobotRecipeManagerRobotRecipeManager  5   	   I)clr-namespace:RobotRecipeManager.ControlsRobotRecipeManager.Controls  5   	   (    "RobotRecipeManager.Recipe_Creation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .s clr-namespace:RobotRecipeManager     5   	   7c)clr-namespace:RobotRecipeManager.Controls     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$  Robot Recipe Manager��5   	   $	��850��5   	   $
��1000��6    � 	Resources 5
         DesignerCanvasContextMenu.  (System.Windows.Input.ApplicationCommands   Paste m� Command m� Icon'   !RobotRecipeManager.DesignerCanvas   	SelectAll��%�   &	        �� 5   
   .@�5      m� $��Paste��6   # Z 6&    5      �� 5      $>��8/RobotRecipeManager;component/Resources/Images/Paste.png��6   $��16��6^   5      m� 5      $��
Select All��6   # Z 6+   5      5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��   	MyToolbar#��[ 6   � 5   
   $��1��6   $��0,10,0,0q�6    � ColumnDefinitions 5      �� 5      $	��220 �6#   �� 5       .+�5#      �� $��0��6   $��0,0,0,0q�6)   .+�5$      9� -   5        	 9�Name$	 
Flow_Chart��5$      $��Images/Icons��6/     FlowChartStencils#��[ 6E   
 9� 
IsExpanded
 . 6r   �� 5%      $��0��6   $��0��6&   $��10q�66   ._�5&      �� -   5        $��Add_Remove_Img��5&      $��Add or Remove Images��64   6T   5'      � 5(      .+�5)      �� $��1��6   $��1��6*   $��10q�6:   ._�5*      �� -   5        $��Top_Size_Lbl��5*       $��-1,1,2,0q�64   .��6F   Enter Top Size6V   5+      �� 5,      $��2��6   $��1��6*   $��10q�6:   $��0,25,0,0q�6O   ._�5.      �� -   5        $��Top_Size��5.   #    J� InputBindings 5/      �� 50   "   52      53      54      � 55      .+�56      �� $��1��6   $��1��6*   $��10q�6:   ._�57      �� -   5        $��Mass_Lbl��57       $��-1,0,2,0q�60   .��6B   
Enter Mass6N   58      �� 59      $��4��6   $��1��6*   $��10q�6:   $��0,25,0,0q�6O   ._�5:      �� -   5        $
��Mass��5:   "   .��6r    5;      �� 5<   "      Load_Recipe �� Command# Z 5=   %   
 �� Key$ Return��6W   .��5>   5   5?      5@      5A      5D      �� 5F      |�.  $��2��6-   
�������$��Stretch=�5G      $��Right=�61   �� 5I      $��Diagram��6   $��1��6(   $��3,0,0,0q�68   .��5J      �� $
��Auto=�6   $
��Auto=�5K      .��5L        -   5          Name$ 
MyDesigner��5L   8   |�.   WindowBackgroundBrush#��[ 5M      $��10q�5N       � ContextMenu# [  5O       � FocusVisualStyle 5N   )   Z� 5O      5P      5Q      5R      5T      5U      