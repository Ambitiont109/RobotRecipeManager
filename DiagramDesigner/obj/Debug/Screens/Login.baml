   M S B A M L   `   `   `  ����M  IRobotRecipeManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:RobotRecipeManagerRobotRecipeManager  5   	   I)clr-namespace:RobotRecipeManager.ControlsRobotRecipeManager.Controls  5   	   &     RobotRecipeManager.Screens.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .s clr-namespace:RobotRecipeManager     5   	   7c)clr-namespace:RobotRecipeManager.Controls     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$  Robot Recipe Manager��5   	   $	��850��5   	   $
��1000��6   ���	#FFF99D3F.��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��351,29.5,351,843q�6   $A��;/RobotRecipeManager;component/Resources/Images/conveyor.png��6*   $
��Fill=�6o   �� 5   
   $��ROBOT MANAGER��6   $
��Left=�6(   $	��Top=�6C   $��274.5,325,0,0q�6[   $��50(�6r   �� 5   
   -   5        $��Username��5      $
��Left=�6#    J� Opacity$	 0.5Q�6>   $��34��6L   $��452.5,489,0,0q�6X    �� TextWrapping$
 Wrap=�6o   $�� ��6�   $	��Top=�6�   $��250.5��6�   $��16(�6�    �� CharacterCasing$ Upper=�6�   G� 5   
   -   5        $��Password��5      $
��Left=�6'   $	 0.5Q�6B   $��34��6P   $��452.5,561,0,0q�6\   $	��Top=�6s   $��250.5��6�   $��16(�6�   �� 5   
   $��Username/Initials��6   $
��Left=�6,   $��251.5,489,0,0q�6G   $	��Top=�6^    J� RenderTransformOrigin$ 0.553,-0.885&�6v   $��18(�6�   �� 5   
   $��Password��6   $
��Left=�6#   $��251.5,561,0,0q�6>   $	��Top=�6U   $ 0.553,-0.885&�6m   $��18(�6�   �� 5   
   -   5        $��LOGIN��5      $
��Left=�6!   $��351,674,0,0q�6<   $	��Top=�6Q   $��190.5��6i   $��35��6w    � IsSharedSizeScope .    	ItemBrush#���   6�   $��20(�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5      � 
 � Color$
 Black��6#    � Offset$ 0Q�61   � 5      $
 	#FFE03E3E��6#   $ 1Q�65   5      5      5       5!      