   M S B A M L   `   `   `  ����F  BHCI-P1-Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HCI_P1_GameHCI_P1_Game  5   	       HCI_P1_Game.GameWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:HCI_P1_Game     5   	     � Title$  
GameWindow��5   	   $	��700��6   $
��1200��6)    � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 
ResizeMode$ NoResize=�6.   .��5      �    BackgroundColor1#���   6   .+�5   
   �� -   5         ��Name$ 
TbQuestion��5      $
��Left=�6&   $��65��6A   $��242,361,0,0q�6M   $��TextBox��6b    �� TextWrapping$
 Wrap=�6q   $	��Top=�6�   $	��355��6�   
����d�$��Center=�6�   $��Center=�6�    �� 
IsReadOnly$
 True��6  �� 5   
   -   5         ��Name$ 
BtnAnswerA��5      $�� ��6%   $
��Left=�60   $��130,460,0,0q�6K   $	��Top=�6`   $��61��6x   $	��246��6�     RoundedAnswerButtonStyle#���  6�   �� 5   
   -   5        $ 
BtnAnswerB��5      $�� ��6%   $
��Left=�60   $��442,461,0,0q�6K   $	��Top=�6`   $��61��6x   $	��235��6�   #���  6�   �� 5   
   -   5        $ 
BtnAnswerC��5      $�� ��6%   $
��Left=�60   $��130,544,0,0q�6K   $	��Top=�6`   $��61��6x   $	��242��6�   #���  6�   �� 5   
   -   5        $ 
BtnAnswerD��5      $�� ��6%   $
��Left=�60   $��447,540,0,0q�6K   $	��Top=�6`   $��61��6x   $	��231��6�   #���  6�   �� 5   
   $��872,195,26,2q�6   
����d�.+�5      �� -   5         ��Name$ 	LbPrice15��5      $��	1 000 000��6'   $��15(�6;   $��Center=�6I   $��Center=�6f    $  BackgroundColorForSillPriceLabel#���  6�   �� 5      -   5        $ 	LbPrice14��5      $��500 000��6'   $��15(�69   $��Center=�6G   �� 5      -   5        $ 	LbPrice13��5      $��250 000��6'   $��15(�69   $��Center=�6G   �� 5      -	   5        $ 	LbPrice12��5      $��125 000��6'   $��15(�69   $��Center=�6G   �� 5      -
   5        $ 	LbPrice11��5      $��64 000��6'   $��15(�68   $��Center=�6F   �� 5      -   5        $ 	LbPrice10��5      $��32 000��6'   $��15(�68   $��Center=�6F   �� 5      -   5        $ LbPrice9��5      $��16 000��6&   $��15(�67   $��Center=�6E   #���  6b   �� 5      -   5        $ LbPrice8��5      $��8 000��6&   $��15(�66   $��Center=�6D   �� 5      -   5        $ LbPrice7��5      $��4 000��6&   $��15(�66   $��Center=�6D   �� 5      -   5        $ LbPrice6��5      $��2 000��6&   $��15(�66   $��Center=�6D   �� 5      -   5        $ LbPrice5��5      $��1 000��6&   $��15(�66   $��Center=�6D   #���  6a   �� 5      -   5        $ LbPrice4��5      $	��500��6&   $��15(�64   $��Center=�6B   �� 5      -   5        $ LbPrice3��5      $	��300��6&   $��15(�64   $��Center=�6B   �� 5      -   5        $ LbPrice2��5      $	��200��6&   $��15(�64   $��Center=�6B   �� 5       -   5        $ LbPrice1��5       $	��100��6&   $��15(�64   $��Center=�6B   5!      �� 5"   
   -   5        $ BtnClose��5"      $��Izađi iz igre��6#   $
��Left=�6;   $��1060,31,0,0q�6V   $	��Top=�6k   $��34��6�   $��86��6�   6�   �� 5#   
   -   5        $ 
BtnNewGame��5#      $��	Nova igra��6%   $
��Left=�69   $��
934,32,0,0q�6T   $	��Top=�6h   $��34��6�   $��86��6�   6�   &   System.Windows.Controls.DataGrid  5$   
   -   5        	  Name$	 DgResult��5$      $
��Left=�6%   $	��215��6@   $��	24,42,0,0q�6M   $	��Top=�6`   $	��303��6x   
   	RowHeight$
 30Q�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6�     BackgroundColor#���  6�      RowBackground
 �����   AlternatingRowBackground
 ��ح�   GridLinesVisibility$ 
Horizontal=�6     
IsReadOnly$
 True��67     AreRowDetailsFrozen$
 True��6I     CanUserReorderColumns$ False��5%         CanUserResizeColumns$ False��61      CanUserSortColumns$ False��6N   "   VerticalScrollBarVisibility$ Hidden=�6k    �� AlternationCount$ 2��6�      CanUserAddRows$ False��6�      CanUserDeleteRows$ False��6�      CanUserResizeRows$ False��6�      RowHeaderWidth$ 0Q�6�      RowStyle 5&      �� 5'       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5(      ��  �� Property �@J�IsHitTestVisible �� Value$ False��69   5)      5+      5-      5.      