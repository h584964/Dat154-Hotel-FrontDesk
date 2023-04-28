using FrontDesk.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace FrontDesk
{
 

    public partial class MainWindow : Window
    {
        private readonly HotelDbContext dx = new();
        private readonly LocalView<Booking> Bookings;
        private readonly LocalView<Customer> Customers;
        private readonly LocalView<Room> Rooms;
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            Bookings = dx.Bookings.Local;
            Customers = dx.Customers.Local;
            Rooms = dx.Rooms.Local;


            dx.Bookings.Load();
            dx.Customers.Load();
            dx.Rooms.Load();


        }

        private void CheckInOut_Click(object sender, RoutedEventArgs e)
        {

        }
            

        private void ManageReservations_Click(object sender, RoutedEventArgs e)
        {

            var reservationsWindow = new ReservationWindow();
            reservationsWindow.Show();
            this.Close();
            
        }

        private void ManageRooms_Click(object sender, RoutedEventArgs e)
        {
            var roomWindow = new RoomWindow();
            roomWindow.Show();
            this.Close();
        }
    }
}
