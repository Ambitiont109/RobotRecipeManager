   M S B A M L   `   `   `  ���� M  IRobotRecipeManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:RobotRecipeManagerRobotRecipeManager  \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35  �� MergedDictionaries �� Source   	MyToolbar  ToolbarGroup �� Orientation  ToolBarButtonBaseStyle.   (System.Windows.Input.ApplicationCommands
    New �� ElementName � RowDefinitions'   !RobotRecipeManager.DesignerCanvas   Save_Recipe_Template   Load_Recipe � ColumnDefinitions	   Save_Recipe
    Print    Paste
    Cut    Copy    Delete    Save    Open  ToolbarBorderBrush	 �� X1	 �� Y1	 �� X2	 �� Y2 �� Stretch   Group   Ungroup   BringForward   BringToFront   SendBackward   
SendToBack�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    &s clr-namespace:RobotRecipeManager    �� $ Styles/Shared.xaml?��� $ Styles/ToolBar.xaml?�%�  &	        7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  c� $	��120��.@��� $
��File��8��  $��5,3,3,3q�.���� $��1��$ 
Horizontal=�.+��� $��3q�$	��102��8�� $��Center=�#��Z ���� $ 
MyDesigner�����  �� $��4* ��� $��1* �.+��� $ ��Images/GenericDocument.png��$��45���� $��1��$��Create New Recipe��$��Bottom=�$��Center=��� $��3q�$	��115��8�� $��Center=�#��Z ���� $ 
MyDesigner�����  �� $��4* ��� $��1* �.+��� $��Images/btn_plus.png��$��45���� $��1��$��Save Recipe Template��$��Bottom=�$��Center=��� $ Vertical=�$��0,2,0,2q�.+��� $��1q�$��2q�$
��Left=�8�� #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/OpenFolder.png��$��16���� $��3,0,3,0q�$��Load Recipe��$��Center=�$��1���� $��1q�$��2q�$
��Left=�8�� #��Z	 ���� $ 
MyDesigner�����  �� �� .+��� $��Images/Save.png��$��16���� $��3,0,3,0q�$��Save Recipe��$��Center=�$��1���� $��1q�$��2q�$
��Left=�8�� #��Z
 ���� $ 
MyDesigner�����  �� �� .+��� $��Images/Print.png��$��16���� $��3,0,3,0q�$��Print Recipe��$��Center=�$��1���� $
��Edit��8�� $��3q�.���� $��1��$ 
Horizontal=�.+��� $��3q�$��55��8�� #��Z ���� $ 
MyDesigner�����  �� $��4* ��� $��1* �.+��� $��Images/PasteBig.png��$��45���� $��1��$��Paste��$��Bottom=�$��Center=��� $ Vertical=�$��0,2,0,2q�.+��� $��1q�$��2q�$
��Left=�8�� #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/Cut.png��$��16���� $��3,0,3,0q�$	��Cut��$��Center=�$��1���� $��1q�$��2q�$
��Left=�8��	 #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/Copy.png��$��16���� $��3,0,3,0q�$
��Copy��$��Center=�$��1���� $��1q�$��2q�$
��Left=�8��
 #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/Delete.png��$��16���� $��3,0,3,0q�$��Delete��$��Center=�$��1���� $��Import/Export Recipe ��8�� $��3q�.���  �� $
��Auto ��� .+��� $��0��$ Vertical=�$��5,-3,5,0q�.+��� $��3q�$��5q�$
��Left=�8�� #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/export.png��$��16���� $��3q�$��Export Recipe��$��Center=�$��1���� $��3q�$��5q�$
��Left=�8�� #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/import.png��$��16���� $��3q�$��Import Recipe��$��Center=�$��1���� 8�� $��1��$ 0��$ 0��$ 0��$ 20��$
 Fill=�$
��Left=�$��3,0,0,0q�$��1���� $��Arrange��8�� $��3q�.���  �� $
��Auto ��� �� .+��� .+��� $��0,1,0,3q�$��5q�$
��Left=�8�� #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/Group.png��$��16���� $��3q�$��Group��$��Center=�$��1���� $��0,2,0,3q�$��5q�$
��Left=�8�� #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/Ungroup.png��$��16���� $��3q�$��Ungroup��$��Center=�$��1���� $��1��$��7,0,0,0q�.+��� $��0,1,0,3q�$��5q�$
��Left=�8�� #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/BringForward.png��$��16���� $��3q�$��Forward��$��Center=�$��1���� $��0,2,0,3q�$��5q�$
��Left=�8�� #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/BringToFront.png��$��16���� $��3q�$��To Front��$��Center=�$��1���� 8�� $��1��$ 0��$ 0��$ 0��$ 20��$
 Fill=�$
��Left=�$��1��$��3,0,0,0q��� $��2��.+��� $��0,1,0,3q�$��5q�$
��Left=�8�� #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/SendBackward.png��$��16���� $��3q�$��Backward��$��Center=�$��1���� $��0,2,0,3q�$��5q�$
��Left=�8�� #��Z ���� $ 
MyDesigner�����  �� �� .+��� $��Images/SendToBack.png��$��16���� $��3q�$��To Back��$��Center=�$��1��