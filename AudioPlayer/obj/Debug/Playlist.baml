   M S B A M L   `   `   `  ����F  BAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AudioPlayerAudioPlayer  5   	   )clr-namespace:AudioPlayerAudioPlayer  5   	       AudioPlayer.Playlist   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   "ucclr-namespace:AudioPlayer  5   	   %localclr-namespace:AudioPlayer  5   	   -   5          � Title$  
MainWindow��5
   	   $	��600��6   $	��350��6)    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . 
������  � 	Resources 5         ButtonPlaybackBackground �� 
TargetType �� Property �� Value	 �� Triggers
 P� Property P� Value  	TextStyle  BorderStyle��%i  &	        &	     &	     �� 5   
   " ��61   .�5      ��  � �� �#2e333a6-   �� 5       � ��$ 50��6&   �� 5       � ��$ 50��6'   	 5      P� 5      
 �@J�IsMouseOver . . �5      ��  �@J�Opacity$	 0.8Q�67   5      5      �� 5   
   " ��6"   .�5      ��  � ��
 �����6+   �� 5       � ��$ Century Gothic)�6+   5      �� 5    
   " ��6$   .�5!      ��  �@��CornerRadius$ 25��6-   �� 5"       � �� �#2e333a6+   �� 5#       � ��$ 3q�60   �� 5$       � �� �#4545456,   5%      5&      .��5)      #  MaterialDesignThemes.Wpf.Card  
������ .��5*   
   �� #��[ 6   ._�5+      � -   5        $
��Grid��5+      .+�5,      ]� .+�5-      �� $	��Top=�6!    �� Orientation$ 
Horizontal=�66   .+�5.      �� $��	My Tracks��6    #��[ 64   $��30(�6W   $��10, 10, 0, 0q�5/       �� 50      -   5        $��120, 10, 10, 0q�50   <   #��[  51   !   .��52      �� $��images/add.png��6$   $��25��6<   $��25��6G   ��53      �� 54   "    �� 
TargetType" ��62   .R�55   &   � .+�56   *   A� ���#2e333a62   A� 57   *   �� 58   *   #��z��6;   $��Center=�59   ;   $��Center=�5:   ;   5;   '   5<   #    J� Effect 5>      3  -System.Windows.Media.Effects.DropShadowEffect  5?   "      Color$ White��63      	Direction$	 120Q�6A      ShadowDepth$ 1Q�6Q      Opacity$	 0.2Q�6a   5A      5B      �� 5D      -   5        $��ListBox��5D   5   $��10, 15, 5, 15q�6   ���#2e333a$��Disabled=�5E      5J      5K      5L      5M      5N      5O      