using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace lesson2
{
    public class BookSeller
    {
        private string formattedPhoneNumber;

        /// <summary>
        /// Creates a new Seller object
        /// </summary>
        /// <param name="name">Title must not be empty.</param>
        /// <param name="email">Email Address must not be empty.</param>
        /// <param name="telephon">Telephon number must not be empty.</param>
        public BookSeller(string name, string email, string telephon)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must not be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email must not be empty.", nameof(email));
            if(string.IsNullOrWhiteSpace(telephon)) throw new ArgumentException("Telephon must not be empty.", nameof(telephon));

            Name = name;
            Email = CheckEmail(email);
            Telephon = CheckTelephon(telephon);
        }

        /// <summary>
        /// Gets the bookseller's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the bookseller's email.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the Telephon.
        /// </summary>
        public string Telephon { get; }

        /// <summary>
        /// Checks the pattern of the Telphon number
        /// </summary>
        public string CheckTelephon(string telephon)
        {
            Regex regexObj = new Regex(@"^(\+97[\s]{0,1}[\-]{0,1}[\s]{0,1}1|0)50[\s]{0,1}[\-]{0,1}[\s]{0,1}[1-9]{1}[0-9]{6}$");
            if (!regexObj.IsMatch(telephon))
            {
                string formattedPhoneNumber = regexObj.Replace(telephon, "(+$1$2) $3 $4");
                return formattedPhoneNumber;
            }
            else return telephon;
        }

        /// <summary>
        /// Checks the pattern of the Email Address
        /// </summary>
        public string CheckEmail(string email)
        {
            try
            {
                MailAddress emailObj = new MailAddress(email);
                return email;
            }
            catch
            {
                throw new ArgumentException("Email is not valid.", nameof(email));
            }
           
            
        }
    }
}

