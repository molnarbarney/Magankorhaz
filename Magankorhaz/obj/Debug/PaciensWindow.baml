   M S B A M L   `   `   `  ����  Magankorhaz    Magankorhaz.PaciensWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  paciensWindow��5   	    � Title$ Magánkórház - Páciens��5   	   $	��700��6'   $
��1350��64    � 
ResizeMode$ CanMinimize=�6B   .��5      � .+�5   
   �� -   5         ��Name$ menu_background��5      ���	#FF355061$
��Left=�6>   $	��571��6Y   
���   �$	��Top=�6u   $	��229��6�   $��
-1,100,0,0q�6�   $��0��6�   �� 5   
   -   5        $ menu_header_background��5      ���	#FF1D3446$
��Left=�6E   $	��100��6`   
���   �$	��Top=�6|   $	��229��6�   $��-1,0,0,0q�6�   $��0��6�   �� 5   
   -   5        $ header_background��5      ���	#FFEBEBEB$
��Left=�6@   $	��100��6[   
���   �$	��Top=�6w   $
��1106��6�   $��	228,0,0,0q�6�   $��0��6�   �� 5	   
   -   5         ��Name$ kijelentkezesButton��5	   )   $��Kijelentkezés��6   $
��Left=�6F   $��1193,25,0,0q�6a   $	��Top=�6v   $	��117��6�   $��52��6�   $��16(�6�   �� 5
   
   -   5         ��Name$ felhasznalo��5
      $�� ��6%   $
��Left=�60   $��
245,22,0,0q�6K   $	��Top=�6_   $��20(�6w   $
��Bold"�6�   ���	#FF1D34466�   �� 5   
   -   5        $ felhasznaloTipus��5      $��Páciens��6*   $
��Left=�6<   $��
245,59,0,0q�6W   $	��Top=�6k   $��14(�6�   ���	#FF3550616�   �� 5   
   -   5        $ attekintesMenuGomb��5      $��Áttekintés��6-   $
��Left=�6B   $��	0,124,0,0q�6]   $	��Top=�6p    K� Capitals$ 	SmallCaps=�6�   $	��228��6�   $��50��6�   ���	#FF355061
�������$��Calibri)�6  $
��Bold"�6  $��16(�6(  ��6�   Z� 66  �� 5   
   $
��Left=�6   $��Pictures/healthcare.png��6+   $	��670��6L   $��492,0,-112,-147q�6Y   $��Bottom=�6r   $	��964��6�    J� Opacity$	 0.2Q�6�   �� 5   
   -	   5        $ kezeleseimMenuGomb��5      $��Kezeléseim��6-   $
��Left=�6B   $��	0,194,0,0q�6]   $	��Top=�6p   $ 	SmallCaps=�6�   $	��228��6�   $��50��6�   ���	#FF355061
�������$��Calibri)�6  $
��Bold"�6  $��16(�6(  ��6�   Z� 66  � 5   
   -
   5         �Name$ paciensMegtekinteseGrid��5      $
��Left=�60   $	��548��6K   $��245,113,0,0q�6X   $	��Top=�6m   $
��1089��6�   $y�Hidden=�6�   .+�5      �� $��Saját adatok��6   $
��Left=�6+   $��	10,10,0,0q�6F   $	��Top=�6Y   	 J� RenderTransformOrigin$	 0.224,-1.385&�6q   $
��Bold"�6�   $��16(�6�   ���	#FF1D34466�   �� 5      $
��Left=�6   $��Pictures/healthcare.png��6/   $	��670��6P   $��248,66,-136,-217q�6]   $	��Top=�6w   $	��964��6�   $	 0.2Q�6�   �� 5      ���	#FFF4F4F5$
��Left=�6)   $	��472��6D   $��	10,66,0,0q�6Q   
���   �$��0��6s   $	��Top=�6�   $	��391��6�   �� 5      $��Név:��6   $
��Left=�6#   $
��Left=�6E   $��	24,80,0,0q�6`   $	��Top=�6s   $��45��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5      $��E-mail:��6   $
��Left=�6&   $
��Left=�6H   $��
24,105,0,0q�6c   $	��Top=�6w   $��54��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5      $��Felhasználónév:��6   $
��Left=�6.   $
��Left=�6P   $��
24,130,0,0q�6k   $	��Top=�6   $	��105��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5      $��Jelszó:��6   $
��Left=�6&   $
��Left=�6H   $��
24,155,0,0q�6c   $	��Top=�6w   $	��105��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5      -   5        
 ��Name$
 paciensAdatNev��5      $
��Left=�6.   $��22��6I   $��	69,84,0,0q�6U    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��322��6�   ���	#FF1C9BB8 �� 
IsReadOnly . $
��Bold"�6  ��6�   Z� ��6�   Z�  �� SelectionBrush 6�   Z� 6  �� 5      -   5        $
 paciensAdatEmail��5      $
��Left=�60   $��18��6K   $��
79,109,0,0q�6W   $
 Wrap=�6k   $	��Top=�6   $	��312��6�   ���	#FF1C9BB8$
��Bold"�6   . ��6�   Z� ��6�   Z�  6�   Z� 6  �� 5      -   5        $
 paciensAdatFelhasznalonev��5      $
��Left=�69   $��18��6T   $��132,135,0,0q�6`   $
 Wrap=�6u   $	��Top=�6�   $	��264��6�   ���	#FF1C9BB8$
��Bold"�6   . ��6�   Z� ��6�   Z�  6�   Z� 6  G� 5      -   5         G�Name$ paciensAdatJelszo��5      $
��Left=�65   $��
77,160,0,0q�6P   $	��Top=�6d   $	��319��6|   ���	#FF1C9BB8{�.  $	 0.5,0.5&�6�   ��6�   Z�  G� SelectionBrush 6�   Z� ��6�   Z� z�5      V� 5       .~�5!      �� �� 5"      �� 5#       �� Angle$
 0.01Q�6*   T� 5$      5%      5'      �� 5)      $��Személyi szám:��6   $
��Left=�6-   $
��Left=�6O   $��
24,180,0,0q�6j   $	��Top=�6~   $��94��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5*      -   5        $
 paciensAdatSzemelyiSzam��5*      $
��Left=�67   $��18��6R   $��123,185,0,0q�6^   $
 Wrap=�6s   $	��Top=�6�   $	��156��6�   ���	#FF1C9BB8$
��Bold"�6	   . ��6�   Z� ��6�   Z�  6�   Z� 6  �� 5,      $
��TAJ:��6   $
��Left=�6#   $
��Left=�6E   $��
24,205,0,0q�6`   $	��Top=�6t   $��37��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5-      -   5        $
 paciensAdatTAJ��5-      $
��Left=�6.   $��18��6I   $��
62,210,0,0q�6U   $
 Wrap=�6i   $	��Top=�6}   $	��218��6�   ���	#FF1C9BB8$
��Bold"�6�    . ��6�   Z� ��6�   Z�  6�   Z� 6  �� 5/      $��Születési dátum:��6   $��Center=�6/   $
��Left=�6S   $��
22,230,0,0q�6n   $	��Top=�6�   $	��105��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   (  "System.Windows.Controls.DatePicker  50      -   5          Name$ paciensAdatSzuletesiDatum��50      $
��Left=�6<   $��127,233,0,0q�6W   $	��Top=�6l      IsTodayHighlighted . ���	#FF1C9BB8$
��Bold"�6�   $��0q�6�      FirstDayOfWeek$ Monday=�6�   {�.  ��6�   Z� 6
  �� 52      $��Lakcím:��6   $��Center=�6&   $
��Left=�6J   $��
23,255,0,0q�6e   $	��Top=�6y   $��53��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 53      -   5        $
 paciensAdatLakcim��53      $
��Left=�61   $��20��6L   $��
81,260,0,0q�6X   $
 Wrap=�6l   $	��Top=�6�   $	��316��6�   ���	#FF1C9BB8$
��Bold"�6   . ��6�   Z� ��6�   Z�  6�   Z� 6  �� 55      $��Telefon:��6   $��Center=�6'   $
��Left=�6K   $��
22,280,0,0q�6f   $	��Top=�6z   $��58��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 56      -   5        $
 paciensAdatTelefonszam��56      $
��Left=�66   $��20��6Q   $��
83,285,0,0q�6]   $
 Wrap=�6q   $	��Top=�6�   $	��311��6�   ���	#FF1C9BB8$
��Bold"�6   . ��6�   Z� ��6�   Z�  6�   Z� 6  �� 58      $��Neme:��6   $��Center=�6$   $
��Left=�6H   $��
22,305,0,0q�6c   $	��Top=�6w   $��48��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 59      -   5        $
 paciensAdatNeme��59      $
��Left=�6/   $��20��6J   $��
77,310,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��316��6�   ���	#FF1C9BB8$
��Bold"�6    . ��6�   Z� ��6�   Z�  6�   Z� 6  �� 5:      -   5         ��Name$ paciensAdatNemeComboBox��5:      $
��Left=�68   $��
75,300,0,0q�6S   $	��Top=�6g   $��81��6    �� SelectedIndex$ 0��6�   $y�Hidden=�6�   .@�5;      �� -   5         ��Name$ ferfii��5;      $��Férfi��6/   �� 5<      -   5        $	 noo��5<      $	��Nő��6,   5=      �� 5?      $��Utolsó bejelentkezés:��6   $��Center=�64   $
��Left=�6X   $��
22,330,0,0q�6s   $	��Top=�6�   $	��130��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5@      -   5        $$
 paciensAdatUtolsoBejelentkezes��5@      $
��Left=�6>   $��20��6Y   $��160,334,0,0q�6e   $
 Wrap=�6z   $	��Top=�6�   $	��234��6�   ���	#FF1C9BB8$
��Bold"�6   . ��6�   Z� ��6�   Z�  6�   Z� 6"  �� 5B      $��Felvétel dátuma:��6   $��Center=�6/   $
��Left=�6S   $��
22,355,0,0q�6n   $	��Top=�6�   $	��105��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5C      -   5        $
 paciensAdatFelvetel��5C      $
��Left=�63   $��20��6N   $��134,360,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $	��259��6�   ���	#FF1C9BB8$
��Bold"�6   . ��6�   Z� ��6�   Z�  6�   Z� 6  �� 5E      $��Távozás dátuma:��6   $��Center=�6.   $
��Left=�6R   $��
22,380,0,0q�6m   $	��Top=�6�   $	��105��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�     5F      -   5        $ paciensAdatTavozasDatum��5F      $
��Left=�6:   $��133,383,0,0q�6U   $	��Top=�6j    . ���	#FF1C9BB8$
��Bold"�6�   $��0q�6�   $ Monday=�6�   $y�Visible=�6  ��6�   Z� 6  �� 5H      $��Jelenlegi kezelőorvos:��6   $��Center=�65   $
��Left=�6Y   $��
22,405,0,0q�6t   $	��Top=�6�   $	��134��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5I      -   5        $
 paciensAdatOrvos��5I      $
��Left=�60   $��20��6K   $��163,410,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��230��6�   ���	#FF1C9BB8$
��Bold"�6   . ��6�   Z� ��6�   Z�  6�   Z� 6  �� 5K      $��Felelős ügyintező:��6   $��Center=�61   $
��Left=�6U   $��
22,430,0,0q�6p   $	��Top=�6�   $	��113��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5L      -   5        $
 paciensAdatUgyvezeto��5L      $
��Left=�64   $��20��6O   $��142,434,0,0q�6[   $
 Wrap=�6p   $	��Top=�6�   $	��251��6�   ���	#FF1C9BB8$
��Bold"�6   . ��6�   Z� ��6�   Z�  6�   Z� 6  �� 5O      $
��Left=�6   $��71��63   $��
422,66,0,0q�6?   
���   �$��0��6b   $	��Top=�6v   $	��648��6�   ���	#FFEBEBEB6�   �� 5Q      $��	Osztály:��6   $
��Left=�6'   $
��Left=�6I   $��
432,76,0,0q�6d   $	��Top=�6x   $��58��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5R      -   5        $ paciensAdatOsztalyText��5R      $
��Left=�64   $
��Left=�6V   $��
490,76,0,0q�6q   $	��Top=�6�   $	��372��6�   ���	#FF1C9BB8$
��Bold"�6�   $��28��6�   ��6�   Z�  � ToolTip 6�   �� *Text+ �� RelativeSource �� *Self+�� 5S      -   5        $  paciensAdatOsztalyComboBox��5S      $
��Left=�6;   $��
491,78,0,0q�6V   $	��Top=�6j   $	��372��6�   $��24��6�   $��Center=�6�   $y�Hidden=�6�   $ 0��6�   �� 5U      $��Szobaszám:��6   $
��Left=�6)   $
��Left=�6K   $��432,102,0,0q�6f   $	��Top=�6{   $��77��6�   ���	#FF0D6174$
��Bold"�6�   ��6�   Z� 6�   �� 5V      -   5        $ paciensAdatSzobaText��5V      $
��Left=�62   $
��Left=�6T   $��514,102,0,0q�6o   $	��Top=�6�   $	��123��6�   ���	#FF1C9BB8$
��Bold"�6�   $��28��6�   ��6�   Z� 6�   �� 5W      -    5        $ paciensAdatSzobaComboBox��5W      $
��Left=�69   $��515,104,0,0q�6T   $	��Top=�6i   $	��123��6�   $��24��6�   $��Center=�6�   $y�Hidden=�6�   $ 0��6�   �� 5[      ���	#FFEBEBEB$
��Left=�6)   $��42��6D   $��422,158,0,0q�6P   
���   �$��0��6t   $	��Top=�6�   $	��648��6�   �� 5\      -!   5        $ paciensAdatUjIdopontGomb��5\      $��Új időpont felvétele��67   $
��Left=�6V   $��927,166,0,0q�6q   $	��Top=�6�   $	��131��6�   $��26��6�   6�   &   System.Windows.Controls.DataGrid  5]      -"   5          Name$ paciensIdpontokListView��5]      $	��338��68   $��422,200,19,10q�6E   $	��648��6\   $��0q�6h      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 214 6|      CanUserResizeColumns .     MaxColumnWidth$	 214Q�6�      SelectionMode$ Single=�6�   6�   �� 5^      -#   5        $ IdopontokRefreshGomb��5^      $�� ��63   $
��Left=�6>   $��435,170,0,0q�6Y   $	��Top=�6n   $��20��6�   $��20��6�   $��0q�6�   ��6�   Z� ��6�   Z� ��5_      �� 5`       �� ImageSource$ Pictures/refresh.png��6!   5b      5c      �� 5d   
   -$   5         ��Name$ kezelesVaszon��5d      $
��Left=�6(   $	��558��6C   $��235,108,0,0q�6P   $	��Top=�6e   $
��1101��6}   .+�5e        -%   5        $ tolDate��5e      $
��Left=�6*   $	��Top=�6E     �� Left$  24��6]   
! �� Top$! 54��6n     5f      -&   5        $ igDate��5f      $
��Left=�6)   $	��Top=�6D   $	  142��6\   $! 54��6n   �� 5g      $��Kezeléseim��6   $
��Left=�6)   $	��Top=�6D   $��16(�6\   $
��Bold"�6j   $  20��6|   $! 17��6�   �� 5h      $��-��6   $	  127��6    $! 47��62   $��16(�6B   $
��Bold"�6P   �� 5i      -'   5        $ kezelesLekerdezes��5i      $��Mutasd!��60   $	  407��6B   $! 54��6T   $	��100��6d   $��30��6p   $��16(�6|   $
��Bold"�6�   6�   �� 5j      -(   5        $��kezelesLista��5j   �   $��Center=�6   $��Center=�64   $	��406��6X   $  4��6e   $! 90��6u   $
��1093��6�   $y�Hidden=�6�   ��5k      �� 5l      " �� 
TargetType"" ��6   .�5m      �� # �� Property# � ��$ �� Value$$ Center=�6G   5n      % �� View% 5p      �� 5q      .P�5r      �� $��id��6)   & �� Width$& 0��6Y   ' �� DisplayMemberBinding' 65   �� *id+6Y   �� 5s      $��Dátum��6)   $	& 150��6a   ' 68   �� *	idopont+6a   �� 5t      $��Kezelőorvos��6)   $	& 150��6e   ' 6>   �� *orvos+6e   �� 5u      $��Szolgáltatás��6)   $	& 640��6f   ' 6?   �� *szolg+6f   �� 5v      $	��Ár��6)   $	& 150��6Y   ' 65   �� *ar+6Y   5w      5y      �� 5z      -)   5        $ osszesKoltseg��5z      $�� ��6+   $	  118��66   $	! 509��6H   $��16(�6Y   $
��Bold"�6g   $��33��6y   $	��973��6�   �� 5{      -*   5        $ kezelesReszletek��5{      $��
Részletek��6/   $	  969��6C   $! 54��6U   $	��100��6e   $��30��6q   $��16(�6}   $
��Bold"�6�   $y�Hidden=�6�   5|      5}      5      