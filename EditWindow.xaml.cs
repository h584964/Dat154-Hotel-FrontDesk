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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private readonly HotelDbContext dx = new();

        private readonly LocalView<Booking> Bookings;
        private readonly LocalView<Customer> Customers;
        private readonly LocalView<Room> Rooms;

        private Booking _booking;

        public EditWindow(Booking booking)
        {
            InitializeComponent();

            Bookings = dx.Bookings.Local;
            Customers = dx.Customers.Local;
            Rooms = dx.Rooms.Local;

            dx.Bookings.Load();
            dx.Customers.Load();
            dx.Rooms.Load();

            _booking = booking;

            RoomNumberTextBox.Text = _booking.RoomNumber.ToString();
            CheckInDatePicker.SelectedDate = _booking.CheckInDate;
            CheckOutDatePicker.SelectedDate = _booking.CheckOutDate;
            NumberOfGuestsTextBox.Text = _booking.NumberOfGuests.ToString();
            TotalPriceTextBox.Text = _booking.TotalPrice.ToString("F2");

            // Last inn kundeinformasjon
            Customer customer = dx.Customers.Find(_booking.CustomerId);
            FirstNameTextBox.Text = customer.FirstName;
            LastNameTextBox.Text = customer.LastName;
            EmailTextBox.Text = customer.Email;
            PhoneNumberTextBox.Text = customer.PhoneNumber;


        }

        private void SaveReservation_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = dx.Customers.Find(_booking.CustomerId);
            

            if (customer == null)
            {
                customer = new Customer();
                dx.Customers.Add(customer);
                _booking.CustomerId = customer.CustomerId;
            }

            // Oppdater kundeinformasjonen

            customer.FirstName = FirstNameTextBox.Text;
            customer.LastName = LastNameTextBox.Text;
            customer.Email = EmailTextBox.Text;
            customer.PhoneNumber = PhoneNumberTextBox.Text;


            // Oppdater reservasjonsinformasjonen med de endrede verdiene
            _booking.RoomNumber = int.Parse(RoomNumberTextBox.Text);
            _booking.CheckInDate = CheckInDatePicker.SelectedDate.Value;
            _booking.CheckOutDate = CheckOutDatePicker.SelectedDate.Value;
            _booking.NumberOfGuests = int.Parse(NumberOfGuestsTextBox.Text);
            _booking.TotalPrice = decimal.Parse(TotalPriceTextBox.Text);

           

            // Lagre endringene i databasen
            dx.SaveChanges();

            // Lukk vinduet og angi DialogResult til true for å indikere at endringene ble lagret
            DialogResult = true;
            Close();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; 
            Close();
        }
    }
}
