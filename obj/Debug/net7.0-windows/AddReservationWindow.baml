   M S B A M L   `   `   `  ����D  @FrontDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:FrontDesk	FrontDesk  5   	   $    FrontDesk.AddReservationWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:FrontDesk     5   	     � Title$  AddReservationWindow��5   	   $	��450��6&   $	��800��63   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   $	��105��6,   �� 5      .+�5   
   �� $��0��6   $��0��6!   $��First Name:��61   $��Center=�6D   $��16��6_   �� 5   
   -   5        $��FirstNameTextBox��5   /   $��0��6   $��1��6   $��5,5,5,5q�6G   �� 5   
   $��1��6   $��0��6!   $��
Last Name:��61   $��Center=�6C   $��16��6^   �� 5    
   -   5        $��LastNameTextBox��5    /   $��1��6   $��1��6   $��5,5,5,5q�6F   �� 5"   
   $��2��6   $��0��6!   $��Email:��61   $��Center=�6?   $��16��6Z   �� 5#   
   -   5        $��EmailTextBox��5#   /   $��2��6   $��1��6   $��5,5,5,5q�6C   �� 5%   
   $��3��6   $��0��6!   $��Phone Number:��61   $��Center=�6F   $��16��6a   �� 5&   
   -   5        $��PhoneNumberTextBox��5&   /   $��3��6   $��1��6   $��5,5,5,5q�6I   �� 5(   
   $��4��6   $��0��6!   $��Room Number:��61   $��Center=�6E   $��16��6`   �� 5)   
   -   5        $��RoomNumberTextBox��5)   /   $��4��6   $��1��6   $��5,5,5,5q�6H   �� 5+   
   $��5��6   $��0��6!   $��Check-In Date:��61   $��Center=�6G   $��16��6b   (  "System.Windows.Controls.DatePicker  5,   
   -   5        $��CheckInDatePicker��5,   2   $��5��6   $��1��6"   $��5,5,5,5q�6K   �� 5.   
   $��6��6   $��0��6!   $��Check-Out Date:��61   $��Center=�6H   $��16��6c     5/   
   -   5        $��CheckOutDatePicker��5/   2   $��6��6   $��1��6"   $��5,5,5,5q�6L   �� 51   
   $��7��6   $��0��6!   $��Number of Guests:��61   $��Center=�6J   $��16��6e   �� 52   
   -   5        $��NumberOfGuestsTextBox��52   /   $��7��6   $��1��6   $��5,5,5,5q�6L   �� 54   
   $��8��6   $��0��6!   $��Total Price:��61   $��Center=�6E   $��16��6`   �� 55   
   -	   5        $��TotalPriceTextBox��55   /   $��8��6   $��1��6   $��5,5,5,5q�6H   �� 57   
   -
   5        $��9��57      $��Add Reservation��6   $��562,10,0,100q�68   $
��Left=�6k   $��1��6�   $��90��6�   59      5:      