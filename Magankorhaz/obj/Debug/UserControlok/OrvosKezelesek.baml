   M S B A M L   `   `   `  ����  Magankorhaz.    (Magankorhaz.UserControlok.OrvosKezelesek   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5	   
   �� ���	#FFEBEBEB$
��Left=�6&   $	��450��6A   $��	40,10,0,0q�6N   $	��Top=�6a   $	��270��6y   �� 5
   
   ���	#FFEBEBEB$	��450��6&   $��
320,10,0,0q�63   $	��750��6G   $	��Top=�6S   $
��Left=�6k   �� 5   
   $
��Left=�6   $ ��../Pictures/healthcare.png��6+   $	��670��6O   $��248,66,-136,-217q�6\   $	��Top=�6v   $	��964��6�     J� Opacity$	  0.2Q�6�   �� 5   
   $��Páciensek:��6   $��	50,20,0,0q�6%   $��16(�68   $
��Bold"�6F   ���	#FF1D3446$
��Left=�6o    K� Capitals$ 	SmallCaps=�6�   �� 5   
   -   5         ��Name$ paciensListBox��5   q   $	��250��6   $	��400��6   $��	50,50,0,0q�6+   $	��Top=�6>   $
��Left=�6V   
������ 
������ ��6�   �� *	Paciensek+��5      �� 5      .R�5      �� .+�5      �� ��6$   �� *Nev+�� 5      ��6$   �� *SzuletesiDatum+ �� StringFormat$ {0:yyyy-MM-dd}��5      5      5      �� 5   
   $��Kezelések:��6   $��
350,20,0,0q�6%   $��16(�69   $
��Bold"�6G   ���	#FF1D3446$
��Left=�6p   $ 	SmallCaps=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ kezelesekDataGrid��5      $
��Left=�6.   $	��Top=�6I      
IsReadOnly . $��
350,50,0,0q�6s   $	��700��6�   
������ $	��400��6�      CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .  	   CanUserResizeRows	 .  
   AutoGenerateColumns
 .     SelectionMode$ Single=�6`  
������ ��6�   �� *	Kezelesek+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Páciens neve��6%   -   5        paciensNeveColumn��1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   V   �� *	Paciens+6t     5      $ Kezelés időpontja��6%   -   5        kezelesIdopontjaColumn�� 5   `   �� *KezelesDatuma+6�     5      $ Kezelés részletei��6%   -   5        kezelesReszleteiColumn�� 5   `   �� *KezelesReszletei+6�     5      $ 
Orvos neve��6%   -   5        orvosColumn�� 5   N   �� *Orvos+6j   5       �� 5!   
   -   5         ��Name$ ujkezelesButton��5!      $��Új kezelés��6*   $��
50,470,0,0q�6?   $	��200��6S   $��50��6_   $
��Left=�6k   $	��Top=�6�   6�   �� 5"   
   -   5        $ kezelesmodositasaButton��5"      $��Kezelés módosítása��62   $��350,470,0,0q�6O   $	��200��6d   $��50��6p   $
��Left=�6|   $	��Top=�6�   6�   �� 5#   
   -	   5        $ kezelesTorleseButton��5#      $��Kezelés törlése��6/   $��
0,470,50,0q�6I   $	��200��6]   $��50��6i   $��Right=�6u   $	��Top=�6�   6�   5$      5%      