   M S B A M L   `   `   `  ����D  @FrontDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:FrontDesk	FrontDesk  5   	   !    FrontDesk.ReservationWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:FrontDesk     5   	     � Title$  ReservationWindow��5   	   $	��450��6#   $	��800��60   .��5	      � $��	0,0,0,-16q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ booking��5
      $��0,44,0,0q�6<      AutoGenerateColumns$ False��6N   ��6$   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6)      Header$ 
Booking ID��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *	BookingId+  5      $	 250 6)   $ Customer ID��65    6J   �� *
CustomerId+  5      $	 100 6)   $ Room Number��65    6J   �� *
RoomNumber+  5      $	 200 6)   $ Check-In��65    6G   �� *CheckInDate+  5      $	 200 6)   $ 	Check-Out��65    6H   �� *CheckOutDate+  5      $	 100 6)   $ Guests��65    6E   �� *NumberOfGuests+  5      $	 100 6)   $ Total Price��65    6J   �� *
TotalPrice+5      �� 5   
   -   5        $��Show Reservations��5      $
��Left=�6-   $��	50,10,0,0q�6H   $	��Top=�6[   6s   �� 5      -   5        $��Add Reservation��5      $
��Left=�6/   $��
200,10,0,0q�6J   $	��Top=�6^   6v   �� 5      -   5        $��Delete Reservation��5      $
��Left=�62   $��
350,10,0,0q�6M   $	��Top=�6a   6y   �� 5      -   5        $
��Back��5      $��Right=�6$   $	��Top=�6@   $��
10,10,10,0q�6X   6l   5      5      