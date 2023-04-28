using FrontDesk.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
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
using System.Data.Entity;

namespace FrontDesk
{
    /// <summary>
    /// Interaction logic for AddReservationWindow.xaml
    /// </summary>
    public partial class AddReservationWindow : Window
    {
        private readonly HotelDbContext dx = new();
        private readonly LocalView<Booking> Bookings;
        private readonly LocalView<Customer> Customers;
        private readonly LocalView<Room> Rooms;

        public event EventHandler ReservationAdded;
        public AddReservationWindow(int roomNumber, DateTime? checkInDate, DateTime? checkOutDate, decimal price)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            Bookings = dx.Bookings.Local;
            Customers = dx.Customers.Local;
            Rooms = dx.Rooms.Local;

            dx.Bookings.Load();
            dx.Customers.Load();
            dx.Rooms.Load();

        
            RoomNumberTextBox.Text = roomNumber.ToString();
            CheckInDatePicker.SelectedDate = checkInDate;
            CheckOutDatePicker.SelectedDate = checkOutDate;
            TotalPriceTextBox.Text = price.ToString("F2");

            
    }

        public AddReservationWindow()
        {
            InitializeComponent();

            InitializeComponent();
            WindowState = WindowState.Maximized;

            Bookings = dx.Bookings.Local;
            Customers = dx.Customers.Local;
            Rooms = dx.Rooms.Local;

            dx.Bookings.Load();
            dx.Customers.Load();
            dx.Rooms.Load();
        }

        private void AddReservation_Click(object sender, RoutedEventArgs e)
        {
           
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;


            Customer newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber

            };

            dx.Customers.Add(newCustomer);
            dx.SaveChanges();

        

            int roomNumber = int.Parse(RoomNumberTextBox.Text);
            DateTime checkInDate = CheckInDatePicker.SelectedDate.Value;
            DateTime checkOutDate = CheckOutDatePicker.SelectedDate.Value;
            int numberOfGuests = int.Parse(NumberOfGuestsTextBox.Text);
            decimal totalPrice = decimal.Parse(TotalPriceTextBox.Text);

            


            Booking newBooking = new Booking
            {
                CustomerId = newCustomer.CustomerId,
                RoomNumber = roomNumber,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                NumberOfGuests = numberOfGuests,
                TotalPrice = totalPrice,
               
            };

            dx.Bookings.Add(newBooking);
            dx.SaveChanges();

            MessageBox.Show("Reservation added successfully!");
            ReservationAdded?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}
