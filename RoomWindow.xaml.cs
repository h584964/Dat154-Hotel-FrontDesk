using FrontDesk.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FrontDesk
{
    /// <summary>
    /// Interaction logic for RoomWindow.xaml
    /// </summary>
    public partial class RoomWindow : Window
    {
        private readonly HotelDbContext dx = new();

        private readonly LocalView<Booking> Bookings;
        private readonly LocalView<Customer> Customers;
        private readonly LocalView<Room> Rooms;
        public RoomWindow()
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

        private void ShowAvailableRooms_Click(object sender, RoutedEventArgs e)
        {

            if (StartDatePicker.SelectedDate == null || EndDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select a valid date range.");
                return;
            }

            DateTime startDate = StartDatePicker.SelectedDate.Value;
            DateTime endDate = EndDatePicker.SelectedDate.Value;

            var availableRooms = dx.Rooms.Local.Where(room => !dx.Bookings.Local.Any(booking =>
                booking.RoomNumber == room.RoomNumber &&
                ((booking.CheckInDate >= startDate && booking.CheckInDate <= endDate) ||
                 (booking.CheckOutDate >= startDate && booking.CheckOutDate <= endDate) ||
                 (booking.CheckInDate <= startDate && booking.CheckOutDate >= endDate)))).ToList();

            RoomsDataGrid.ItemsSource = availableRooms;

        }

        private void ReserveRoom_Click(object sender, RoutedEventArgs e)
        {
            if (RoomsDataGrid.SelectedItem is Room selectedRoom)
            {
                int roomNumber = selectedRoom.RoomNumber;
                decimal price = selectedRoom.Price;
                DateTime? checkInDate = StartDatePicker.SelectedDate;
                DateTime? checkOutDate = EndDatePicker.SelectedDate;

                var addReservationWindow = new AddReservationWindow(roomNumber, checkInDate, checkOutDate, price);
                addReservationWindow.ReservationAdded += (s, args) => ShowAvailableRooms();
                addReservationWindow.ShowDialog();

            }
        }


        private void ShowAvailableRooms()
        {
            if (StartDatePicker.SelectedDate.HasValue && EndDatePicker.SelectedDate.HasValue)
            {
                DateTime checkInDate = StartDatePicker.SelectedDate.Value;
                DateTime checkOutDate = EndDatePicker.SelectedDate.Value;

                if (checkInDate <= checkOutDate)
                {
                    // Hent rom som er booket i den valgte perioden.
                    var bookedRooms = dx.Bookings
                        .Where(b => b.CheckInDate <= checkOutDate && b.CheckOutDate >= checkInDate)
                        .Select(b => b.RoomNumber)
                        .Distinct()
                        .ToList();

                    // Filtrer ut rom som ikke er booket i den valgte perioden.
                    var availableRooms = dx.Rooms.Local
                        .Where(r => !bookedRooms.Contains(r.RoomNumber))
                        .ToList();

                    // Oppdater romoversikten.
                    RoomsDataGrid.ItemsSource = availableRooms;
                }
                else
                {
                    MessageBox.Show("Check-in date must be earlier or equal to the check-out date.");
                }
            }
            else
            {
                MessageBox.Show("Please select both check-in and check-out dates.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
