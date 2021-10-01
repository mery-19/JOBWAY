using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOBWAY.Models
{
    public class Candidat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;
        private string usernname;
        private string password;
        private string description;
        private string cv;
        private string phone;
        private string email;
        private string poste;
        private DateTime date_creation = DateTime.Now;

        public int Id { get => id; set => id = value; }
        public string Usernname { get => usernname; set => usernname = value; }
        public string Password { get => password; set => password = value; }
        public string Description { get => description; set => description = value; }
        public string Cv { get => cv; set => cv = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Poste { get => poste; set => poste = value; }

        public DateTime Date_creation { get => date_creation; set => date_creation = value; }
    }
}