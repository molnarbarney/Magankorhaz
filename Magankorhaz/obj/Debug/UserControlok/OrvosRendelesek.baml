   M S B A M L   `   `   `  ����  Magankorhaz/    )Magankorhaz.UserControlok.OrvosRendelesek   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5	   
   �� $
��Left=�6   $ ��../Pictures/healthcare.png��6+   $	��670��6O   $��248,66,-136,-217q�6\   $	��Top=�6v   $	��964��6�     J� Opacity$	  0.2Q�6�   &   System.Windows.Controls.DataGrid  5
   
   -   5          Name$ idopontokDataGrid��5
      $	��Top=�6.   $��1200px��6F   $��500px��6U   
������    CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns .    
IsReadOnly . 
������ $��Stretch=�6N     CanUserResizeColumns .  	   SelectionMode$	 Single=�6�  
 �� SelectedIndex$
 -1��6�     AutoGenerateColumns .  ��6d   �� *	Idopontok+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        FoglaltIdopontColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Foglalt időpont��5   C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6\   �� *FoglaltIdopont+6�     5      -   5        PaciensColumn��$ Páciens��5   <    6M   �� *	Paciens+6k     5      -   5        OrvosColumn��$ Orvos��5   :    6I   �� *Orvos+6e   5      �� 5   
   -   5         ��Name$ ujIdopontButton��5   ]   $��200px��6   $
��50px��6   $��200,300,0,0q�6-   $
��Left=�6B   $��Új időpont felvétele��6v   6�   �� 5   
   -   5        $ idopontModositasaButton��5   a   $��200px��6   $
��50px��6   $��100,300,100,0q�6-   $��Center=�6D   $��Időpont módosítása��6�   {�.  6�   �� 5   
   -   5        $ idopontTorleseButton��5   ^   $��200px��6   $
��50px��6   $��0,300,200,0q�6-   $��Right=�6B   $��Időpont törlése��6|   {�.  6�   5      5      