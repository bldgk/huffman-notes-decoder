   M S B A M L   `   `   `  ����B  >Huffman, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HuffmanProjectHuffmanProject  5   	   )    #HuffmanProject.WindowChangeAlphaber   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HuffmanProject     5   	     � Title$!  Зміна алфавіту��5   	   $	��300��6    $	��300��6-    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $ 
Style.xaml?�6%   %    5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��20* �6   �� 5      $��5* �6   �� 5      $
��239* �6    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      $
��197* �6   �� 5      $	��22* �6   �� 5      $	��73* �6   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $��2��6'    �� TextAlignment$ Center=�6;   $
��Wrap=�6R   $#��Введіть алфавіт��6f   $��1��6}   �� 5   
   -   5         ��Name$ Browse��5      $��^��6!   $��2��6-   $��1��6=   6J   �� 5    
   -   5        $ 
btn_change��5       $��Змінити��6%   $��3��67   $��1��6G   6T   �� 5!   
   -   5        	 ��Name$	 textBox��5!      $��4��6#   $��3��67   
 �� TextWrapping$

 Wrap=�6D   5"      5#      