   M S B A M L   `   `   `  ����B  >Huffman, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HuffmanProjectHuffmanProject  5   	       HuffmanProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HuffmanProject     5   	   -   5          �Name$  MainWindow1��5   	    � Title$  ��5   	   $	��350��6   $	��525��6    � 	Resources 5	       �� MergedDictionaries �� Source�� 5
   
    5      �� 5      $ 
Style.xaml?�6%   %    5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $	��20* �6   �� 5      $
��280* �6   �� 5      $	��19* �6    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      .+�5   
   o� -   5         o�Name$
 menu��5      $��2��6   .@�5      m� -   5         m�Name$ mi_file��5      $��Файл��6(   .@�5      m� -   5        $ 
mi_newfile��5      $��
Новий��6/   $
��Left=�6>   $	��135��6Y   6e   m� 5      -   5        $ mi_openfile��5      $��Відкрити��60   $
��Left=�6B   $	��135��6]   6i   m� 5       -   5        $ mi_savefile��5       $��Зберегти��60   $
��Left=�6B   $	��135��6]   6i   5"      m� 5#      -   5        $ mi_edit��5#      $��Правка��6(   .@�5$      m� -   5        $ mi_changeAlphabet��5$      $#��Змінити алфавіт��66   $
��Left=�6O   6j   5%      5&      �� 5'   
   -	   5        	 ��Name$	 tabControl_files��5'      $��1��6/   $��1��6@   $��0q�6M   ���	#FF4B4B4B��6a   Z� 6x   5)      5*      