   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  
MainWindow��5   	   $	��460��6   $	��600��6)    � WindowStartupLocation$ CenterScreen=�65    � WindowState$ 	Maximized=�6Z    � 	Resources 5	         buttonColor �� Color��%-   &	        �� 5
   
   $ 	#FF1940A6��6.   5      .��5      �  � ShowGridLines .  ��5   
   �� 5       �� ImageSource$ Images/learing.png��6    j� Stretch$ Uniform=�6:    � ColumnDefinitions 5   
   �� 5      $
��101* �6   �� 5      $	��24* �6   �� 5      $
��468* �6   .+�5   
    � -   5        	  �Name$	 FramMain��5      
  � NavigationUIVisibility$
 Visible=�6#   $��Stretch=�6D   $��Stretch=�6b   $��4.667,68,0.333,0q�6~   
���   �$��2��6�   ��5      �� 5      $ Images/learing.png��6   $ Uniform=�6>   5      � 5   
   #��[  6   $	��Top=�6:   $��3��6S   $��68��6g   $��0,0,0.333,0q�6s   .+�5      �� $��Welcome��6   $
��Bold"�6&   $��Center=�68   $��30(�6U     
labelStyle#���  6c   $��
119,10,0,0q�6�   $	��Top=�6�   $��46��6�   $	��147��6�   
�������6�   5      � 5   
    .  $��0,68,0.333,-0.333q�6%   $��2��6@    � RowDefinitions 5      �� 5      $��* �6    �� 5       $��* �6    �� 5!      $��* �6    �� 5"      $��* �6    .+�5$      �� -   5         ��Name$ testerButton��5$      $��Tester��6+   $��40(�6<     MyBottonStyle#���  6L   #��[  6�   
�������$��2��6�   �� 5%      -   5        $ traineeButton��5%      $��Trainee��6,   $��40(�6>   $��1��6L   $��0��6Y   #���  6i   #��[  6�   
�������6�   �� 5&      -   5        $ 
testButton��5&      $
��Test��6)   $��40(�68   $��2��6F   $��0��6S   #���  6d   #��[  6�   
�������6�   �� 5'      -   5        $ 
ButtonLinq��5'      $
��Linq��6)   $��40(�68   $��3��6F   $��0��6S   #���  6c   #��[  6�   
�������6�   5(      5)      5*      