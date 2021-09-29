using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JOBWAY.Models
{
    public class Offre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;
        private string titre;
        private string description;
        private string image;
        private double salaire;
        private string phone;
        private string email;
        private DateTime dateTime = DateTime.Now;
        private bool isTaken = false;
        private string categorie;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
        public double Salaire { get => salaire; set => salaire = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public bool IsTaken { get => isTaken; set => isTaken = value; }
        public string Categorie { get => categorie; set => categorie = value; }

    }
}