using FrontDesk.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.Entity;

namespace FrontDesk
{
    /// <summary>
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    public partial class ReservationWindow : Window
    {
        private readonly HotelDbContext dx = new();

        private readonly LocalView<Booking> Bookings;
        private readonly LocalView<Customer> Customers;
        private readonly LocalView<Room> Rooms;

        public ReservationWindow()
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


        private void ShowReservation()
        {
            booking.DataContext = Bookings.OrderBy(b => b.RoomNumber);

        }
        
        private void AddReservation_Click(object sender, RoutedEventArgs e)
        {
            var addReservationWindow = new AddReservationWindow();
            addReservationWindow.ReservationAdded += AddReservationWindow_ReservationAdded;
            addReservationWindow.ShowDialog();

            ShowReservation();
        }

        private void AddReservationWindow_ReservationAdded(object? sender, EventArgs e)
        {
            ShowReservation();
        }

        private void DeleteReservation_Click(Object sender, RoutedEventArgs e) 
        {
            var selectedReservation = booking.SelectedItem as Booking;

            
            if (selectedReservation != null)
            {
                
                dx.Bookings.Remove(selectedReservation);

                
                dx.SaveChanges();

                
                ShowReservation();
            }
            else
            {
                MessageBox.Show("Please select a reservation to delete.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void EditReservation_Click(object sender, RoutedEventArgs e)
        {
            var selectedReservation = booking.SelectedItem as Booking;
            if (selectedReservation != null)
            {
                // Åpne en ny dialog for å redigere den valgte reservasjonen.
                // Du må lage en ny Window (f.eks. EditReservationWindow) som lar brukeren redigere reservasjonen.
                var editReservationWindow = new EditWindow(selectedReservation);
                if (editReservationWindow.ShowDialog() == true)
                {
                    // Oppdater databasen med endringene i reservasjonen.
                    dx.SaveChanges();

                    // Oppdater reservasjonslisten.
                    ShowReservation();
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to edit.");
            }

        }
    }
}
