   M S B A M L   `   `   `  ����C  ?Estudio1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:EstudioEstudio  5   	       Estudio.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Estudio     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��0,29,0,0q�6   .+�5
   
   �� -   5        $��ip��5
   y   $
��Left=�6   $��
131,29,0,0q�6-    �� TextWrapping$
 Wrap=�6A   $	��Top=�6U   $	��120��6m   6y   �� 5   
   -   5        $��porta��5   x   $
��Left=�6   $��
325,29,0,0q�6-   $
 Wrap=�6A   $	��Top=�6U   $��75��6m   6x   �� 5   
   -   5        $
��btOK��5   i   $��Salvar��6   $
��Left=�6"   $��
426,27,0,0q�6=   $	��Top=�6Q   $��20��6�   $��51��6�   6�   �� 5   
   $��IP do Servidor��6   $
��Left=�6)   $��	34,27,0,0q�6D   $	��Top=�6W   �� 5   
   $��Porta:��6   $
��Left=�6!   $��
274,24,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$ bt_Play��5   h   $
��Play��6   $
��Left=�6    $��109,304,0,0q�6;   $	��Top=�6P   $��18��6�   $��42��6�   �� 5   
   -   5         ��Name$ mensagemServidor��5      $��Mensagem��6*   $
��Left=�6=   $��109,327,0,0q�6X   $	��Top=�6m   $	��185��6�   �� 5   
   -   5        $��mensagem��5   y   $
��Left=�6   $��200,333,0,0q�6-   $
 Wrap=�6B   $	��Top=�6V   $��75��6n   6y   �� 5   
   -   5        $ BtEnviar��5      $��Enviar��6#   $
��Left=�64   $��334,333,0,0q�6O   $	��Top=�6d   6|   �� 5   
   -   5         ��Name$ playngMusic��5      $
��Left=�6'   $��
275,97,0,0q�6B   $	��Top=�6W   $	��120��6o   .��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      .��5      5      �� 5   
   -	   5        $ timerbox��5      $
��Left=�6$   $��
430,97,0,0q�6?   $	��Top=�6T   $	��120��6l   .��6x    5        5      .��5      5      �� 5   
   $��Tocando��6   $
��Left=�6"   $��
316,73,0,0q�6=   $	��Top=�6Q   �� 5   
   $��Tempo��6   $
��Left=�6    $��
467,73,0,0q�6;   $	��Top=�6O   $
��auto��6g   �� 5   
   $��	/logo.jpg��6   $��616,-6,10,325q�6#   &   System.Windows.Controls.DataGrid  5    
   -
   5        $��dataGrid��5       $��200,140,200,120q�6#   6>   5!      5"      