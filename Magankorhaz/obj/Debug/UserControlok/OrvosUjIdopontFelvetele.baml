   M S B A M L   `   `   `  ����  Magankorhaz7    1Magankorhaz.UserControlok.OrvosUjIdopontFelvetele   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5	   
   �� -   5          ��Name$  idopontOrvos��5	      $
��Left=�6)   $��
125,17,0,0q�6D   $	��Top=�6X   $	��204��6p   6|   �� 5
   
   -   5         ��Name$ idopontReszletek��5
      $
��Left=�6,   $��122,122,0,0q�6G    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��121��6�   $	��202��6�    �� 	MaxLength$ 10��6�   �� 5   
   -   5         ��Name$ UjIdopontMentesGomb��5      $��Mentés��6.   $
��Left=�6?   $��249,254,0,0q�6Z   $	��Top=�6o   $��75��6�   6�   �� 5   
   $��Dátum:��6   $
��Left=�6!   $��	14,92,0,0q�6<   $	��Top=�6O    J� RenderTransformOrigin$ 0.688,0.385&�6g   �� 5   
   $��Orvos:��6   $
��Left=�6!   $��	14,15,0,0q�6<   $	��Top=�6O   �� 5   
   $��Időpont részletei:��6   $
��Left=�6-   $��
14,122,0,0q�6H   $	��Top=�6\   �� 5   
   $��Foglalt időpontok:��6   $
��Left=�6-   $��	343,0,0,0q�6H   $	��Top=�6[   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ idopontDatum��5      $
��Left=�6+   $��
126,92,0,0q�6F   $	��Top=�6Z   6r   �� 5   
   -   5        $  
idopontOra��5      $
��Left=�6'   $��
233,92,0,0q�6B   $	��Top=�6V   $��43��6n   �� 5   
   -   5        $  idopontPerc��5      $
��Left=�6(   $��
285,92,0,0q�6C   $	��Top=�6W   $��43��6o   �� 5   
   $��:��6   $
��Left=�6   $��
274,92,0,0q�67   $	��Top=�6K   �� 5   
   -   5         ��Name$ foglaltIdopontokListBox��5      $
��Left=�63   $	��208��6N   $��
354,37,0,0q�6[   $	��Top=�6o   $	��230��6�   �� 5   
   $��	Páciens:��6   $
��Left=�6#   $��	15,52,0,0q�6>   $	��Top=�6Q   �� 5   
   -   5        $  idopontPaciens��5      $
��Left=�6+   $��
125,52,0,0q�6F   $	��Top=�6Z   $	��204��6r   ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� ��6$   �� *Nev+�� 5      $��(��6$   �� 5      ��6$   �� *SzuletesiDatum+	 �� StringFormat$	 {0:yyyy-MM-dd}���� 5      $��)��6$   5      5      5!      5"      5#      